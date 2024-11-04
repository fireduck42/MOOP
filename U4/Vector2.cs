using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U4
{
    public class Vector2
    {
        public int Rows { get; set; }
        public int Columns { get; set; }

        private const int _defaultLength = 4;

        public List<int> Elements { get; set; }

        public Vector2() 
        {
            Rows = 1;
            Elements = new List<int>();
            var rand = new Random();
            for (int i = 0; i < _defaultLength; i++)
                Elements.Add(rand.Next(1, 99));

            Columns = Elements.Count;
        }
    }
}
