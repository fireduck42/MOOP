using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPatternUebung
{
    public class CreditCardStrategy : IStrategy
    {
        public CreditCardStrategy() { }

        public void Execute(double data)
        {
            Console.WriteLine("Paying $" + data.ToString() + " with the CreditCard...");
        }
    }
}
