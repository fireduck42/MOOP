using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomUebung
{
    public class CoreSandwich : ISandwichInterface
    {
        public void CreateSandwich()
        {
            Console.WriteLine("Adding two pieces of bread...");
        }
    }
}
