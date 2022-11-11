using Integral2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integral2
{
    public class QuadEquation : Equation
    {
        private readonly double a;
        private readonly double b;
        private readonly double c;

        public QuadEquation(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        public override double GetValue(double x)
        {
            

            return Math.Sin(a *    x) / x;
        }

    }
}
