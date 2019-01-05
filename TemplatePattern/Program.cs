using System;
using static System.Console;

namespace TemplatePattern
{
    public abstract class Game
    {
        public void Run()
        {
            Start();
            while (!HaveWinner)
            {
                TakeTurn();
            }
            WriteLine($"Player {WinningPlayer} wins");
        }

        protected int currentPlayer;
        protected readonly int numberOfPlayers;

        protected Game(int numberOfPlayers)
        {
            this.numberOfPlayers = numberOfPlayers;
        }

        protected abstract void Start();
        protected abstract void TakeTurn();
        protected abstract bool HaveWinner { get; }
        protected abstract int WinningPlayer { get; }
    }


    public class Chess : Game
    {
        public Chess() : base(2)
        {

        }

        protected override bool HaveWinner => turn == maxTurn;

        protected override int WinningPlayer => currentPlayer;

        protected override void Start()
        {
            WriteLine($"Starting a game of chess with {numberOfPlayers} playes.");

        }

        protected override void TakeTurn()
        {
            WriteLine($"Turn {turn++} taken by player {currentPlayer}.");
            currentPlayer = (currentPlayer + 1) % numberOfPlayers;
        }

        private int turn = 1;
        private int maxTurn = 10;
    }

    class Program
    {
        static void Main(string[] args)
        {
            var chess = new Chess();
            chess.Run();
            ReadKey();
            WriteLine("Hello World!");
        }
    }
}
