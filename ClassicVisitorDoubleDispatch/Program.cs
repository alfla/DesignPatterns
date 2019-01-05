using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace ClassicVisitorDoubleDispatch
{
    public interface IExpressionVisitor
    {
        void Visit(DoubleExpression de);
        void Visit(AdditionExpression ae);
    }

    public abstract class Expression
    {
        public abstract void Accept(IExpressionVisitor visitor);
    }

    public class DoubleExpression : Expression
    {
        internal Double value;

        public DoubleExpression(double value)
        {
            this.value = value;
        }

        public override void Accept(IExpressionVisitor visitor)
        {
            visitor.Visit(this);
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

        public override void Accept(IExpressionVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class ExpressionPrinter : IExpressionVisitor
    {
        private StringBuilder sb = new StringBuilder();


        public void Visit(DoubleExpression de)
        {
            sb.Append(de.value);
        }

        public void Visit(AdditionExpression ae)
        {
            sb.Append("(");
            ae.Left.Accept(this);
            sb.Append("+");
            ae.Right.Accept(this);
            sb.Append(")");
        }
        public override string ToString()
        {
            return sb.ToString();
        }
    }

    public class ExpressionCalculator : IExpressionVisitor
    {
        public double result;



        public void Visit(DoubleExpression de)
        {
            result = de.value;
        }

        public void Visit(AdditionExpression ae)
        {
            ae.Left.Accept(this);
            var a = result;
            ae.Right.Accept(this);
            var b = result;
            result = a + b;

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
            var calc = new ExpressionCalculator();

            calc.Visit(e);
            ep.Visit(e);


            WriteLine(ep);
            WriteLine($"{ep} = {calc.result}");

            ReadKey();
            WriteLine("Hello World!");
        }
    }
}
