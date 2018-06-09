//#define debug
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RandomDelete
{
    class Program
    {
        const double ratio = 0.7;
        static Random _random = new Random();

        static void Main(string[] args)
        {
            bool dontPause = false, removeDetected = true;

#if debug
            deleteRandomFiles("c:\\output",true);
#else
            if (args.Length < 1)
            {
                Console.WriteLine("! Wrong arguments");
                Console.WriteLine("use : RandomDelete directory [--dont-pause] [--remove-detected]");
            }
            else
            {

                if (!Directory.Exists(args[0]))
                    Console.WriteLine("! args[0] should be an existing directory");
                else
                {
                    ProcessArgs(args, out removeDetected, out dontPause);
                    deleteRandomFiles(args[0], removeDetected);
                }

            }
#endif
            if (!dontPause)
                Console.ReadKey();
        }

        private static void ProcessArgs(string[] args, out bool removeDetected, out bool dontPause)
        {
            removeDetected = dontPause = false;

            foreach (string arg in args)
            {
                if (arg.ToLower() == "--dont-pause")
                    dontPause = true;
                else if (arg.ToLower() == "--remove-detected")
                    removeDetected = true;
            }
        }

        private static void deleteRandomFiles(string directory, bool removeDetected)
        {
            Console.WriteLine("Ratio : {0}", ratio);
            Console.WriteLine("Directory : {0}", directory);

            string[] files = Directory.EnumerateFiles(directory, "*.*", SearchOption.TopDirectoryOnly).ToArray();

            Console.WriteLine("Number of files found : {0}", files.Length);
            Console.WriteLine("Number of files to remove : {0}", files.Length * ratio);

            // generate array containing values [0..nFiles]
            List<int> allIndexes = Count(0, files.Length);

            // the values removed from the list are the indexes of the files to keep
            for (int i = 0; i < (int)(files.Length * (1 - ratio)); i++)
                allIndexes.RemoveAt(_random.Next(allIndexes.Count));

            for (int i = 0; i < allIndexes.Count; i++)
                try
                {
                    if (removeDetected)
                        File.Delete(files[allIndexes[i]]);
                    Console.WriteLine((removeDetected ? "" : "Not ") + "Removed : {0}", files[allIndexes[i]]);
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        private static List<int> Count(int start, int end)
        {
            if (start > end)
                throw new IndexOutOfRangeException();

            int[] count = new int[end - start];
            for (int i = 0; i < count.Length; i++)
                count[i] = i + start;
            return count.ToList();
        }
    }
}
