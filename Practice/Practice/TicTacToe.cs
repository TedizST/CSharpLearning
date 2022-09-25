using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public class TicTacToe
    {
        private char[] _fields = new char[9];
        private bool _flag;
        private string[] _players = new string[] { "First", "Second" };
        private char[] _signs = new char[] { 'X', 'O' };
        private Dictionary<bool, int> BoolToInt = new Dictionary<bool, int>
        {
            { true, 1 },
            { false, 0 }
        };

        public TicTacToe()
        {
            StartGame();
        }

        public void StartGame()
        {
            for (int i = 0; i < 9; i++)
            {
                _fields[i] = ' ';
            }

            _flag = false;

            PrintFields();
            Console.WriteLine("You need to enter number (1 to 9) to choose field.");
            Console.WriteLine("Game started...");
            Game();
        }

        private void Game()
        {
            bool endGame = false;

            for (int i = 0; i < 9; i++)
            {
                PlayerTurn();
                if (i > 3)
                {
                    if (IsWin())
                    {
                        endGame = true;
                        PrintFields();
                        Win();
                        break;
                    }
                }

                PrintFields();
                _flag = !_flag;
            }

            if (!endGame)
            {
                Draw();
            }
        }

        private void PlayerTurn()
        {
            while (true)
            {
                Console.Write($"{_players[BoolToInt[_flag]]}'s player turn: ");
                if (IsValid(out int item))
                {
                    _fields[--item] = _signs[BoolToInt[_flag]];
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid number of field! Try again!");
                }
            }
        }

        private void Win()
        {
            Console.WriteLine($"The {this._players[BoolToInt[this._flag]]} is a winner!");
            Restart();
        }

        private void Draw()
        {
            Console.WriteLine("The game ended in a draw.");
            Restart();
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

        private void PrintFields()
        {
            for (int i = 0, j = 0; i < 3; i++)
            {
                Console.WriteLine("+-----+");
                Console.WriteLine($"|{_fields[j++]}|{_fields[j++]}|{_fields[j++]}|");
            }
            Console.WriteLine("+-----+");
        }

        private bool IsWin()
        {
            int[] winVariables = new int[] { 0, 1, 2, 0, 3, 6, 0, 4, 8,
                                            1, 4, 7, 2, 4, 6, 2, 5, 8,
                                            3, 4, 5, 6, 7, 8 };

            for (int i = 0; i < winVariables.Length; i += 3)
            {
                bool same = AreSame(winVariables[i], winVariables[i + 1], winVariables[i + 2]);
                if (same)
                {
                    return true;
                }
            }
            return false;
        }

        private bool AreSame(int a, int b, int c)
        {
            return _fields[a] == _fields[b] && _fields[a] == _fields[c] && _fields[a] == _signs[BoolToInt[_flag]];
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

            if (item >= 1 && item <= 9 && _fields[item - 1] == ' ')
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