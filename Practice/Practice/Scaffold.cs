using Practice.GuessNumber;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public class Scaffold
    {
        public string Word { get; private set; }
        private int _attempts;
        readonly Difficulty difficulty;
        private bool[] _state;
        private char _letter;

        public Scaffold(Difficulty difficulty = Difficulty.Normal)
        {
            this.difficulty = difficulty;
            StartGame();
        }

        public void StartGame()
        {
            _attempts = (int)difficulty;

            OpenFile();
            CreateStates();

            Console.WriteLine("Добро пожаловать в игру виселица!");
            Console.WriteLine($"В вашем слове {Word.Length} букв.");

            PrintWord();
            Game();
        }

        private void Game()
        {
            int count = 0;

            while (_attempts > 0)
            {
                GetLetter();

                if (!IsRight())
                {
                    Console.WriteLine($"Вы ошиблись!\nПопыток осталось: {--_attempts}");
                }

                PrintWord();

                if (++count >= Word.Length)
                {
                    if (IsWin())
                    {
                        Win();
                        return;
                    }
                }
                
            }

        Lose();
        return;               
        }

        private void GetLetter()
        {
            while (true)
            {
                Console.Write("Введите вашу букву: ");

                string letter = Console.ReadLine();

                if (letter.Length == 1)
                {
                    _letter = char.Parse(letter);
                    return;
                }
                else
                {
                    Console.WriteLine("Вы можете ввести только 1 букву!");
                }
            }
        }

        private bool IsRight()
        {
            for (int i = 0; i < Word.Length; i++)
            {
                if (_letter == Word[i])
                {
                    for (int j = i; j < _state.Length; j++)
                    {
                        if (_letter == Word[j])
                            _state[j] = true;
                    }
                    return true;
                }                    
            }

            return false;
        }

        private bool IsWin()
        {
            int countTrueState = 0;

            for (int i = 0; i < _state.Length; i++)
            {
                if (_state[i])
                    countTrueState++;
            }

            if (countTrueState == _state.Length)
                return true;
            else
                return false;
        }

        private void Win()
        {
            Console.WriteLine($"Вы победили! Поздравляем!");
            Restart();
        }

        private void Lose()
        {
            Console.WriteLine($"Загаданное слово - это {Word}");
            Console.WriteLine("К сожалению, Вы проиграли!");
            Restart();
        }

        private void Restart()
        {
            while (true)
            {
                Console.Write("Хотите попробовать еще раз?\nда/нет: ");
                string answer = Console.ReadLine();

                if (answer == "да")
                {
                    StartGame();
                    return;
                }
                else if (answer == "нет")
                {
                    return;
                }
            }
        }

        private void PrintWord()
        {
            for(int i = 0; i < Word.Length; i++)
            {   
                if (_state[i])
                    Console.Write(Word[i]);
                else
                    Console.Write('_');

                Console.Write(' ');
            }
            Console.WriteLine();
        }

        private void OpenFile()
        {
            var rand = new Random();
            int strNumber = rand.Next(11648) + 1;
            IEnumerable<string> line = File.ReadLines("WordsStockRus.txt").Skip(strNumber).Take(1);

            foreach(var item in line)
            {
                Word = item.TrimEnd();
            }          
        }

        private void CreateStates()
        {
            _state = new bool[Word.Length];

            for (int i = 0; i < Word.Length; i++)
            {
                _state[i] = false;
            }
        }       
    }

    public enum Difficulty 
    {
        Easy = 9,
        Normal = 6,
        Hard = 3
    }
}
