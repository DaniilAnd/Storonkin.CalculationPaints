using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storonkin.CalculationPaints.Class
{
    static class Calc
    {
         


        private static double Res;
        // Метод вычисления стоимости покраски
        public static double Result(double Square,int Layer,int Price,double SquareWindow, double SquareDoor)
        {
            double temp = (((Square - SquareWindow - SquareDoor) * Layer) / ((8 + 14) / 2)) * Price;
            Res = temp;
            return Res;
        }
        // Метод вычисления количества банок
        public static int ResCount(double Square, int Layer, double SquareWindow, double SquareDoor ) 
        {
            int temp = Convert.ToInt32(((Square - SquareWindow - SquareDoor) * Layer) / ((8 + 14) / 2));
            return temp + 1 ;

        }

        public static double SquareWall( double[] w, double[] h)
        {
            return w.Sum() * h.Sum();
        }

        public static double SquareDoor(double H, double W)
        {
            return H * W;
        }
        public static double SquareWindow(double H, double W)
        {
            return H * W;
        }
    }
}
