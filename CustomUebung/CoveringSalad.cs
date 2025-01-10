using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomUebung
{
    public class CoveringSalad : VeganSandwich
    {
        public CoveringSalad(ISandwichInterface wrappee) : base(wrappee)
        {
        }

        public override void CreateSandwich()
        {
            base.CreateSandwich();
            Console.WriteLine("Adding salad...");
        }
    }
}
