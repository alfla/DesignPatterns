using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace IntrusiveExpressionPrinting
{
    using DictType = Dictionary<Type, Action<Expression, StringBuilder>>;

    public abstract class Expression
    {
        //public abstract void Print(StringBuilder sb);
    }

    public class DoubleExpression : Expression
    {
        internal Double value;

        public DoubleExpression(double value)
        {
            this.value = value;
        }

        //public override void Print(StringBuilder sb)
        //{
        //    sb.Append(value);
        //}
    }

    public class AdditionExpression : Expression
    {
        public Expression left, right;

        public AdditionExpression(Expression left, Expression right)
        {
            this.left = left ?? throw new ArgumentNullException(paramName: nameof(left));
            this.right = right ?? throw new ArgumentNullException(paramName: nameof(right));
        }

        //public override void Print(StringBuilder sb)
        //{
        //    sb.Append("(");
        //    left.Print(sb);
        //    sb.Append("+");
        //    right.Print(sb);
        //    sb.Append(")");
        //}
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

        //public static void Print(Expression e, StringBuilder sb)
        //{
        //if (e is DoubleExpression de)
        //{
        //    sb.Append(de.value);
        //}
        //else if (e is AdditionExpression ae)
        //{
        //    sb.Append("(");
        //    Print(ae.left, sb);
        //    sb.Append("+");
        //    Print(ae.right, sb);
        //    sb.Append(")");
        //}

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
            //        e.Print(sb);
            ExpressionPrinter.Print(e, sb);
            WriteLine(sb);
            ReadKey();
            WriteLine("Hello World!");
        }
    }
}
