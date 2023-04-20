using DongUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointGenerator
{
   
    internal class LogisticMap
    {
        private double r;
        private double x;
        private Random random;
        public LogisticMap(double r, Random rand)
        {
            this.r = r;
            random = rand;
            x = random.NextDouble(0.1, 0.9);
        }
        //Generates the next x for the dataset. The logistic map generates a chaotic but still related
        //dataset for with a critical point at r = ~3.54.
        //Equation: X_{n+1} = rX_n(1 - X_n)
        public double nextPoint()
        {
            double next = r * x * (1 - x);
            x = next;
            return next;
        }
    }
}
