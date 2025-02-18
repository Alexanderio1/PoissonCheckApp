using System;
using System.Collections.Generic;
using System.Linq;

namespace PoissonCheckApp
{
    public static class Statistics
    {
        /// <summary>
        /// Вычисляет среднее арифметическое по выборке.
        /// </summary>
        public static double Mean(List<int> sample)
        {
            if (sample == null || sample.Count == 0)
                throw new ArgumentException("Выборка пуста.");
            return sample.Average();
        }

        /// <summary>
        /// Выполняет приближённый Z‑тест для сравнения двух пуассоновских выборок.
        /// Возвращает Z‑значение.
        /// </summary>
        public static double ZTestForPoisson(List<int> sample1, List<int> sample2)
        {
            double mean1 = Mean(sample1);
            double mean2 = Mean(sample2);
            int n1 = sample1.Count;
            int n2 = sample2.Count;

            double denominator = Math.Sqrt(mean1 / n1 + mean2 / n2);
            if (denominator == 0)
                return 0;
            double z = (mean1 - mean2) / denominator;
            return z;
        }

        /// <summary>
        /// Вычисляет факториал n (n!).
        /// </summary>
        private static double Factorial(int n)
        {
            double result = 1;
            for (int i = 2; i <= n; i++)
                result *= i;
            return result;
        }

        /// <summary>
        /// Вычисляет p-значение для χ²‑статистики с заданными степенями свободы.
        /// pValue = Q(ν/2, χ²/2), где Q – комплементарная регуляризованная гамма-функция.
        /// </summary>
        public static double ChiSquarePValue(double chiSquare, int df)
        {
            return GammaQ(df / 2.0, chiSquare / 2.0);
        }

        /// <summary>
        /// Вычисляет логарифм гамма-функции с использованием приближения Ланцоша.
        /// </summary>
        private static double LogGamma(double x)
        {
            double[] cof = {
                76.18009172947146, -86.50532032941677,
                24.01409824083091, -1.231739572450155,
                0.1208650973866179e-2, -0.5395239384953e-5
            };
            double y = x;
            double tmp = x + 5.5;
            tmp -= (x + 0.5) * Math.Log(tmp);
            double ser = 1.000000000190015;
            for (int j = 0; j < cof.Length; j++)
            {
                y += 1;
                ser += cof[j] / y;
            }
            return -tmp + Math.Log(2.5066282746310005 * ser / x);
        }

        /// <summary>
        /// Вычисляет неполную гамма-функцию P(a, x) с помощью ряда.
        /// </summary>
        private static double GammaP(double a, double x)
        {
            const double EPS = 1e-8;
            double gln = LogGamma(a);
            if (x <= 0)
                return 0.0;
            double sum = 1.0 / a;
            double del = sum;
            double ap = a;
            for (int n = 1; n <= 100; n++)
            {
                ap += 1.0;
                del *= x / ap;
                sum += del;
                if (Math.Abs(del) < Math.Abs(sum) * EPS)
                    break;
            }
            return sum * Math.Exp(-x + a * Math.Log(x) - gln);
        }

        /// <summary>
        /// Вычисляет неполную гамма-функцию Q(a, x) с помощью цепной дроби.
        /// </summary>
        private static double GammaCF(double a, double x)
        {
            const double EPS = 1e-8;
            const int ITMAX = 100;
            double gln = LogGamma(a);
            double b = x + 1.0 - a;
            double c = 1.0 / 1e-30;
            double d = 1.0 / b;
            double h = d;
            for (int i = 1; i <= ITMAX; i++)
            {
                double an = -i * (i - a);
                b += 2.0;
                d = an * d + b;
                if (Math.Abs(d) < 1e-30)
                    d = 1e-30;
                c = b + an / c;
                if (Math.Abs(c) < 1e-30)
                    c = 1e-30;
                d = 1.0 / d;
                double delta = d * c;
                h *= delta;
                if (Math.Abs(delta - 1.0) < EPS)
                    break;
            }
            return Math.Exp(-x + a * Math.Log(x) - gln) * h;
        }

        /// <summary>
        /// Вычисляет комплементарную регуляризованную гамма-функцию Q(a, x).
        /// Если x < (a+1), используем Q = 1 – P(a, x), иначе – цепную дробь.
        /// </summary>
        private static double GammaQ(double a, double x)
        {
            if (x < (a + 1.0))
                return 1.0 - GammaP(a, x);
            else
                return GammaCF(a, x);
        }

        /// <summary>
        /// Выполняет критерий согласия (χ²‑тест) для проверки соответствия выборки
        /// теоретическому пуассоновскому распределению с параметром lambda.
        /// Возвращает кортеж: (χ²‑статистика, число степеней свободы, p‑значение).
        /// Для повышения точности, bins с ожидаемым числом меньше 5 объединяются.
        /// </summary>
        public static (double chiSquare, int df, double pValue) ChiSquareGoodnessOfFit(List<int> sample, double lambda)
        {
            int N = sample.Count;
            // Подсчитываем наблюдаемые частоты для каждого k
            var observed = new Dictionary<int, double>();
            foreach (int val in sample)
            {
                if (!observed.ContainsKey(val))
                    observed[val] = 0;
                observed[val]++;
            }
            // Определяем максимальное значение k из наблюдений
            int maxObserved = observed.Keys.Max();
            int maxK = maxObserved;
            var expected = new Dictionary<int, double>();
            double cumulativeExpected = 0;
            for (int k = 0; k <= maxK; k++)
            {
                double p = Math.Exp(-lambda) * Math.Pow(lambda, k) / Factorial(k);
                double expCount = N * p;
                expected[k] = expCount;
                cumulativeExpected += expCount;
            }
            // Если хвостовое ожидание (k > maxK) не равно нулю, добавляем дополнительную группу
            double tailExpected = N - cumulativeExpected;
            if (tailExpected > 0)
            {
                expected[maxK + 1] = tailExpected;
                if (!observed.ContainsKey(maxK + 1))
                    observed[maxK + 1] = 0;
            }

            // Объединяем категории с ожидаемым числом меньше 5
            List<double> O = new List<double>();
            List<double> E = new List<double>();
            double combinedO = 0;
            double combinedE = 0;

            foreach (var kvp in expected.OrderBy(k => k.Key))
            {
                int k = kvp.Key;
                double expVal = kvp.Value;
                double obsVal = observed.ContainsKey(k) ? observed[k] : 0;

                if (combinedE + expVal < 5)
                {
                    combinedE += expVal;
                    combinedO += obsVal;
                }
                else
                {
                    if (combinedE > 0)
                    {
                        O.Add(combinedO);
                        E.Add(combinedE);
                        combinedE = 0;
                        combinedO = 0;
                    }
                    if (expVal < 5)
                    {
                        combinedE += expVal;
                        combinedO += obsVal;
                    }
                    else
                    {
                        O.Add(obsVal);
                        E.Add(expVal);
                    }
                }
            }
            if (combinedE > 0)
            {
                O.Add(combinedO);
                E.Add(combinedE);
            }

            double chiSquare = 0;
            for (int i = 0; i < O.Count; i++)
            {
                double diff = O[i] - E[i];
                chiSquare += diff * diff / E[i];
            }
            int df = O.Count - 1; // число степеней свободы (поскольку λ задан, а не оценивается)

            double pValue = ChiSquarePValue(chiSquare, df);
            return (chiSquare, df, pValue);
        }
    }
}
