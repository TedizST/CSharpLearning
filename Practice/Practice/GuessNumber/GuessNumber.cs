using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Practice.GuessNumber
{
    public class GameGuess
    {
        public int Number { get; private set; }
        public readonly Mode Mode;
        public readonly int range;
        public readonly Difficulty Difficulty;
        private byte _attempts;
        private int _guess;

        public GameGuess(Mode mode, Difficulty difficulty = Difficulty.Normal, Range range = Range.to_100)
        {
            this.Mode = mode;
            this.Difficulty = difficulty;
            this.range = (int)range;

            StartGame();
        }

        public void StartGame()
        {
            this.Number = default;
            this._attempts = (byte)Difficulty;

            switch (this.Mode)
            {
                case Mode.PlayerVSComputer:
                    ComputerMakesGuess();
                    break;
                case Mode.ComputerVSPlayer:
                    PlayerMakesGuess();
                    break;
            }
        }

        private void ComputerMakesGuess()
        {
            Random rand = new Random();
            this.Number = rand.Next(this.range);

            Console.WriteLine($"The number is guessed! Range is [0, {this.range}]");

            PlayerGuesses();
        }

        private void PlayerGuesses()
        {
            while (this._attempts > 0)
            {
                Console.Write("Make a guess: ");

                if (!IsValid(out int item))
                {
                    Console.WriteLine("Invalid number!\nTry again!");
                    continue;
                }

                this._guess = item;

                if (this._guess == this.Number)
                {
                    Console.WriteLine("You won! Congratulations!");
                    Restart();
                    break;
                }
                else if (this._guess > this.Number)
                {
                    Console.WriteLine($"Wrong! My number is more than {this._guess}.\nAttempts left: {--this._attempts}");
                }
                else
                {
                    Console.WriteLine($"Wrong! My number is less than {this._guess}.\nAttempts left: {--this._attempts}");
                }
            }

            if (_attempts == 0)
            {
                Console.WriteLine("There are no attempts left! You lost!");
                Restart();
            }
        }

        private void PlayerMakesGuess()
        {
            while (true)
            {
                Console.Write($"Enter your number from 0 to {this.range}: ");

                if (IsValid(out int item))
                {
                    this.Number = item;
                    ComputerGuesses();
                    break;                    
                }
                else
                {
                    Console.WriteLine("Invalid number!\nTry again!");
                }
            }


        }

        private void ComputerGuesses()
        {
            int left = 0;
            int right = this.range;
            Random rand = new Random();
            string[] answerToPlayer = new string[] { "Hehe, it's not right...",
                                                    "Wrong! You are almost win..." };
            string[] computerLost = new string[] { "When the machines rise up, I won't lose again!",
                                                    "Next time everything will be different!" };

            while (this._attempts > 0)
            {
                this._guess = (left + right) / 2;

                Console.WriteLine($"My guess is {this._guess}");

                if (this._guess == this.Number)
                {
                    Console.WriteLine("Ah, it's right. You lost!");
                    Restart();
                    break;
                }
                else if (this._guess > this.Number)
                {
                    Console.Write(answerToPlayer[rand.Next(1)]);
                    Console.WriteLine($" Attempts left: {--this._attempts}");

                    right = this._guess;
                }
                else
                {
                    Console.Write(answerToPlayer[rand.Next(1)]);
                    Console.WriteLine($" Attempts left: {--this._attempts}");

                    left = this._guess;
                }
            }

            if (this._attempts == 0)
            {
                Console.WriteLine(computerLost[rand.Next(1)]);
                Restart();
            }
        }

        private void Restart()
        {
            while (true)
            {
                Console.Write("Wanna try again?\nyes/no: ");
                string answer = Console.ReadLine();

                if (answer == "yes")
                {
                    StartGame();
                    break;
                }
                else if (answer == "no")
                {
                    break;
                }
            }
        }

        private bool IsValid(out int item)
        {
            item = default;

            try
            {
                item = int.Parse(Console.ReadLine());
            }
            catch
            {
                return false;
            }

            if (item >= 0 && item <= this.range)
            {
                return true;
            }
            else
            {
                return false;
            }
        }        
    }
}
