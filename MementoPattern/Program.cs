using static System.Console;

namespace MementoPattern
{
    public class Memento
    {
        public int Balance { get; }

        public Memento(int balance)
        {
            Balance = balance;
        }

    }
    public class BanckAccount
    {
        private int balance;
        public BanckAccount(int balance)
        {
            this.balance = balance;
        }

        public Memento Deposit(int amount)
        {
            balance += amount;
            return new Memento(balance);
        }

        public void Restore(Memento m)
        {
            balance = m.Balance;
        }

        public override string ToString()
        {
            return $"{nameof(balance)}: {balance}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var ba = new BanckAccount(100);
            var m1 = ba.Deposit(50);//150
            var m2 = ba.Deposit(25);//175

            WriteLine(ba);

            ba.Restore(m1);
            WriteLine(ba);
            ba.Restore(m2);
            WriteLine(ba);


            WriteLine("Hello World!");
            ReadKey();
        }
    }
}
