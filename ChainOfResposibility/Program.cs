using System;
using static System.Console;


namespace ChainOfResposibility
{
    public class Creature
    {
        public string Name;
        public int Attack, Defense;

        public Creature(string name, int attack, int defense)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Attack = attack;
            Defense = defense;
        }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Attack)}: {Attack}, {nameof(Defense)}: {Defense}";
        }
    }

    public class CreatureModifier
    {
        protected Creature creature;
        protected CreatureModifier next; // linked list

        public CreatureModifier(Creature creature)
        {
            this.creature = creature ?? throw new ArgumentNullException(nameof(creature));
        }

        public void Add(CreatureModifier cm)
        {
            if (next != null) next.Add(cm);
            else next = cm;
        }

        public virtual void Handle() => next?.Handle();
    }

    public class DoubleAttackModfier : CreatureModifier
    {
        public DoubleAttackModfier(Creature creature) : base(creature)
        {
        }

        public override void Handle()
        {
            WriteLine($"Doubling {creature.Name}'s attack");
            creature.Attack *= 2;
            base.Handle();
        }
    }

    public class IncreasedDefeseModifier : CreatureModifier
    {
        public IncreasedDefeseModifier(Creature creature) : base(creature)
        {
        }

        public override void Handle()
        {
            WriteLine($"Increasing {creature.Name}'s defense");
            creature.Defense *= 4;
            base.Handle();
        }
    }

    public class NoBonusesModifier : CreatureModifier
    {
        public NoBonusesModifier(Creature creature) : base(creature)
        {
        }

        public override void Handle()
        {
            //
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var goblin = new Creature("Goblin", 2, 2);
            WriteLine(goblin);
            var root = new CreatureModifier(goblin);
            root.Add(new NoBonusesModifier(goblin));
            WriteLine("Let's double the goblin's attack");
            root.Add(new DoubleAttackModfier(goblin));
            WriteLine("Let's increase the goblin's defense");
            root.Add(new IncreasedDefeseModifier(goblin));
            root.Handle();
            WriteLine(goblin);
            ReadKey();
        }
    }
}
