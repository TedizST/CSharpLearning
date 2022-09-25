using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.GuessNumber
{
    public enum Mode
    {
        PlayerVSComputer,
        ComputerVSPlayer,
    }

    public enum Difficulty : byte
    {
        Easy = 7,
        Normal = 5,
        Hard = 3
    }

    public enum Range
    {
        to_50 = 50,
        to_100 = 100,
        to_150 = 150,
        to_200 = 200,
        to_255 = 255
    }
}
