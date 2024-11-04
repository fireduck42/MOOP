using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U4
{
    public class Matrix2
    {
        public int Rows { get; set; }
        public int Columns { get; set; }

        private const int _defaultLength = 4;

        public List<int> Elements { get; set; }

        public Matrix2()
        {
            var rand = new Random();
            Rows = Columns = 2;
            Elements = new List<int>();
            for (int i = 0; i < _defaultLength; i++)
                Elements.Add(rand.Next(1, 99));
        }

        public static Matrix2 operator *(Matrix2 inputMatrix, Vector2 inputVector)
        {
            var resultMatrix = new Matrix2();
            for (int i = 0; i < _defaultLength; i++)
                resultMatrix.Elements[i] = inputMatrix.Elements[i] * inputVector.Elements[i];

            return resultMatrix;
        }

        public void PrintElements()
        {
            for (int i = 0; i < _defaultLength; i++)
                Console.WriteLine(Elements[i].ToString());   
        }
    }
}
