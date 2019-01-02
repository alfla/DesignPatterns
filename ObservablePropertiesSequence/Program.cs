using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using static System.Console;

namespace ObservablePropertiesSequence
{
    public class Market
    {
        private List<float> prices = new List<float>();

        public void AddPrice(float price)
        {
            prices.Add(price);
            PriceAdded?.Invoke(this, price);
        }

        public event EventHandler<float> PriceAdded;
    }

    class Program
    {
        static void Main(string[] args)
        {
            var market = new Market();
            market.PriceAdded += (sender, f) =>
            {
                WriteLine($"We got a price of {f}");
            };

            market.AddPrice(123);
            ReadKey();
        }
    }
}
