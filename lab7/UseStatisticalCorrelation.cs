using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7
{
    internal class UseStatisticalCorrelation
    {
        public static double Average(double[] arr)
        {
            double sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            return sum / arr.Length;
        }

        //середнє квадратичне відхилення по х та у
        public static double StandardDeviation(double[] arr)
        {
            double res = 0;
            double averg = Average(arr);
            for (int i = 0; i < arr.Length; i++)
            {
                res += Math.Pow(arr[i] - averg, 2);
            }
            res /= arr.Length;
            return Math.Sqrt(res);
        }

        //статистичний кореляційний момент(коваріація)
        public static double StatisticalCorrelationMoment(double[] x, double[] y)
        {
            double avergX = Average(x);
            double avergY = Average(y);
            double sum = 0;
            for (int i = 0; i < x.Length; i++)
            {
                sum += (x[i] - avergX) * (y[i] - avergY);
            }
            return sum /= x.Length;
        }

        //статистичний коефіцієнт кореляції
        public static double StatisticalCorrelationCoefficient(double[] x, double[] y)
        {
            return StatisticalCorrelationMoment(x, y) / (StandardDeviation(x) * StandardDeviation(y));
        }

        public static double RXnY(double[] x, double[] y)
        {
            return StatisticalCorrelationCoefficient(x, y) * (StandardDeviation(x) / StandardDeviation(y));
        }

        public static double RYnX(double[] x, double[] y)
        {
            return StatisticalCorrelationCoefficient(x, y) * (StandardDeviation(y) / StandardDeviation(x));
        }

        public static string GetY(double[] x, double[] y)
        {
            double statX = UseStatisticalCorrelation.Average(x);
            double statY = UseStatisticalCorrelation.Average(y);
            double ynaX = RYnX(x, y);
            return $"y = {Math.Round(ynaX, 3)}(x - {Math.Round(statX, 3)}) + {Math.Round(statY, 3)} ";
        }

        public static string GetX(double[] x, double[] y)
        {
            double statX = UseStatisticalCorrelation.Average(x);
            double statY = UseStatisticalCorrelation.Average(y);
            double XnaY = RXnY(x, y);
            return $"x = {Math.Round(XnaY, 3)}(y - {Math.Round(statY, 3)}) + {Math.Round(statX, 3)} ";
        }

    }
}
