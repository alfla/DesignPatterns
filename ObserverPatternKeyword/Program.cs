using System;
using static System.Console;


namespace ObserverPatternKeyword
{
    public class FallsIllEventArgs
    {
        public string Address;
    }

    public class Person
    {
        public void CathcACold()
        {
            FallsIll?.Invoke(this, new FallsIllEventArgs { Address = "123 London Road" });
        }

        public event EventHandler<FallsIllEventArgs> FallsIll;
    }

    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person();
            person.FallsIll += CallDoctor;
            person.CathcACold();
            //person.FallsIll -= CallDoctor;

            ReadKey();
        }

        private static void CallDoctor(object sender, FallsIllEventArgs e)
        {
            WriteLine($"A doctor has been called to {e.Address}");
        }
    }
}
