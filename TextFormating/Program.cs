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

    public class BetterFormattedText
    {
        private readonly string plainText;
        private List<TextRange> formating = new List<TextRange>();

        public BetterFormattedText(string plainText)
        {
            this.plainText = plainText ?? throw new ArgumentNullException(nameof(plainText));
        }
        public TextRange GetRange(int start, int end)
        {
            var range = new TextRange { Start = start, End = end };
            formating.Add(range);
            return range;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < plainText.Length; i++)
            {
                var c = plainText[i];
                foreach (var range in formating)
                {
                    if (range.Covers(i) && range.Capitalize)
                        c = char.ToUpper(c);
                }    
                sb.Append(c);
            }
            return sb.ToString();
        }

        public class TextRange
        {
            public int Start, End;
            public bool Capitalize, Bold, Italic;


            public bool Covers(int position)
            {
                return position >= Start && position <= End;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var ft = new FormattedText("This is a brave new world");
            ft.Capitalize(10, 15);
            WriteLine(ft.ToString());


            var bft = new BetterFormattedText("This is a brave new world");
            bft.GetRange(10, 15).Capitalize = true;
            WriteLine(bft.ToString());
            WriteLine("Hello World!");
            ReadKey();
        }
    }
}
