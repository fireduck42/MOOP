using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPatternUebung
{
    public interface IShape
    {
        public void Accept(IVisitor visitor);
    }
}
