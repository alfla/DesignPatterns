using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;


namespace DynamicVisitorViaDLR
{

    public abstract class Expression
    {
    }

    public class DoubleExpression : Expression
    {
        internal Double value;

        public DoubleExpression(double value)
        {
            this.value = value;
        }


    }

    public class AdditionExpression : Expression
    {
        public Expression Left, Right;

        public AdditionExpression(Expression left, Expression right)
        {
            this.Left = left ?? throw new ArgumentNullException(paramName: nameof(left));
            this.Right = right ?? throw new ArgumentNullException(paramName: nameof(right));
        }

    }

    public class ExpressionPrinter
    {
        public void Print(AdditionExpression ae, StringBuilder sb)
        {
            sb.Append("(");
            Print((dynamic)ae.Left, sb);
            sb.Append("+");
            Print((dynamic)ae.Right, sb);
            sb.Append(")");
        }

        public void Print(DoubleExpression de, StringBuilder sb)
        {
            sb.Append(de.value);
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            var e = new AdditionExpression(
                new DoubleExpression(1),
                new AdditionExpression(
                    new DoubleExpression(2),
                    new DoubleExpression(3)
                    ));
            var sb = new StringBuilder();
            var ep = new ExpressionPrinter();

            ep.Print((dynamic)e,sb);


            WriteLine(sb.ToString());

            ReadKey();
            WriteLine("Hello World!");
        }
    }
}
