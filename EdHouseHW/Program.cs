using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EdHouseHW
{
    internal class Program
    {
        public const string File = "x.txt";

        static void Main(string[] args)
        {
            // choose where to find input
            if (System.IO.File.Exists(File))
            {
                LunchPairing lunchPairing = new LunchPairing();
                if (lunchPairing.FindLunchCords(File))
                {
                    Console.WriteLine(lunchPairing.lunchCords);
                }
            }
            else if (args.Length > 0)
            {
                if (System.IO.File.Exists(args[0]))
                {
                    LunchPairing lunchPairing = new LunchPairing();
                    if (lunchPairing.FindLunchCords(args[0]))
                    {
                        Console.WriteLine(lunchPairing.lunchCords);
                    }
                }
                else
                {
                    ErrorMsg("file passed in argument could not be found");
                }
            }
            else
            {
                LunchPairing lunchPairing = new LunchPairing();
                if (lunchPairing.FindLunchCords())
                {
                    Console.WriteLine(lunchPairing.lunchCords);
                }
            }
        }

        

        public static void ErrorMsg(string err)
        {
            Console.WriteLine($"ERROR: {err}");
        }

        
    }
}
