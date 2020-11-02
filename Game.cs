using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class Game
    {
        public string Name { get; set; }
        public string Company { get; set; }
        public string Rating { get; set; }
        public string Genre { get; set; }
        public string Year { get; set; }
        public string Price { get; set; }

        // Checks whether some of the attributes is unset.
        public bool HasEmptyAttribute()
        {
            return Name.Equals("") || Company.Equals("") || Rating.Equals("")
                 || Genre.Equals("") || Year.Equals("") || Price.Equals("");
        }
    }
}
