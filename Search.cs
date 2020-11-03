using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Xml;
using System.Xml.Linq;
using System.Linq;

namespace XmlParser
{
    public interface ISearch
    {
        List<Game> Search(SearchCriteria criteria);
    }

    #region Dom search
    public class DomSearch : ISearch
    {
        public List<Game> Search(SearchCriteria criteria)
        {
            List<Game> games = new List<Game>();
            XmlDocument doc = new XmlDocument();
            doc.Load(From1.dataPath);

            XmlNodeList gameNodes;

            string xPathCriteria = "";
            string gameSearchTag = "//" + From1.gameTag;

            List<string> attributes = new List<string>();
            attributes.Add(From1.genre);
            attributes.Add(From1.year);
            attributes.Add(From1.company);

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
                AddCreterias(game, gameNode, criteria);
                if (!game.HasEmptyAttribute())
                {
                    games.Add(game);
                }
            }

            return games;
        }

        /// <summary>
        /// Sets the the game's attributes
        /// </summary>
        private void AddCreterias(Game game, XmlNode gameNode, SearchCriteria criteria)
        {
            game.Name = gameNode.Attributes[From1.name].Value;
            game.Genre = gameNode.Attributes[From1.genre].Value;
            game.Company = gameNode.Attributes[From1.company].Value;
            game.Year = gameNode.Attributes[From1.year].Value;

            if (!criteria.Rating.Equals(""))
            {
                game.Rating = criteria.IsRatingInCriteria(
                    gameNode.Attributes[From1.rating].Value, criteria.Rating) ?
                    gameNode.Attributes[From1.rating].Value : "";
            }
            else
            {
                game.Rating = gameNode.Attributes[From1.rating].Value;
            }

            if (!criteria.Price.Equals(""))
            {
                game.Price = criteria.IsPriceInCriteria(
                gameNode.Attributes[From1.price].Value, criteria.Price) ?
                gameNode.Attributes[From1.price].Value : "";
            }
            else
            {
                game.Price = gameNode.Attributes[From1.price].Value;
            }
        }
    }
    #endregion

    #region Sax search
    public class SaxSearch : ISearch
    {
        public List<Game> Search(SearchCriteria criteria)
        {
            List<Game> games = new List<Game>();
            var xmlReader = new XmlTextReader(From1.dataPath);

            while (xmlReader.Read())
            {
                if (xmlReader.HasAttributes && xmlReader.NodeType == XmlNodeType.Element)
                {
                    Game game = new Game();

                    while (xmlReader.MoveToNextAttribute())
                    {
                        AddCriterias(game, xmlReader, criteria);
                    }

                    games.Add(game.HasEmptyAttribute() ? null : game);
                }
            }

            return games;
        }

        /// <summary>
        /// Sets the the game's attributes
        /// </summary>
        private void AddCriterias(Game game, XmlReader xmlReader, SearchCriteria criteria)
        {
            string attrName = xmlReader.Name;
            string attrValue = xmlReader.Value;

            if (attrName.Equals(From1.name))
            {
                game.Name = attrValue;
            }
            if (attrName.Equals(From1.genre))
            {
                game.Genre = CheckCriteria(criteria.Genre, attrValue);
            }
            if (attrName.Equals(From1.year))
            {
                game.Year = CheckCriteria(criteria.Year, attrValue);
            }
            if (attrName.Equals(From1.company))
            {
                game.Company = CheckCriteria(criteria.Company, attrValue);
            }
            if (attrName.Equals(From1.rating))
            {
                game.Rating = criteria.IsRatingInCriteria(attrValue, criteria.Rating) ? attrValue : "";
            }
            if (attrName.Equals(From1.price))
            {
                game.Price = criteria.IsPriceInCriteria(attrValue, criteria.Price) ? attrValue : "";
            }
        }

        private string CheckCriteria(string criteria, string attrValue)
        {
            if (criteria.Equals(""))
            {
                return attrValue;
            }

            return attrValue.Equals(criteria) ? attrValue : "";
        }
    }
    #endregion

    #region LINQ search
    public class LinqToXmlSearch : ISearch
    {
        public List<Game> Search(SearchCriteria criteria)
        {
            List<Game> games = new List<Game>();
            var doc = XDocument.Load(From1.dataPath);

            var gamesInList = from obj in doc.Descendants(From1.gameTag)
                              select new
                              {
                                  name = obj.Attribute(From1.name).Value,

                                  year = criteria.Year.Equals("") ?
                                  obj.Attribute(From1.year).Value :
                                  criteria.Year.Equals(obj.Attribute(From1.year).Value) ?
                                  obj.Attribute(From1.year).Value : "",

                                  genre = criteria.Genre.Equals("") ?
                                  obj.Attribute(From1.genre).Value :
                                  criteria.Genre.Equals(obj.Attribute(From1.genre).Value) ?
                                  obj.Attribute(From1.genre).Value : "",

                                  company = criteria.Company.Equals("") ?
                                  obj.Attribute(From1.company).Value :
                                  criteria.Company.Equals(obj.Attribute(From1.company).Value) ?
                                  obj.Attribute(From1.company).Value : "",

                                  rating = criteria.Rating.Equals("") ?
                                  obj.Attribute(From1.rating).Value :
                                  criteria.IsRatingInCriteria(obj.Attribute(From1.rating).Value, criteria.Rating) ?
                                  obj.Attribute(From1.rating).Value : "",

                                  price = criteria.Price.Equals("") ?
                                  obj.Attribute(From1.price).Value :
                                  criteria.IsPriceInCriteria(obj.Attribute(From1.price).Value, criteria.Price) ?
                                  obj.Attribute(From1.price).Value : "",
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
    #endregion
}