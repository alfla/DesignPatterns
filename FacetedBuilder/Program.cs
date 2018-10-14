using System;
using static System.Console;

namespace FacetedBuilder
{
    public class Person
    {
        // address
        public string StreedAddress, Postcode, City;

        //employment
        public string CompanyName, Position;
        public int AnnualIncome;

        public override string ToString()
        {
            return $"{nameof(StreedAddress)}: {StreedAddress}, {nameof(Postcode)}: {Postcode}, {nameof(City)}: {City}, {nameof(CompanyName)}: {CompanyName}, {nameof(Position)}: {Position}, {nameof(AnnualIncome)}: {AnnualIncome}.";
        }
    }

    public class PersonBuilder //Facade
    {
        protected Person person = new Person();

        public PersonJobBuilder Worsks => new PersonJobBuilder(person);
        public PersonAddressBuilder Lives => new PersonAddressBuilder(person);
        public static implicit operator Person(PersonBuilder pd)
        {
            return pd.person;
        }
    }

    public class PersonAddressBuilder : PersonBuilder
    {
        public PersonAddressBuilder(Person person)
        {
            this.person = person;
        }

        public PersonAddressBuilder At(string streetAddress)
        {
            this.person.StreedAddress = streetAddress;
            return this;
        }
        public PersonAddressBuilder WithPostcode(string postcode)
        {
            this.person.Postcode = postcode;
            return this;
        }
        public PersonAddressBuilder In(string city)
        {
            this.person.City = city;
            return this;
        }
    }

    public class PersonJobBuilder : PersonBuilder
    {
        public PersonJobBuilder(Person person)
        {
            this.person = person;
        }

        public PersonJobBuilder At(string companyName)
        {
            person.CompanyName = companyName;
            return this;
        }
        public PersonJobBuilder AsA(string position)
        {
            person.Position= position;
            return this;
        }
        public PersonJobBuilder Earning(int amount)
        {
            person.AnnualIncome = amount;
            return this;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var pb = new PersonBuilder();
            Person person = pb
                .Lives.At("AlwaysLive")
                      .In("Springfield")
                      .WithPostcode("1542")
                .Worsks.At("Home")
                       .AsA("Son")
                       .Earning(100);
            WriteLine(person);
            WriteLine("Hello World!");
            ReadKey();
        }
    }
}
