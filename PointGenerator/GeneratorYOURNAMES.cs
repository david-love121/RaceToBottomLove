using DongUtility;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointGenerator
{
    public class GeneratorYOURNAMES : Generator
    {
        protected override Point CreatePoint(bool signal)
        {
            if (signal)
            {
                double x = Random.NextDouble(0, 100);
                double y = Random.NextDouble(0, 100);
                double z = Random.NextDouble(0, 100);
                int r = Random.Next(0, 128);
                int g = Random.Next(0, 128);
                int b = Random.Next(0, 128);

                var position = new Vector(x, y, z);
                var color = Color.FromArgb(r, g, b);
                return new Point(position, color);
            }
            else
            {
                double x = Random.NextDouble(0, 100);
                double y = Random.NextDouble(0, 100);
                double z = Random.NextDouble(0, 100);
                int r = Random.Next(128, 256);
                int g = Random.Next(128, 256);
                int b = Random.Next(128, 256);

                var position = new Vector(x, y, z);
                var color = Color.FromArgb(r, g, b);
                return new Point(position, color);
            }
        }
    }
}
