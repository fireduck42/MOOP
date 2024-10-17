using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U2
{
    public enum MatrixDimension
    {
        oneXone = 1,
        twoXtwo,
        threeXthree,
        fourXfour,
        fiveXfive,
    }

    public class Matrix
    {
        public MatrixDimension Dimension { get; set; }
        public List<int> Values { get; set; }

        public Matrix(MatrixDimension dimension)
        {
            Values = [];
            Dimension = dimension;
            FillWithRandomValues();
        }

        private void FillWithRandomValues()
        {
            var random = new Random();
            int len = (int)Dimension * (int)Dimension;
            Values = [];

            for (int index=0; index < len; index++)
            {
                Values.Add(random.Next(0, 100));
            }
        }
    }
}
