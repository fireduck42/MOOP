using System;

namespace VisitorPatternUebung
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var element = new Rectangle();
            element.Accept(new ConcreteVisitor());

            Console.ReadKey();
            return;
        }
    }
}