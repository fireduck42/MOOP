using System;

namespace CustomUebung
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ISandwichInterface sandwich = new CoreSandwich();
            sandwich = new CoveringSalad(sandwich);
            sandwich = new CoveringVeganMayonaise(sandwich);
            sandwich.CreateSandwich();

            Console.ReadKey();
            return;
        }
    }
}