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
                LunchPairing lunchPairing = ReadFileInput(File);

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

        private static LunchPairing ReadFileInput(string file)
        {
            try
            {
                // open file with input
                using (StreamReader sr = new StreamReader(file, Encoding.UTF8))
                {
                    // get lunch interval
                    string[] firstLine = sr.ReadLine()?.Split('-');
                    int[] lunchInterval = new int[2];
                    if (firstLine == null || firstLine.Length != 2 || !int.TryParse(firstLine[0], out lunchInterval[0]) || !int.TryParse(firstLine[1], out lunchInterval[1]))
                    {
                        Program.ErrorMsg("lunch brake interval specified incorrectly");
                    }

                    string[] directions;
                    directions = sr.ReadLine()?.Split(',');
                    Driver one = new Driver(new Track(directions), lunchInterval);
                    directions = sr.ReadLine()?.Split(',');
                    Driver two = new Driver(new Track(directions), lunchInterval);

                    one.PrintDriver();
                    two.PrintDriver();

                    return new LunchPairing(one, two);
                }
            }
            catch (FileLoadException)
            {
                throw new FileLoadException("file could not be loaded");
            }
            catch (DirectoryNotFoundException)
            {
                throw new DirectoryNotFoundException("file could not be loaded");
            }
        }

        public static void ErrorMsg(string err)
        {
            Console.WriteLine($"ERROR: {err}");
        }

        
    }
}
