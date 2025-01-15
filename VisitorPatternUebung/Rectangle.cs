using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPatternUebung
{
    public class Rectangle : IShape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle() { }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public void GetArea()
        {
            Console.WriteLine($"Area: {Width*Height}");
        }
    }
}
