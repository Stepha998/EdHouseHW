using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EdHouseHW
{
    internal static class Program
    {
        private const string File = "input.txt";

        static void Main(string[] args)
        {
            // choose where to find input
            LunchPairing lunch;
            if (System.IO.File.Exists(File))
            {
                lunch = new LunchPairing(File);
                Console.WriteLine(lunch.lunchSpot);
                return;
            }
            if (args.Length > 0)
            {
                if (System.IO.File.Exists(args[0]))
                {
                    lunch = new LunchPairing(args[0]);
                    Console.WriteLine(lunch.lunchSpot);
                    return;
                }
            }

            lunch = new LunchPairing();
            Console.WriteLine(lunch.lunchSpot);
        }

        

        public static void ErrorMsg(string err)
        {
            Console.WriteLine($"ERROR: {err}");
        }

        
    }
}
