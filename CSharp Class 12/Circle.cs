using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_Class_12
{
    class Circle : Shape
    {
        private double radius;

        public Circle(double radius)
        {
            this.radius = radius;
        }

        public override double CalculateArea()
        {
            return radius * radius * Math.PI;
        }
    }
}
