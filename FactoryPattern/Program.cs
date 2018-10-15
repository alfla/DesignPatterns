using System;

namespace FactoryPattern
{
    public static class PointFactory
    {
        public static Point NewCartesianPoint(double x, double y)
        {
            return new Point(x, y);
        }
        public static Point NewPolarPoint(double rho, double theta)
        {
            return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
        }

    }

    public class Point
    {
        public enum CoordinateSystem
        {
            Cartesian,
            Polar
        }
        private double x, y;
        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }


        public override string ToString()
        {
            return $"{nameof(x)}: {x}, {nameof(y)}: {y}";
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Point pointCartesian = PointFactory.NewCartesianPoint(1.0, Math.PI /2);
            Point pointPolar = PointFactory.NewPolarPoint(1.0, Math.PI / 2);

            Console.WriteLine($"{nameof(pointCartesian)}: {pointCartesian}");
            Console.WriteLine($"{nameof(pointPolar)}: {pointPolar}");
            Console.WriteLine(pointCartesian);



            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
