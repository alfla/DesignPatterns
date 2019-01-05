using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
namespace ReflectionBasePrinting
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
        public Expression left, right;

        public AdditionExpression(Expression left, Expression right)
        {
            this.left = left ?? throw new ArgumentNullException(paramName: nameof(left));
            this.right = right ?? throw new ArgumentNullException(paramName: nameof(right));
        }
    }

    public static class ExpressionPrinter
    {

        public static void Print(Expression e, StringBuilder sb)
        {
            if (e is DoubleExpression de)
            {
                sb.Append(de.value);
            }
            else if (e is AdditionExpression ae)
            {
                sb.Append("(");
                Print(ae.left, sb);
                sb.Append("+");
                Print(ae.right, sb);
                sb.Append(")");
            }
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
            ExpressionPrinter.Print(e, sb);
            WriteLine(sb);
            ReadKey();
            WriteLine("Hello World!");
        }
    }
}
