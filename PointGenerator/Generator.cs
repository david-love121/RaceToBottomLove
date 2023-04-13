using DecisionTree;
using DongUtility;
using System;
using System.Drawing;

namespace PointGenerator
{
    abstract public class Generator
    {
        static public Random Random { get; } = new();

        abstract protected Point CreatePoint(bool signal);

        private const double positionJitter = .01;
        private const double colorJitter = 1;

        public Point MakePoint(bool signal)
        {
            var point = CreatePoint(signal);

            // Add jitter
            double x = Random.NextGaussian(point.Position.X, positionJitter);
            double y = Random.NextGaussian(point.Position.Y, positionJitter);
            double z = Random.NextGaussian(point.Position.Z, positionJitter);

            byte r = ColorJitter(point.Color.R);
            byte g = ColorJitter(point.Color.G);
            byte b = ColorJitter(point.Color.B);

            Vector newPosition = new Vector(x, y, z);
            Color newColor = Color.FromArgb(r, g, b);

            return new Point(newPosition, newColor);
        }

        static public string[] Names { get; } = new string[6] { "X position", "Y position", "Z position", "Red", "Green", "Blue" };


        public DataSet MakeDataSet(int nEntries, double signalFraction)
        {
            if (signalFraction < 0 || signalFraction > 1)
                throw new ArgumentException("Invalid signal fraction!");

                       var ds = new DataSet(Names);

            for (int i = 0; i < nEntries; ++i)
            {
                bool isSignal = Random.NextBool(signalFraction);
                var point = CreatePoint(isSignal);
                ds.AddDataPoint(point.ConvertToDataPoint());
            }

            return ds;
        }

        private static byte ColorJitter(byte input)
        {
            double jittered = Random.NextGaussian(input, colorJitter);
            int rounded = (int)(Math.Round(jittered, 0));
            int clamped = Math.Clamp(rounded, 0, 255);
            return (byte)clamped;
        }
    }
}
