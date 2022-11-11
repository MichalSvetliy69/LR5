using Integral2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integral2
{
    public class MySin1 : Equation
    {
        private readonly double a;

        public MySin1(double a)
        {
            this.a = a;
        }
        public override double GetValue(double x)
        {
            double G = Math.Sin(a * x) / x;


            return Math.Sin(a * x) / x;
        }

    }
}
