using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U3
{
    public class CustomVector : IMultiplicable
    {
        public List<int> Data { get; set; }
        public int Rows { get; set; }
        public int Cols { get; set; }

        public CustomVector(int cols = 5) 
        {
            Random rand = new Random();
            Data = new List<int>();
            Rows = 1; 
            Cols = cols;

            for (int i = 0; i < Cols; i++)
            {
                Data.Add(rand.Next(0, 99));
            }
        }

        public IMultiplicable Multiply(IMultiplicable otherMultiplier)
        {
            var result = new CustomVector();
            result.Data.Clear();

            for (int i = 0; i < Data.Count; i++)
            {
                var value = Data[i] * otherMultiplier.Data[i];
                result.Data.Add(value);
            }

            return result;
        }

        public void PrintStructure()
        {
            foreach (var item in Data)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
        }
    }
}
