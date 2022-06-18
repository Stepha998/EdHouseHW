using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EdHouseHW
{
    internal class Program
    {
        public const string File = "input.txt";

        static void Main(string[] args)
        {
            // choose where to find input
            if (System.IO.File.Exists(File))
            {
                LunchPairing lunchPairing = new LunchPairing(File);
                if (lunchPairing.FindLunchCords())
                {
                    Console.WriteLine(lunchPairing.lunchCords);
                }
                else
                {
                    return;
                }
            }
            else if (args.Length > 0)
            {
                Console.WriteLine("arg");
            }
            else
            {
                Console.WriteLine("keyboard");
            }
        }

        

        public static void ErrorMsg(string err)
        {
            Console.WriteLine($"ERROR: {err}");
        }

        
    }
}
