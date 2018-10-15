using System;

namespace FactoryPattern
{

    public class Point
    {
        private double x, y;
        private Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public static Point Origin = new Point(0, 0);
        public static Point Origin2 => new Point(0,0);
        public override string ToString()
        {
            return $"{nameof(x)}: {x}, {nameof(y)}: {y}";
        }

        public static class Factory
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

    }

    class Program
    {
        static void Main(string[] args)
        {
            Point pointCartesian = Point.Factory.NewCartesianPoint(1.0, Math.PI /2);
            Point pointPolar = Point.Factory.NewPolarPoint(1.0, Math.PI / 2);

            Console.WriteLine($"{nameof(pointCartesian)}: {pointCartesian}");
            Console.WriteLine($"{nameof(pointPolar)}: {pointPolar}");
            Console.WriteLine(pointCartesian);


            var origin = Point.Origin;
            Console.WriteLine($"{nameof(origin)}: {origin}");
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
