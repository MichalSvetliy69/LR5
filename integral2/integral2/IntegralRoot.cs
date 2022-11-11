using Integral2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integral2
{
    public abstract class IntegralRoot
    {
        public abstract void Integrator(Equation equation);

        public abstract double Integrate(double x1, double x2, double N);
    }
}
