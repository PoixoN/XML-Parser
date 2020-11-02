using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Lab3
{
    public struct SearchCriteria
    {
        private readonly string _genre;
        private readonly string _year;
        private readonly string _company;
        private readonly string _rating;
        private readonly string _price;

        public string Genre { get { return _genre; } }
        public string Year { get { return _year; } }
        public string Company { get { return _company; } }
        public string Rating { get { return _rating; } }
        public string Price { get { return _price; } }

        public SearchCriteria(XmlNode game)
        {
            _genre = game.Attributes[PlaylistReader.genre].Value;
            _year = game.Attributes[PlaylistReader.year].Value;
            _company = game.Attributes[PlaylistReader.company].Value;
            _rating = game.Attributes[PlaylistReader.rating].Value;
            _price = game.Attributes[PlaylistReader.price].Value;
        }

        public SearchCriteria(string genre, string year, string company, string rating, string price)
        {
            _genre = genre;
            _year = year;
            _company = company;
            _rating = rating;
            _price = price;
        }


        public bool AllCriteriaAreEmpty()
        {
            return _genre.Equals("") && _year.Equals("") &&
                   _company.Equals("") && _rating.Equals("") && _price.Equals("");
        }

        public List<string> GetCriteriaList()
        {
            List<string> result = new List<string>();

            result.Add(_genre);
            result.Add(_year);
            result.Add(_company);
            result.Add(_rating);
            result.Add(_price);

            return result;
        }

        public bool IsRatingInCriteria(string rating, string ratingCriteria)
        {
            if (ratingCriteria.Equals(""))
            {
                return true;
            }

            double ratingParsed = double.Parse(rating.Split('/')[0], System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo);
            int lowerBound = int.Parse(ratingCriteria.Split('-')[0]);
            int upperBound = int.Parse(ratingCriteria.Split('-')[1]);

            return lowerBound <= ratingParsed && ratingParsed <= upperBound;
        }

        public bool IsPriceInCriteria(string price, string priceCriteria)
        {
            if (priceCriteria.Equals(""))
            {
                return true;
            }

            double priceParsed = 0; //Also if price = "Free"

            if (price.ToLower() != "free")
            {
                priceParsed = double.Parse(price.Split('$')[0], System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo); ;
            }
            else if (priceCriteria[0] == '1')
            {
                return true;
            }

            //"1. Only Free", "2. Less 10$", "3. Less 45$", "4. Less 130$", "5. More 130$"
            int criteria = int.Parse(priceCriteria[0].ToString());
            switch (criteria)
            {
                case 2:
                    return priceParsed < 10;
                case 3:
                    return priceParsed < 45;
                case 4:
                    return priceParsed < 130;
                case 5:
                    return priceParsed >= 130;
            }
            return false;
        }
    }
}
