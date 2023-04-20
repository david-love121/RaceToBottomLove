using DongUtility;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointGenerator
{
    public class GeneratorLove : Generator
    {
        private double rSignal;
        private double rBackground;
        LogisticMap signalMap;
        LogisticMap backgroundMap;
        public GeneratorLove()
        {
            while (Math.Abs(rSignal - rBackground) < 0.1)
            {
                rSignal = Random.NextDouble(3.57, 4);
                rBackground = Random.NextDouble(3.57, 4);
            }
            signalMap = new LogisticMap(rSignal, Random);
            backgroundMap = new LogisticMap(rBackground, Random);
        }
        protected override Point CreatePoint(bool signal)
        {
            if (signal)
            {
                double x = signalMap.nextPoint() * 100;
                double y = signalMap.nextPoint() * 100;
                double z = signalMap.nextPoint() * 100;
                int r = (int)(signalMap.nextPoint() * 255);
                int g = (int)(signalMap.nextPoint() * 255);
                int b = (int)(signalMap.nextPoint() * 255);

                var position = new Vector(x, y, z);
                var color = Color.FromArgb(r, g, b);
                return new Point(position, color);
            }
            else
            {
                double x = backgroundMap.nextPoint() * 100;
                double y = backgroundMap.nextPoint() * 100;
                double z = backgroundMap.nextPoint() * 100;
                int r = (int)(backgroundMap.nextPoint() * 255);
                int g = (int)(backgroundMap.nextPoint() * 255);
                int b = (int)(backgroundMap.nextPoint() * 255);

                var position = new Vector(x, y, z);
                var color = Color.FromArgb(r, g, b);
                return new Point(position, color);
            }
        }
       
    }
}
