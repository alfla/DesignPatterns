﻿using System;
using System.Text;
using static System.Console;

namespace IntrusiveExpressionPrinting
{
    public abstract class Expression
    {
        public abstract void Print(StringBuilder sb);
    }

    public class DoubleExpression : Expression
    {
        private Double value;

        public DoubleExpression(double value)
        {
            this.value = value;
        }

        public override void Print(StringBuilder sb)
        {
            sb.Append(value);
        }
    }

    public class AdditionExpression : Expression
    {
        private Expression left, right;

        public AdditionExpression(Expression left, Expression right)
        {
            this.left = left ?? throw new ArgumentNullException(paramName: nameof(left));
            this.right = right ?? throw new ArgumentNullException(paramName: nameof(right));
        }

        public override void Print(StringBuilder sb)
        {
            sb.Append("(");
            left.Print(sb);
            sb.Append("+");
            right.Print(sb);
            sb.Append(")");
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
            e.Print(sb);
            WriteLine(sb);
            ReadKey();
            WriteLine("Hello World!");
        }
    }
}
