using StrategyPatternUebung;
using System;

namespace StrategyPatterUebung
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var str = new PaypalStrategy();
            var content = new PaymentService();
            content.SetStrategy(str);
            content.Pay(20.71);

            var str2 = new CreditCardStrategy();
            content.SetStrategy(str2);
            content.Pay(14.31);

            Console.ReadKey();
            return;
        }
    }
}