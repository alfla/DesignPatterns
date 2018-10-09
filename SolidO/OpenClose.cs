using System;
using System.Collections.Generic;
using static System.Console;
namespace SolidO
{
    public enum Color
    {
        Red, Green, Blue
    }

    public enum Size
    {
        Small, Mediumn, Large, Yuge 
    }

    public class Product
    {
        public string Name;
        public Size Size;
        public Color Color;

        public Product(string name, Size size, Color color)
        {
            if (name == null)
            {
                throw new ArgumentNullException(paramName: nameof(name));
            }
            Name = name;
            this.Size = size;
            this.Color = color;
        }
    }

    public class ProductFilter
    {
        public IEnumerable<Product> FilterBySize(IEnumerable<Product> products, Size size)
        {
            foreach (var p in products)
            {
                if (p.Size == size)
                    yield return p;
            }
        }

        public IEnumerable<Product> FilterByColor(IEnumerable<Product> products, Color color)
        {
            foreach (var p in products)
            {
                if (p.Color == color)
                    yield return p;
            }
        }
    }

    public interface ISpecification<T>
    {
        bool IsSatisfied(T t);
    }

    public interface IFilter<T> 
    {
        IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> specification);
    }

    public class ColorSpecification : ISpecification<Product>
    {
        private Color color;
        public ColorSpecification(Color color)
        {
            this.color = color;
        }

        public bool IsSatisfied(Product t)
        {
            return t.Color == color;
        }
    }

    public class SizeSpecification : ISpecification<Product>
    {
        private Size Size;
        public SizeSpecification(Size size)
        {
            this.Size = size;
        }

        public bool IsSatisfied(Product t)
        {
            return t.Size == Size;
        }
    }


    public class BetterFilter : IFilter<Product>
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> specification)
        {
            foreach (var item in items)
                if (specification.IsSatisfied(item))
                    yield return item;
        }
    }

    public class AndSpecification<T> : ISpecification<T>
    {
        private ISpecification<T> first, second;
        public AndSpecification(ISpecification<T> first, ISpecification<T> second)
        {
            this.first = first ?? throw new ArgumentNullException(paramName: nameof(first));
            this.second = second ?? throw new ArgumentNullException(paramName: nameof(second));
        }

        public bool IsSatisfied(T t)
        {
            return first.IsSatisfied(t) && second.IsSatisfied(t);
        }
    }
    class OpenClose
    {
        static void Main(string[] args)
        {
            var apple = new Product("Apple", Size.Small, Color.Green);
            var tree = new Product("Tree", Size.Large, Color.Green);
            var house = new Product("House", Size.Large, Color.Blue);

            Product[] products = { apple, tree, house };

            var pf = new ProductFilter();
            WriteLine("Green Products (old):");
            foreach (var p in pf.FilterByColor(products, Color.Green))
            {
                WriteLine($"- {p.Name} is green.");
            }

            var bf = new BetterFilter();
            WriteLine("Green Products (new):");
            foreach (var p in bf.Filter(products, new ColorSpecification(Color.Green)))
            {
                WriteLine($"- {p.Name} is green.");
            }

            WriteLine("Large blue items:");
            foreach (var p in bf.Filter(products, new AndSpecification<Product>(new ColorSpecification(Color.Blue), 
                                                                                new SizeSpecification(Size.Large))))
            {
                WriteLine($"- {p.Name} is big and blue.");
            }

            ReadKey();
        }
    }
}
