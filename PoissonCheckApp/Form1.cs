using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace PoissonCheckApp
{
    public partial class Form1 : Form
    {
        private PoissonGenerator generator;
        private List<int> sample1;
        private List<int> sample2;

        public Form1()
        {
            InitializeComponent();
            generator = new PoissonGenerator();
        }

        private void btnGenerateSample1_Click(object sender, EventArgs e)
        {
            double lambda = (double)numericUpDownLambda.Value;
            int N = (int)numericUpDownSampleSize.Value;
            sample1 = generator.GenerateSample(N, lambda);
            ShowHistogram(sample1, chart1, "Выборка 1");
        }

        private void btnGenerateSample2_Click(object sender, EventArgs e)
        {
            double lambda = (double)numericUpDownLambda.Value;
            int N = (int)numericUpDownSampleSize.Value;
            sample2 = generator.GenerateSample(N, lambda);
            ShowHistogram(sample2, chart2, "Выборка 2");
        }

        private void btnCheckHypothesis_Click(object sender, EventArgs e)
        {
            if (sample1 == null || sample1.Count == 0 ||
                sample2 == null || sample2.Count == 0)
            {
                MessageBox.Show("Сначала сгенерируйте обе выборки!");
                return;
            }

            double lambdaInput = (double)numericUpDownLambda.Value;
            double zValue = Statistics.ZTestForPoisson(sample1, sample2);
            double mean1 = Statistics.Mean(sample1);
            double mean2 = Statistics.Mean(sample2);

            // Критическое значение для уровня значимости 0.05 (±1.96)
            double zCritical = 1.96;
            string conclusion = Math.Abs(zValue) <= zCritical
                ? "Гипотеза НЕ отвергается (средние примерно равны)."
                : "Гипотеза отвергается (средние статистически различаются).";

            // Выполним критерий согласия для каждой выборки
            var chiSq1 = Statistics.ChiSquareGoodnessOfFit(sample1, lambdaInput);
            var chiSq2 = Statistics.ChiSquareGoodnessOfFit(sample2, lambdaInput);

            lblResult.Text =
                $"Введённое значение λ: {lambdaInput:F2}\r\n" +
                $"Выборочное значение λ (выборка 1): {mean1:F2}\r\n" +
                $"Выборочное значение λ (выборка 2): {mean2:F2}\r\n" +
                $"Z-значение (сравнение средних): {zValue:F2}\r\n" +
                $"{conclusion}\r\n\r\n" +
                $"Критерий согласия (χ²‑тест) для выборки 1:\r\n" +
                $"   χ² = {chiSq1.chiSquare:F2}, df = {chiSq1.df}, p = {chiSq1.pValue:F4}\r\n" +
                $"Критерий согласия (χ²‑тест) для выборки 2:\r\n" +
                $"   χ² = {chiSq2.chiSquare:F2}, df = {chiSq2.df}, p = {chiSq2.pValue:F4}";
        }

        /// <summary>
        /// Отображает гистограмму для заданной выборки и оформляет легенду.
        /// </summary>
        private void ShowHistogram(List<int> data, Chart chart, string seriesName)
        {
            chart.Series.Clear();
            chart.Legends.Clear();

            // Создаём легенду
            Legend legend = new Legend
            {
                Title = "Распределение",
                Docking = Docking.Top,
                Alignment = System.Drawing.StringAlignment.Center
            };
            chart.Legends.Add(legend);

            // Создаём серию для гистограммы
            var series = new Series(seriesName)
            {
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true // отображать значения над столбцами
            };
            series.Legend = legend.Name;
            chart.Series.Add(series);

            // Подсчитываем частоты
            var freq = new Dictionary<int, int>();
            foreach (int val in data)
            {
                if (!freq.ContainsKey(val))
                    freq[val] = 0;
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
