using System;

namespace U6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var dinner = new Dinner();
            dinner.startDinner();

            Console.ReadKey();
            return;
        }
    }
}