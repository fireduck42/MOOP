using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPatternUebung
{
    public class ConcreteVisitor : IVisitor
    {
        public ConcreteVisitor() { }

        public void Visit(Rectangle a)
        {
            a.GetArea();
        }

        public void Visit(Circle b)
        {
            b.GetArea();
        }
    }
}
