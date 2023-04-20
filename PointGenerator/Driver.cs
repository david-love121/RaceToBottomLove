using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointGenerator
{
    internal class Driver
    {
        static void Main(string[] args)
        {
            var generator = new GeneratorLove();

            const int nPoints = 10;

            List<Point> signal = new();
            List<Point> background = new();

            for (int i = 0; i < nPoints; ++i)
            {
                var signalPoint = generator.MakePoint(true);
                var backgroundPoint = generator.MakePoint(false);
                signal.Add(signalPoint);
                background.Add(backgroundPoint);
            }
        }
    }
}
