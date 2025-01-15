using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPatternUebung
{
    public class PaypalStrategy : IStrategy
    {
        public PaypalStrategy() { }

        public void Execute(double data)
        {
            Console.WriteLine("Paying $" + data.ToString() + " PayPal...");
        }
    }
}
