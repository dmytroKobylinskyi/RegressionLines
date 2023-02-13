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
    public partial class Grafics : Form
    {
        double[] x = new double[]
                {
                    0.32, 0.34, 0.34, 0.49, 0.52, 0.81, 0.88, 0.57,
                    0.42, 0.25, 0.86, 0.99, 0.72, 0.43, 0.25, 0.78,
                    0.29, 0.35, 0.34, 0.42, 0.47, 0.60, 0.34, 0.49,
                    0.91, 0.24, 0.32, 0.34, 0.41, 0.57, 0.86, 0.99
                };
        double[] y = new double[]
          {
                   0.29, 0.31, 0.65, 0.76, 0.43, 0.32, 0.10, 0.00,
                   0.34, 0.10, 0.00, 0.02, 0.22, 0.29, 0.31, 0.43,
                   0.24, 0.32 ,0.35, 0.43, 0.62, 0.81, 0.43, 0.27,
                   0.99, 0.59, 0.43, 0.23, 0.12, 0.24, 0.65, 0.76
          };
        public Grafics()
        {
            InitializeComponent();
        }

        private void вихідToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void удалитиГрафікиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.chart1.Series[0].Points.Clear();
            this.chart1.Series[1].Points.Clear();
            this.chart1.Series[2].Points.Clear();
        }

        private void побудуватиГрафікToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == false && radioButton2.Checked == false)
            {
                MessageBox.Show("Виберіть, який графік побудувати!", "Увага!");
            }
            if (radioButton1.Checked == true)
            {
                this.chart1.Series[0].Points.Clear();
                this.chart1.Series[1].Points.Clear();
                this.chart1.Series[2].Points.Clear();
                this.chart1.Series[1].Name = "Вхідні дані";

                chart1.ChartAreas[0].AxisX.Interval = Math.Round((x.Max() - x.Min()) / 10, 2);
                chart1.ChartAreas[0].AxisY.Interval = Math.Round((y.Max() - y.Min()) / 10, 2);
                chart1.ChartAreas[0].AxisX.Maximum = x.Max();
                chart1.ChartAreas[0].AxisY.Maximum = y.Max();
                for (int i = 0; i < x.Length; i++)
                {
                    this.chart1.Series[1].Points.AddXY(x[i], y[i]);
                }

                double beta = Math.Round(LeastSquaresMethod.Beta(x, y),3);
                double alpha = Math.Round(LeastSquaresMethod.Alpha(x, y),3);
                this.chart1.Series[0].Points.AddXY(0, alpha + beta * 0);
                this.chart1.Series[0].Points.AddXY(x.Max(), alpha + beta * x.Max());
                this.chart1.Series[0].Name = LeastSquaresMethod.GetYPriam(x, y);

                beta = Math.Round(LeastSquaresMethod.Beta(y, x), 3);
                alpha = Math.Round(LeastSquaresMethod.Alpha(y, x), 3);
                this.chart1.Series[2].Points.AddXY(alpha + beta * 0, 0);
                this.chart1.Series[2].Points.AddXY(alpha + beta * y.Max(), y.Max());
                this.chart1.Series[2].Name = LeastSquaresMethod.GetXPriam(x, y);
            }
            else if (radioButton2.Checked == true)
            {
                this.chart1.Series[0].Points.Clear();
                this.chart1.Series[1].Points.Clear();
                this.chart1.Series[2].Points.Clear();

                this.chart1.Series[1].Name = "Вхідні дані";

                chart1.ChartAreas[0].AxisX.Interval = Math.Round((x.Max() - x.Min()) / 10, 2);
                chart1.ChartAreas[0].AxisY.Interval = Math.Round((y.Max() - y.Min()) / 10, 2);
                chart1.ChartAreas[0].AxisX.Maximum = x.Max();
                chart1.ChartAreas[0].AxisY.Maximum = y.Max();

                for (int i = 0; i < x.Length; i++)
                {
                    this.chart1.Series[1].Points.AddXY(x[i], y[i]);
                }
                this.chart1.Series[0].Name = UseStatisticalCorrelation.GetY(x, y);
                this.chart1.Series[2].Name = UseStatisticalCorrelation.GetX(x, y);
                double statX = Math.Round(UseStatisticalCorrelation.Average(x),3);
                double statY = Math.Round(UseStatisticalCorrelation.Average(y),3);
                double ynaX = Math.Round(UseStatisticalCorrelation.RYnX(x, y),3);
                double XnaY = Math.Round(UseStatisticalCorrelation.RXnY(x, y),3);

                this.chart1.Series[0].Points.AddXY(0, ynaX * (0 - statX) + statY);
                this.chart1.Series[0].Points.AddXY(x.Max(), ynaX * (x.Max() - statX) + statY);

                this.chart1.Series[2].Points.AddXY(XnaY * (0 - statY) + statX, 0);
                this.chart1.Series[2].Points.AddXY(XnaY * (y.Max() - statY ) + statX, y.Max());
            }
        }
    }
}
