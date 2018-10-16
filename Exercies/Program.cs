using System;

namespace Exercies
{
    public class PersonFactory
    {
        private static int Id = 0;
        public Person CreatePerson(string name)
        {
            Person person = new Person { Id = Id++, Name = name};
            return person;
        }
    }

    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            PersonFactory factory = new PersonFactory();
            Console.WriteLine(factory.CreatePerson("Luchooo"));
            Console.WriteLine(factory.CreatePerson("Geooo"));
            Console.WriteLine(factory.CreatePerson("Mabeliss"));

            Console.ReadKey();
            Console.WriteLine("Hello World!");
        }
    }
}
