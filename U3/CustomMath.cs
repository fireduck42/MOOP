using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U3
{
    public class CustomMath
    {
        public static void MultiplyStructure(IMultiplicable multiplier1, IMultiplicable multiplier2)
        {
            var result = multiplier1.Multiply(multiplier2);
            result.PrintStructure();
        }
    }
}
