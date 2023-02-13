using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //double[] x = new double[]
            //    {
            //        0.32, 0.34, 0.34, 0.49, 0.52, 0.81, 0.88, 0.57,
            //        0.42, 0.25, 0.86, 0.99, 0.72, 0.43, 0.25, 0.78,
            //        0.29, 0.35, 0.34, 0.42, 0.47, 0.60, 0.34, 0.49,
            //        0.91, 0.24, 0.32, 0.34, 0.41, 0.57, 0.86, 0.99
            //    };
            //double[] y = new double[]
            //  {
            //       0.29, 0.31, 0.65, 0.76, 0.43, 0.32, 0.10, 0.00,
            //       0.34, 0.10, 0.00, 0.02, 0.22, 0.29, 0.31, 0.43,
            //       0.24, 0.32 ,0.35, 0.43, 0.62, 0.81, 0.43, 0.27,
            //       0.99, 0.59, 0.43, 0.23, 0.12, 0.24, 0.65, 0.76
            //  };
            double[] x = new double[]
               {
                    -0.48, -0.34, -0.22, 0.24, 0.36, 0.51
               };
            double[] y = new double[]
             {
                    -0.43, -0.31, -0.17, 0.21, 0.33, 0.47
             };
            //double[] x = new double[]
            //    {
            //       0.35, 0.38, 0.42, 0.47, 0.91, 0.89, 
            //       0.49, 0.60, 0.86, 0.99, 0.72, 0.43,
            //       0.32, 0.34, 0.34, 0.49, 0.52, 0.81,
            //       0.42, 0.25, 0.86, 0.99, 0.72, 0.43
            //    };
            //double[] y = new double[]
            //  {
            //       0.24, 0.32, 0.35, 0.43, 0.62, 0.81,
            //       0.99, 0.59, 0.43, 0.27, 0.32, 0.29,
            //       0.29, 0.31, 0.65, 0.76, 0.43, 0.32, 
            //      0.34,  0.10, 0.00, 0.02, 0.22, 0.29
            //  };
            double delta=LeastSquaresMethod.CulculateDelta(x);
            double deltaAlpha = LeastSquaresMethod.CulculateAlphaDelta(x, y);
            double deltaBeta = LeastSquaresMethod.CulculateBetaDelta(x, y);
            double alpha = LeastSquaresMethod.Alpha(x, y);
            double beta = LeastSquaresMethod.Beta(x, y);

            double delta1 = LeastSquaresMethod.CulculateDelta(y);
            double deltaAlpha1 = LeastSquaresMethod.CulculateAlphaDelta(y, x);
            double deltaBeta1 = LeastSquaresMethod.CulculateBetaDelta(y, x);
            double alpha1 = LeastSquaresMethod.Alpha(y, x);
            double beta1 = LeastSquaresMethod.Beta(y, x);
            
            label1.Text = $"Δ = {Math.Round(delta, 5)}\n" +
                $"Δα = {Math.Round(deltaAlpha, 5)}\n" +
                $"Δβ = {Math.Round(deltaBeta, 5)}\n" +
                $"α = {Math.Round(alpha, 5)}\n" +
                $"β = {Math.Round(beta, 5)}\n" +
                $"{LeastSquaresMethod.GetYPriam(x,y)}";
            
            label3.Text = $"Δ' = {Math.Round(delta1, 5)}\n" +
                $"Δα' = {Math.Round(deltaAlpha1, 5)}\n" +
                $"Δβ' = {Math.Round(deltaBeta1, 5)}\n" +
                $"α' = {Math.Round(alpha1, 5)}\n" +
                $"β' = {Math.Round(beta1, 5)}\n" +
                $"{LeastSquaresMethod.GetXPriam(x, y)}";


            double Rxy = UseStatisticalCorrelation.StatisticalCorrelationCoefficient(x, y);
            double statX = UseStatisticalCorrelation.Average(x);
            double statY = UseStatisticalCorrelation.Average(y);
            double aver0X = UseStatisticalCorrelation.StandardDeviation(x);
            var aver0Y = UseStatisticalCorrelation.StandardDeviation(y);
            var XnY = UseStatisticalCorrelation.RXnY(x, y);
            var YnX = UseStatisticalCorrelation.RYnX(x, y);

            label2.Text = $"Rxy = {Math.Round(Rxy, 5)}\n" +
               $"x̄ = {Math.Round(statX, 5)}\n" +
               $"S0x = {Math.Round(aver0X, 5)}\n" +
               $"Sx|y = {Math.Round(XnY, 5)}\n" +
               $"{UseStatisticalCorrelation.GetX(x,y)}";
            label4.Text = $"\n" +
          $"ȳ = {Math.Round(statY, 5)}\n" +
          $"S0y = {Math.Round(aver0Y, 5)}\n" +
          $"Sy|x = {Math.Round(YnX, 5)}\n" +
          $"{UseStatisticalCorrelation.GetY(x, y)}";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Grafics grafics = new Grafics();
            grafics.Show();
        }
    }

}
