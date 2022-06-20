using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace EdHouseHW
{
    internal static class Program
    {
        private const string File = "input.txt";

        private static void PrintFormattedPoint(Point point)
        {
            Console.WriteLine($"[{point.X},{point.Y}]");
        }

        static void Main(string[] args)
        {
            // choose where to find input
            LunchPairing lunch;
            if (System.IO.File.Exists(File)) // branch for input in file File
            {
                lunch = new LunchPairing(File);
                PrintFormattedPoint(lunch.lunchSpot);
                return;
            }
            if (args.Length > 0 && System.IO.File.Exists(args[0])) // branch for input in file specified in arg[0]
            {
                lunch = new LunchPairing(args[0]);
                PrintFormattedPoint(lunch.lunchSpot);
                return;
            }

            // if no input from files, expect input from stdin
            lunch = new LunchPairing();
            PrintFormattedPoint(lunch.lunchSpot);
        }
    }
}
