using System;
using static System.Console;


namespace MonostatePattern
{
    public class CEO
    {
        private static string name;
        private static int age;

        public string Name
        {
            get => name;
            set => name = value;
        }
        public int Age
        {
            get => age;
            set => age = value;
        }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Age)}: {Age}";
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            var ceo = new CEO() { Name = "Lucho", Age = 35 };
            WriteLine(ceo.ToString());
            var ceo2 = new CEO();
            WriteLine(ceo2.ToString());
            ceo2.Age = 25;
            ceo2.Name = "Luis";
            WriteLine(ceo.ToString());
            WriteLine(ceo2.ToString());
            ReadKey();
        }
    }
}
