using System;
using System.Collections.Generic;
using static System.Console;
namespace PropertyProxy
{
    public class Property<T> : IEquatable<Property<T>> where T : new() 
    {
        private T value;

        public Property(): this(default(T))
        {
        }

        public Property(T value)
        {
            this.value = value;
        }

        public T Value {
            get => value;
            set
            {
                if (Equals(this.value, value)) return;
                WriteLine($"Assigning value to {value}");
                this.value = value;
            }
        }

        public override bool Equals(object obj)
         {
            return Equals(obj as Property<T>);
        }

        public bool Equals(Property<T> other)
        {
            return other != null &&
                   EqualityComparer<T>.Default.Equals(value, other.value) &&
                   EqualityComparer<T>.Default.Equals(Value, other.Value);
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }

        public static bool operator ==(Property<T> property1, Property<T> property2)
        {
            return EqualityComparer<Property<T>>.Default.Equals(property1, property2);
        }

        public static bool operator !=(Property<T> property1, Property<T> property2)
        {
            return !(property1 == property2);
        }

        public static implicit operator T(Property<T> property)
        {
            return property.value; // int n  = p_ int:
        }

        public static implicit operator Property<T>(T value)
        {
            return new Property<T>(value); // Property<int> p = 123;
        }

    }

    public class Creature
    {
        private Property<int> agility = new Property<int>();

        public int Agility { get => agility.Value; set => agility.Value = value; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var c = new Creature();
            c.Agility = 10;
            c.Agility = 10;

            ReadKey();
        }
    }
}
