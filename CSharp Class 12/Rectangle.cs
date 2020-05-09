using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_Class_12
{
    class Rectangle : Shape
    {
        private double a;
        private double b;

        public Rectangle(double a, double b)
        {
            this.a = a;
            this.b = b;
        }

        public override double CalculateArea()
        {
            return a * b;
        }
    }
}
