
using integral2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integral2
{
    public class Integrator1 : IntegralRoot
    {
        public delegate void IntStepDelegate(double x, double f, double integr);
        public delegate void IntFinishDelegate(double integr);

        public event IntStepDelegate OnStep;
        public event IntFinishDelegate OnFinish;

        private delegate double Equa(double x);
        Equa equa1;
        /// <summary>
        /// Конструктор класса "интегратор"
        /// </summary>
        /// <param name="equation">интегрируемое уравнение</param>
        public override void Integrator(Equation equation)
        {
            //проверяем допустимость параметров:
            if (equation == null)
            {
                throw new ArgumentNullException();
            }
            equa1 = (equation.GetValue);
        }
        /// <summary>
        /// Функция интегрирования
        /// </summary>
        /// <param name="x1">левая граница интегрирования</param>
        /// <param name="x2">правая граница интегрирования</param>
        public override double Integrate(double x1, double x2,double N)
        {
            //проверяем допустимость параметров:
            if (x1 >= x2)
            {
                throw new ArgumentException("Правая граница интегирования должны быть больше левой!");
            }
            /* для интегирования разобъем исходный отрезок на 100 точек. 
             * Считаем значение функции в точке, умножаем на ширину интервала.
             * Площадь полученного прямоугольника приблизительно равна значению интеграла на этом отрезке
             * суммируем значения площадей, получаем значение интеграла на отрезке [X1;X2]*/
    //количество интервалов разбиения
            //определяем ширину интервала:
            double h = (x2 - x1) / N;
            double sum = 0; //"накопитель" для значения интеграла
            for (double i = 0; i < N; i++)
            {

                sum = sum + equa1(x1 + i * h);
                RaiseStepEvent(x1 + i * h, equa1(x1 + i * h), sum);
            }
            return sum*h;
        }

        void RaiseStepEvent(double x, double f, double sum)
        {
            if (OnStep != null)
            {
                OnStep(x, f, sum);
            }
        }

        void RaiseFinishEvent(double sum)
        {
            if (OnFinish != null)
            {
                OnFinish(sum);
            }
        }

    }

}

