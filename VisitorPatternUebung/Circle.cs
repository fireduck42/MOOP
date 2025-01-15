using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPatternUebung
{
    public class Circle : IShape
    {
        public double Radius { get; set; }
        public Circle(double radius) 
        { 
            Radius = radius;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public void GetArea()
        {
            Console.WriteLine($"Area: {2*Math.PI*Radius}");
        }
    }
}
