using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomUebung
{
    public class CoveringVeganMayonaise : VeganSandwich
    {
        public CoveringVeganMayonaise(ISandwichInterface wrappee) : base(wrappee)
        {
        }

        public override void CreateSandwich()
        {
            base.CreateSandwich();
            Console.WriteLine("Adding vegan mayonaise...");
        }
    }
}
