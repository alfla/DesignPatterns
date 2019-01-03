using Stateless;
using System;
using static System.Console;

namespace StateMachineWithStateless
{
    public enum Health
    {
        NomReproductive,
        Pregnant,
        Reproductive
    }

    public enum Activity
    {
        GrowOlder,
        GiveBirth,
        ReachPuberty,
        HaveAbortion,
        HaveUnprotectedSex,
        Historectomy
    }

    class Program
    {
        public static bool ParentNotWatching { get; private set; }

        static void Main(string[] args)
        {
            var stateMachine = new StateMachine<Health, Activity>(Health.NomReproductive);

            stateMachine .Configure(Health.NomReproductive)
                    .Permit(Activity.ReachPuberty, Health.Reproductive);

            stateMachine.Configure(Health.Reproductive)
                    .Permit(Activity.Historectomy, Health.NomReproductive)
                    .PermitIf(Activity.HaveUnprotectedSex, Health.Pregnant, () => ParentNotWatching);

            stateMachine.Configure(Health.Pregnant)
                    .Permit(Activity.GiveBirth, Health.Reproductive)
                    .Permit(Activity.HaveAbortion, Health.Reproductive);


            WriteLine("Hello World!");
        }
    }
}
