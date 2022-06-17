using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EdHouseHW
{
    internal class Program
    {
        private const string File = "input.txt";

        public static List<Driver> Drivers = new();

        static void Main(string[] args)
        {
            // choose where to find input
            if (System.IO.File.Exists(File))
            {
                FileInput();
            }
            else if (args.Length > 0)
            {
                Console.WriteLine("arg");
            }
            else
            {
                Console.WriteLine("keyboard");
            }

            Console.ReadKey();
        }

        private static void FileInput()
        {
            try
            {
                // open file with input
                using (StreamReader sr = new StreamReader(File, Encoding.UTF8))
                {
                    // get lunch interval
                    string[] firstLine = sr.ReadLine()?.Split('-');
                    int[] lunchInterval = new int[2];
                    if (firstLine == null || firstLine.Length != 2 || !int.TryParse(firstLine[0], out lunchInterval[0]) || !int.TryParse(firstLine[1], out lunchInterval[1]))
                    {
                        ErrorMsg("lunch brake interval specified incorrectly");
                    }

                    // get trackList info of the individual drivers
                    while (!sr.EndOfStream)
                    {
                        // get trackList and validate it
                        string[] directions = sr.ReadLine()?.Split(',');

                        Drivers.Add(new Driver(new Track(directions), lunchInterval));

                    }

                    foreach (var driv in Drivers)
                    {
                        driv.PrintDriver();
                    }

                }
            }
            catch (FileLoadException)
            {
                ErrorMsg("file could not be loaded");
            }
            catch (DirectoryNotFoundException)
            {
                ErrorMsg("file could not be loaded");
            }
        }

        public static void ErrorMsg(string err)
        {
            throw new Exception($"ERROR: {err}");
        }

        
    }
}
