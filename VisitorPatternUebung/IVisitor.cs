using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPatternUebung
{
    public interface IVisitor
    {
        public void Visit(Rectangle a);
        public void Visit(Circle b);
    }
}
