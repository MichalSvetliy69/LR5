using integral2;
using Integral2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integral2
{
    internal class Integrator2 : IntegralRoot
    {




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
        public override double Integrate(double x1, double x2, double N)
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
            double maxY = 0; //"накопитель" для значения интеграла
            for (double i = 0; i < N; i++)
            {

                maxY = Math.Max(maxY, equa1(x1 + i * h));
            }


            
            Random rand = new Random();
            var randPoints = new double[Convert.ToInt32(N)];
            var randPointsX = new double[Convert.ToInt32(N)];
            double RandX;
            double RandY;
            for (int i = 0; i < randPoints.Length; i++)
            {

                RandX = rand.NextDouble() * ((x2) - (x1)) + (x1);
                randPointsX[i] = RandX;
                RandY = rand.NextDouble() * (maxY); /*(0, Convert.ToInt32(maxY))*/
                randPoints[i] = (RandY);
            }
            double counter = 0;
            for (int i = 0; i < randPointsX.Length; i++)
            {

                if (randPoints[i] < equa1(randPointsX[i]))
                {
                    counter++;
                }
                
            }
            double S = (x2-x1)*maxY;


            return S*(counter/ Convert.ToInt32(N));

        }
    }
}
