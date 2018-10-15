using System;

namespace FactoryPattern
{
    public class Point
    {
        public enum CoordinateSystem
        {
            Cartesian,
            Polar
        }

        private double x, y;

        protected Point(double a, double b,
            CoordinateSystem system = CoordinateSystem.Cartesian)
        {
            switch (system)
            {
                case CoordinateSystem.Cartesian:
                    this.x = a;
                    this.y = b;
                    break;
                case CoordinateSystem.Polar:
                    this.x = a * Math.Cos(this.y);
                    this.y = a * Math.Cos(this.y);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(system), system, null);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
