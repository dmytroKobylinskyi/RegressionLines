using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7
{
    internal class LeastSquaresMethod
    {
        //обчислення визначника
        public static double CulculateDelta(double[] arr)
        {
            double sum1 = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum1=sum1+Math.Pow(arr[i],2);
            }
            sum1*=arr.Length;
            double sum2 = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum2 += arr[i];
            }
            sum2 = Math.Pow(sum2,2);
            return sum1-sum2;
        }

        //обчислення другорядного визначника
        public static double CulculateAlphaDelta(double[] x, double[] y)
        {
            double sumx2 = x.Sum((X) => Math.Pow(X, 2));
            double sumy = y.Sum();
            double sumx = x.Sum(X=>X);
            double sumyxy = 0;
            for (int i = 0; i < x.Length; i++)
            {
                sumyxy += x[i]*y[i];
            }
            return sumx2 * sumy - sumx * sumyxy;
        }

        //обчислення другорядного визначника
        public static double CulculateBetaDelta(double[] x, double[] y)
        {
            double sumy = y.Sum();
            double sumx = x.Sum(X => X);
            double sumyxy = 0;
            for (int i = 0; i < x.Length; i++)
            {
                sumyxy += x[i] * y[i];
            }
            return x.Length*sumyxy - sumx*sumy;
        }

        //обчислення коефіцієнту альфа
        public static double Alpha(double[] x, double[] y)
        {
            return CulculateAlphaDelta(x,y) / CulculateDelta(x);
        }

        //обчислення коефіцієнту бета
        public static double Beta(double[] x, double[] y)
        {
            return CulculateBetaDelta(x, y) / CulculateDelta(x);
        }

        //пряма
        public static string GetYPriam(double[] x, double[] y)
        {
            double beta=Beta(x, y);
            if(beta >= 0)
                return $"y = {Math.Round(Alpha(x,y),3)} + {Math.Round(beta,3)}x";
            else
                return $"y = {Math.Round(Alpha(x, y), 3)} - {Math.Round(beta, 3)}x";
        }

        //пряма
        public static string GetXPriam(double[] x, double[] y)
        {
            double beta = Beta(y, x);
            if (beta >= 0)
                return $"x = {Math.Round(Alpha(y, x), 3)} + {Math.Round(beta, 3)}y";
            else
                return $"x = {Math.Round(Alpha(y, x), 3)} - {Math.Round(beta, 3)}y";
        }
    }
}
