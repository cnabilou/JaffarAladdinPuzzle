﻿using System;

namespace Jafar_Aladdin
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new[]
            {
                "............",
                "............",
                "........X...",
                "............",
                "........X.X.",
                "............",
                ".....X......",
                "............",
                ".....X......",
                "............",
                ".....X.X....",
                "......O....."
            };
            var maxJump = Solution.GetMaxJump(array);
            Console.WriteLine("Max jump: " + maxJump);
            Console.Read();
        }
    }
}
