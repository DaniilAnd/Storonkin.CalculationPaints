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
        public static double Result(double Square,int Layer,int Price,double SquareWindow)
        {
            double temp = (((Square - SquareWindow) * Layer) / ((8 + 14) / 2)) * Price;
            Res = temp;
            return Res;
        }
        // Метод вычисления количества банок
        public static int ResCount(double Square, int Layer, double SquareWindow) 
        {
            int temp = Convert.ToInt32(((Square - SquareWindow) * Layer) / ((8 + 14) / 2));
            return temp + 1 ;

        }
    }
}
