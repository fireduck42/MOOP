using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomUebung
{
    public class VeganSandwich : ISandwichInterface
    {
        protected ISandwichInterface _wrappee;

        public VeganSandwich(ISandwichInterface wrappee)
        {
            _wrappee = wrappee;
        }

        public virtual void CreateSandwich()
        {
            _wrappee.CreateSandwich();
        }
    }
}
