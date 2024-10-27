using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U3
{
    public class CustomMatrix : IMultiplicable
    {
        public List<int> Data { get; set; }

        public int Rows { get; set; }
        public int Cols { get; set; }

        public CustomMatrix(int rows = 3, int cols = 3)
        {
            Random rand = new Random();
            Data = new List<int>();
            Rows = rows;
            Cols = cols;

            for (int i = 0; i < Rows * Cols; i++)
            {
                Data.Add(rand.Next(0, 99));
            }
        }

        public IMultiplicable Multiply(IMultiplicable other)
        {
            var result = new CustomMatrix(Rows, other.Cols);

            if (Cols == other.Rows)
                return result;

            for (int i = 0; i < Rows * other.Cols; i++)
                result.Data.Add(0);

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < other.Cols; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < Cols; k++)
                    {
                        int aIndex = i * Cols + k;
                        int bIndex = k * other.Cols + j;

                        sum += Data[aIndex] * other.Data[bIndex];
                    }

                    result.Data[i * other.Cols + j] = sum;
                }
            }

            return result;
        }

        public void PrintStructure()
        {
            for (int i = 0; i < Rows * Cols; i++)
            {
                if (i % Cols == 0)
                    Console.WriteLine();

                Console.Write(Data[i] + " ");
            }

            Console.WriteLine();
        }
    }
}
