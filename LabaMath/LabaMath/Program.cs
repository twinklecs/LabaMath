using System;
using raminrahimzada;

namespace LabaMath
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal eps = 0.00001M; //Допустимая погрешность
            decimal a = 1;
            decimal b = 8; //Кол-во также итераций повысится, если вы значение этой переменной повысите

            Console.WriteLine("Метод дихотомии:\nМинимальное значение: " + dihot(a, b, eps, function(1)).Item1 + "\nИтераций: " + dihot(a, b, eps, function(1)).Item2 + "\n");
        }
        static decimal function(decimal x)
        {
            double a = 0.25 * Math.Pow(Convert.ToDouble(DecimalMath.E), Convert.ToDouble(-x)) + Convert.ToDouble(DecimalMath.Sin(x)) - 1;
            return Convert.ToDecimal(a);
        }

        static (decimal, int) dihot(decimal a, decimal b, decimal eps, decimal f)
        {
            int k = 0;
            decimal c, f1, f2 = 0;

            while (DecimalMath.Abs(a - b) > eps)
            {
                k++;
                c = (a + b) / 2;
                f1 = function(c - eps);
                f2 = function(c + eps);
                if (f1 > f2)
                    a = c;
                else if (f2 > f1)
                    b = c;
                else
                {
                    a = c - eps;
                    b = c + eps;
                }
            }
            return ((a + b) / 2, k);
        }
    }
}
