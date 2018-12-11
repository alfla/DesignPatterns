using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace ArrayBackend
{
    public class Creature : IEnumerable<int>
    {
        private int[] stats = new int[3];


        private const int strenght = 0;
        private const int agility = 1;
        private const int intelligence = 2;

        public int Strength
        {
            get => stats[strenght];
            set => stats[strenght] = value;
        }

        public int Agility
        {
            get => stats[agility];
            set => stats[agility] = value;
        }

        public int Intelligence
        {
            get => stats[intelligence];
            set => stats[intelligence] = value;
        }

        public double AverageStat =>
            stats.Average();

        public IEnumerator GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator<int> IEnumerable<int>.GetEnumerator()
        {
            return stats.AsEnumerable().GetEnumerator();
        }

        public int this[int index]
        {
            get { return stats[index];}
            set { stats[index] = value; }
        }
        //public int Strength { get; set; }
        //public int Agility { get; set; }
        //public int Intelligence { get; set; }

        //public double AverageStat
        //{
        //    get { return (Strength + Agility + Intelligence) / 3.0; }
        //}

    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
