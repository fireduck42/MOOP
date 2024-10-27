using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U3
{
    public interface IMultiplicable
    {
        public List<int> Data { get; set; }
        public int Rows { get; set; }
        public int Cols { get; set; }

        IMultiplicable Multiply(IMultiplicable otherMultiplier);
        void PrintStructure();
    }
}
