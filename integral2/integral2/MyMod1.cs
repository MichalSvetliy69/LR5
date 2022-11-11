using Integral2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integral2
{
    internal class MyMod1 : Equation
    {
        private readonly double a;

        public MyMod1(double a)
        {
            this.a = a;
        }
        public override double GetValue(double x)
        {


            return a * x * Math.Abs(Math.Sin(x));
        }
    }
}
