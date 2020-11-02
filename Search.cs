using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace Lab3
{
    public interface ISearch
    {
        List<Game> Search(SearchCriteria criteria);
    }

    public class DomSearch : ISearch
    {
        private const int _maxCriteriaCount = 6;//===============================

        public List<Game> Search(SearchCriteria criteria)
        {
            List<Game> games = new List<Game>();
            XmlDocument doc = new XmlDocument();
            doc.Load(PlaylistReader.dataPath);

            /*XmlNode root = doc.DocumentElement;
            
            foreach (XmlNode gameNode in root.ChildNodes)
            {
                Game game = new Game();

                foreach (XmlAttribute attribute in gameNode.Attributes)
                {
                    FillAttributes(game, attribute, criteria);
                }

                games.Add(game.HasEmptyAttribute() ? null : game);
            }*/

            XmlNodeList gameNodes;

            string xPathCriteria = "";
            string gameSearchTag = "//" + PlaylistReader.gameTag;

            List<string> attributes = new List<string>();
            attributes.Add(PlaylistReader.genre);
            attributes.Add(PlaylistReader.year);
            attributes.Add(PlaylistReader.company);
            //attributes.Add(PlaylistReader.rating);
            //attributes.Add(PlaylistReader.price);

            List<string> criteriaList = new List<string>();
            criteriaList.Add(criteria.Genre);
            criteriaList.Add(criteria.Year);
            criteriaList.Add(criteria.Company);

            bool criteriaListEmpty = true;
            for (int i = 0; i < criteriaList.Count; i++)
            {
                if (!criteriaList[i].Equals(""))
                {
                    criteriaListEmpty = false;
                    xPathCriteria += "@" + attributes[i] + "='" + criteriaList[i] + "'and";
                }
            }
            if (criteria.AllCriteriaAreEmpty() || criteriaListEmpty)
            {
                gameNodes = doc.SelectNodes(gameSearchTag);
            }
            else
            {
                int andLength = 3;
                xPathCriteria = xPathCriteria.Substring(0, xPathCriteria.Length - andLength);

                string xPathQuery = gameSearchTag + "[" + xPathCriteria + "]";
                gameNodes = doc.SelectNodes(xPathQuery);
            }

            foreach (XmlNode gameNode in gameNodes)
            {
                Game game = new Game();
                FillAttributes(game, gameNode, criteria);
                if (!game.HasEmptyAttribute())
                {
                    games.Add(game);
                }
            }
            //string xPathQuery = ;
            //doc.SelectNodes()

            return games;
        }

        private void FillAttributes(Game game, XmlNode gameNode, SearchCriteria criteria)
        {
            game.Name = gameNode.Attributes[PlaylistReader.name].Value;
            game.Genre = gameNode.Attributes[PlaylistReader.genre].Value;
            game.Company = gameNode.Attributes[PlaylistReader.company].Value;
            game.Year = gameNode.Attributes[PlaylistReader.year].Value;

            if (!criteria.Rating.Equals(""))
            {
                game.Rating = criteria.IsRatingInCriteria(
                    gameNode.Attributes[PlaylistReader.rating].Value, criteria.Rating) ?
                    gameNode.Attributes[PlaylistReader.rating].Value : "";
            }
            else
            {
                game.Rating = gameNode.Attributes[PlaylistReader.rating].Value;
            }

            if (!criteria.Price.Equals(""))
            {
                game.Price = criteria.IsPriceInCriteria(
                gameNode.Attributes[PlaylistReader.price].Value, criteria.Price) ?
                gameNode.Attributes[PlaylistReader.price].Value : "";
            }
            else
            {
                game.Price = gameNode.Attributes[PlaylistReader.price].Value;
            }
        }

        // Sets the speified game's attributes.
        private void FillAttributes(Game game, XmlAttribute attribute, SearchCriteria criteria)
        {
            string attrName = attribute.Name;
            string attrValue = attribute.Value;

            if (attrName.Equals(PlaylistReader.name))
            {
                game.Name = attrValue;
            }
            if (attrName.Equals(PlaylistReader.genre))
            {
                game.Genre = ResolveCriteria(criteria.Genre, attrValue);
            }
            if (attrName.Equals(PlaylistReader.year))
            {
                game.Year = ResolveCriteria(criteria.Year, attrValue);
            }
            if (attrName.Equals(PlaylistReader.company))
            {
                game.Company = ResolveCriteria(criteria.Company, attrValue);
            }
            if (attrName.Equals(PlaylistReader.rating))
            {
                game.Rating = criteria.IsRatingInCriteria(attrValue, criteria.Rating) ? attrValue : "";
            }
            if (attrName.Equals(PlaylistReader.price))
            {
                game.Price = criteria.IsPriceInCriteria(attrValue, criteria.Price) ? attrValue : "";
            }
        }

        // Works on the search criteria constarints.
        private string ResolveCriteria(string criteria, string attrValue)
        {
            if (criteria.Equals(""))
            {
                return attrValue;
            }

            return attrValue.Equals(criteria) ? attrValue : "";
        }
    }

    public class SaxSearch : ISearch
    {
        public List<Game> Search(SearchCriteria criteria)
        {
            List<Game> games = new List<Game>();
            var xmlReader = new XmlTextReader(PlaylistReader.dataPath);

            while (xmlReader.Read())
            {
                if (xmlReader.HasAttributes && xmlReader.NodeType == XmlNodeType.Element)
                {
                    Game game = new Game();

                    while (xmlReader.MoveToNextAttribute())
                    {
                        FillAttributes(game, xmlReader, criteria);
                    }

                    games.Add(game.HasEmptyAttribute() ? null : game);
                }
            }

            return games;
        }

        // Sets the speified game's attributes.
        private void FillAttributes(Game game, XmlReader xmlReader, SearchCriteria criteria)
        {
            string attrName = xmlReader.Name;
            string attrValue = xmlReader.Value;

            if (attrName.Equals(PlaylistReader.name))
            {
                game.Name = attrValue;
            }
            if (attrName.Equals(PlaylistReader.genre))
            {
                game.Genre = ResolveCriteria(criteria.Genre, attrValue);
            }
            if (attrName.Equals(PlaylistReader.year))
            {
                game.Year = ResolveCriteria(criteria.Year, attrValue);
            }
            if (attrName.Equals(PlaylistReader.company))
            {
                game.Company = ResolveCriteria(criteria.Company, attrValue);
            }
            if (attrName.Equals(PlaylistReader.rating))
            {
                game.Rating = criteria.IsRatingInCriteria(attrValue, criteria.Rating) ? attrValue : "";
            }
            if (attrName.Equals(PlaylistReader.price))
            {
                game.Price = criteria.IsPriceInCriteria(attrValue, criteria.Price) ? attrValue : "";
            }
        }

        // Works on the search criteria constarints.
        private string ResolveCriteria(string criteria, string attrValue)
        {
            if (criteria.Equals(""))
            {
                return attrValue;
            }

            return attrValue.Equals(criteria) ? attrValue : "";
        }
    }

    public class LinqToXmlSearch : ISearch
    {
        public List<Game> Search(SearchCriteria criteria)
        {
            List<Game> games = new List<Game>();
            var doc = XDocument.Load(PlaylistReader.dataPath);

            var gamesInList = from obj in doc.Descendants(PlaylistReader.gameTag)
                              select new
                              {
                                  name = obj.Attribute(PlaylistReader.name).Value,

                                  year = criteria.Year.Equals("") ?
                                  obj.Attribute(PlaylistReader.year).Value :
                                  criteria.Year.Equals(obj.Attribute(PlaylistReader.year).Value) ?
                                  obj.Attribute(PlaylistReader.year).Value : "",

                                  genre = criteria.Genre.Equals("") ?
                                  obj.Attribute(PlaylistReader.genre).Value :
                                  criteria.Genre.Equals(obj.Attribute(PlaylistReader.genre).Value) ?
                                  obj.Attribute(PlaylistReader.genre).Value : "",

                                  company = criteria.Company.Equals("") ?
                                  obj.Attribute(PlaylistReader.company).Value :
                                  criteria.Company.Equals(obj.Attribute(PlaylistReader.company).Value) ?
                                  obj.Attribute(PlaylistReader.company).Value : "",

                                  rating = criteria.Rating.Equals("") ?
                                  obj.Attribute(PlaylistReader.rating).Value :
                                  criteria.IsRatingInCriteria(obj.Attribute(PlaylistReader.rating).Value, criteria.Rating) ?
                                  obj.Attribute(PlaylistReader.rating).Value : "",

                                  price = criteria.Price.Equals("") ?
                                  obj.Attribute(PlaylistReader.price).Value :
                                  criteria.IsPriceInCriteria(obj.Attribute(PlaylistReader.price).Value, criteria.Price) ?
                                  obj.Attribute(PlaylistReader.price).Value : "",
                              };

            foreach (var gameElem in gamesInList)
            {
                Game game = new Game();
                game.Name = gameElem.name;
                game.Company = gameElem.company;
                game.Rating = gameElem.rating;
                game.Genre = gameElem.genre;
                game.Year = gameElem.year;
                game.Price = gameElem.price;

                games.Add(game.HasEmptyAttribute() ? null : game);
            }

            return games;
        }
    }
}