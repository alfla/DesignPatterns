using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace ReflectionDynamicPrintingDictType
{
    using DictType = Dictionary<Type, Action<Expression, StringBuilder>>;

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
        private static DictType actions = new DictType
        {
            [typeof(DoubleExpression)] = (e, sb) =>
            {
                var de = (DoubleExpression)e;
                sb.Append(de.value);
            },
            [typeof(AdditionExpression)] = (e, sb) =>
            {
                var ae = (AdditionExpression)e;
                sb.Append("(");
                Print(ae.left, sb);
                sb.Append("+");
                Print(ae.right, sb);
                sb.Append(")");
            }
        };

        public static void Print(Expression e, StringBuilder sb)
        {
            actions[e.GetType()](e, sb);
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
