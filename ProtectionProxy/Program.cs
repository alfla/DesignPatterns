using System;
using static System.Console;


namespace ProtectionProxy
{
    public interface ICar
    {
        void Drive();
    }
    public class Driver
    {
        public Driver(int age)
        {
            Age = age;
        }

        public int Age { get; set; }
    }

    public class Car:ICar
    {
        public void Drive()
        {
            WriteLine("Car is being driven");
        }
    }

    public class CarProxy : ICar
    {
        private Driver driver;
        private Car car = new Car();

        public CarProxy(Driver driver)
        {
            this.driver = driver;
        }

        public void Drive()
        {
            if (driver.Age > 16)
                car.Drive();
            else
                WriteLine("Too Young");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ICar car = new CarProxy(new Driver(22));
            car.Drive();
            ReadKey();
            //Console.WriteLine("Hello World!");
        }
    }
}
