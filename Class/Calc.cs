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
        public static double Result(double ResCount,int Price)
        {
            double temp = ResCount * Price;
            Res = temp;
            return Res;
        }
        // Метод вычисления количества банок
        public static double ResCount(double Square, int Layer, double SquareWindow, double SquareDoor ) 
        {
            double temp = (((Square - (SquareWindow + SquareDoor)) * Layer) / 11);
            return temp + 1 ;

        }
        

        // Метод получения площади
        public static double SquareWall( double[] w, double[] h)
        {
            
            return (w[0] * h[0])+ (w[1] * h[1])+ (w[2] * h[2]) + (w[3] * h[3]);

        }

        // Метод получения площади цвери
        public static double SquareDoor(double H, double W)
        {
            return H * W;
        }

        // Метод получения площади окон
        public static double SquareWindow(double H, double W)
        {
            return H * W;
        }
    }
}
