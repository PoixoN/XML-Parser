using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XmlParser
{
    public struct SearchCriteria
    {
        #region Propeties
        public string Genre { get; }
        public string Year { get; }
        public string Company { get; }
        public string Rating { get; }
        public string Price { get; }
        #endregion

        public SearchCriteria(XmlNode game)
        {
            Genre = game.Attributes[From1.genre].Value;
            Year = game.Attributes[From1.year].Value;
            Company = game.Attributes[From1.company].Value;
            Rating = game.Attributes[From1.rating].Value;
            Price = game.Attributes[From1.price].Value;
        }

        public SearchCriteria(string genre, string year, string company, string rating, string price)
        {
            Genre = genre;
            Year = year;
            Company = company;
            Rating = rating;
            Price = price;
        }


        public bool AllCriteriaAreEmpty()
        {
            return Genre.Equals("") && Year.Equals("") &&
                   Company.Equals("") && Rating.Equals("") && Price.Equals("");
        }

        public List<string> GetCriteriaList()
        {
            List<string> result = new List<string>();

            result.Add(Genre);
            result.Add(Year);
            result.Add(Company);
            result.Add(Rating);
            result.Add(Price);

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
