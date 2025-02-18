using System;
using System.Collections.Generic;

namespace PoissonCheckApp
{
    public class PoissonGenerator
    {
        private Random rng;

        public PoissonGenerator()
        {
            rng = new Random();
        }

        /// <summary>
        /// Генерирует одно пуассоновское число с параметром lambda.
        /// Метод: перемножаем равномерные числа, пока произведение не станет меньше exp(-lambda).
        /// Итоговое число = (количество умножений - 1).
        /// </summary>
        public int NextPoisson(double lambda)
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

        /// <summary>
        /// Генерирует выборку из N пуассоновских чисел.
        /// </summary>
        public List<int> GenerateSample(int N, double lambda)
        {
            var sample = new List<int>(N);
            for (int i = 0; i < N; i++)
            {
                sample.Add(NextPoisson(lambda));
            }
            return sample;
        }
    }
}
