using Autofac;
using ImpromptuInterface;
using System;
using System.Dynamic;
using static System.Console;


namespace Null_Object_Pattern
{
    public interface ILog
    {
        void Info(string msg);
        void Warn(string msg);
    }

    public class Null<TInterface> : DynamicObject where TInterface : class
    {
        public static TInterface Instance =>
            new Null<TInterface>().ActLike<TInterface>();

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            result = Activator.CreateInstance(binder.ReturnType);
            return true;
        }
    }

    public class ConsoleLog : ILog
    {
        public void Info(string msg)
        {
            WriteLine(msg);
        }

        public void Warn(string msg)
        {
            WriteLine("WARNING!!! " + msg);
        }
    }
    public class BankAccount
    {
        private ILog log;
        public int balance;

        public BankAccount(ILog log)
        {
            this.log = log ?? throw new ArgumentNullException(paramName: nameof(log));
        }

        public void Deposit(int amount)
        {
            balance += amount;
            log.Info($"Deposited {amount}, balance is now {balance}");
        }
    }
    public class NullLog : ILog
    {
        public void Info(string msg)
        {
        }

        public void Warn(string msg)
        {
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            /*   var log = new ConsoleLog();
               var ba = new BankAccount(null);
               ba.Deposit(100);

               ReadKey();
               WriteLine();*/

            /*            var cb = new ContainerBuilder();
                        cb.RegisterType<BankAccount>();
                        cb.RegisterType<NullLog>().As<ILog>();

                        using (var c = cb.Build())
                        {
                            var ba = c.Resolve<BankAccount>();
                            ba.Deposit(100);
                        }
                        */

            var log = Null<ILog>.Instance;
            log.Info("asdfgha");
            var ba = new BankAccount(log);
            ba.Deposit(100);

            ReadKey();

        }
    }
}
