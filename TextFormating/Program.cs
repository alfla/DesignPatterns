using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using static System.Console;

namespace TextFormating
{
    public class FormattedText
    {
        private readonly string plainText;
        private bool[] capitalize;

        public FormattedText(string plainText)
        {
            this.plainText = plainText ?? throw new ArgumentNullException(paramName: nameof(plainText));
            capitalize = new bool[plainText.Length];
        }

        public void Capitalize(int start, int end)
        {
            for (int i = start; i < end; i++)
            {
                capitalize[i] = true;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < plainText.Length; i++)
            {
                var c = plainText[i];
                sb.Append(capitalize[i] ? char.ToUpper(c) : c);
            }
            return sb.ToString();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var ft = new FormattedText("This is a brave new world");
            ft.Capitalize(10, 15);
            WriteLine(ft.ToString());
            WriteLine("Hello World!");
            ReadKey();
        }
    }
}
