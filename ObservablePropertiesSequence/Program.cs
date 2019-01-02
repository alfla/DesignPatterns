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
        public BindingList<float> Prices = new BindingList<float>();

        public void AddPrice(float price)
        {
            Prices.Add(price);
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            var market = new Market();
            market.Prices.ListChanged += (sender, eventArgs) =>
            {
                if (eventArgs.ListChangedType == ListChangedType.ItemAdded)
                {
                    float price = ((BindingList<float>)sender)[eventArgs.NewIndex];
                    WriteLine($"Binding list got a price of {price}");
                }
            };
            market.AddPrice(123);
            ReadKey();
        }
    }
}
