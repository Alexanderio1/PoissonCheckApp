using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace PoissonCheckApp
{
    public partial class Form1 : Form
    {
        private Random rng;
        private List<int> sample1; // метод 1
        private List<int> sample2; // метод 2

        public Form1()
        {
            InitializeComponent();
            rng = new Random();
        }

        // ======= Первый метод (через CDF) =======
        private int NextPoissonCDF(double lambda, Random rng)
        {
            double p = Math.Exp(-lambda);
            double F = p;
            double u = rng.NextDouble();
            int k = 0;
            while (u > F)
            {
                k++;
                p = p * lambda / k;
                F += p;
            }
            return k;
        }
        // ======= Второй метод (через произведение) =======
        private int NextPoissonProduct(double lambda, Random rng)
        {
            double limit = Math.Exp(-lambda);
            double product = 1.0;
            int count = 0;
            while (product > limit)
            {
                product *= rng.NextDouble();
                count++;
            }
            return count - 1;
        }
        private void btnGenerateSample1_Click(object sender, EventArgs e)
        {
            int N = (int)numericUpDownN.Value;
            sample1 = new List<int>(N);

            double lambda = 3.0; // по условию
            for (int i = 0; i < N; i++)
            {
                int val = NextPoissonCDF(lambda, rng);
                sample1.Add(val);
            }

            ShowHistogram(sample1, chart1, "Метод 1 (CDF)");
        }

        private void btnGenerateSample2_Click(object sender, EventArgs e)
        {
            int N = (int)numericUpDownN.Value;
            sample2 = new List<int>(N);

            double lambda = 3.0; // по условию
            for (int i = 0; i < N; i++)
            {
                int val = NextPoissonProduct(lambda, rng);
                sample2.Add(val);
            }

            ShowHistogram(sample2, chart2, "Метод 2 (Product)");
        }

        private void btnCheckHypothesis_Click(object sender, EventArgs e)
        {
            if (sample1 == null || sample1.Count == 0 ||
                sample2 == null || sample2.Count == 0)
            {
                MessageBox.Show("Сначала сгенерируйте обе выборки!");
                return;
            }

            double mean1 = sample1.Average();
            double mean2 = sample2.Average();
            int n1 = sample1.Count;
            int n2 = sample2.Count;

            // Z-критерий
            double denominator = Math.Sqrt(mean1 / n1 + mean2 / n2);
            double Z = 0.0;
            if (denominator > 0)
                Z = (mean1 - mean2) / denominator;

            double zCritical = 1.96; // для alpha=0.05
            bool same = (Math.Abs(Z) <= zCritical);

            lblResult.Text =
                $"Среднее выборки 1 = {mean1:F2}\n" +
                $"Среднее выборки 2 = {mean2:F2}\n" +
                $"Z-значение = {Z:F2}\n" +
                (same
                  ? "Гипотеза НЕ отвергается (распределения совпадают)."
                  : "Гипотеза отвергается (распределения отличаются).");
        }

        /// <summary>
        /// Отображает гистограмму для заданной выборки и оформляет легенду.
        /// </summary>
        private void ShowHistogram(List<int> data, Chart chart, string seriesName)
        {
            chart.Series.Clear();
            chart.Legends.Clear();

            // Легенда
            var legend = new Legend
            {
                Title = "Гистограмма",
                Docking = Docking.Top
            };
            chart.Legends.Add(legend);

            // Серия
            var series = new Series(seriesName)
            {
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = false
            };
            series.Legend = legend.Name;
            chart.Series.Add(series);

            // Частоты
            var freq = new Dictionary<int, int>();
            foreach (int val in data)
            {
                if (!freq.ContainsKey(val)) freq[val] = 0;
                freq[val]++;
            }

            foreach (var kvp in freq.OrderBy(x => x.Key))
            {
                series.Points.AddXY(kvp.Key, kvp.Value);
            }
            chart.ChartAreas[0].RecalculateAxesScale();
        }
    }
}
