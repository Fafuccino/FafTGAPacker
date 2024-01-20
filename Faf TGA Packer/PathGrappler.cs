using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faf_TGA_Packer
{
    internal class PathGrappler
    {
        public static Dictionary<string, string[]> FileRefs = new();    // string[] = BGRA in this order
        public static List<string> SkipList = new();

        public static void Grab(bool portable = false, string[] args = null)
        {
            string[] fileList;

            if (!portable)
            {
                fileList = Directory.GetFiles("./input/");
            }
            else
            {
                fileList = args;
            }

            foreach (string file in fileList)
            {
                string fileName = Path.GetFileNameWithoutExtension(file);
                string key = fileName.Remove(fileName.Length - 2);

                if (!FileRefs.ContainsKey(key))
                {
                    FileRefs.Add(key, new string[4]);
                }
                // Ex : barbara_b.png -> FileRefs["barbara"][0] = "barbara_b.png"
                switch (fileName.Substring(fileName.Length - 1))
                {
                    case "b":
                        FileRefs[key][0] = file;
                        break;

                    case "g":
                        FileRefs[key][1] = file;
                        break;

                    case "r":
                        FileRefs[key][2] = file;
                        break;

                    case "a":
                        FileRefs[key][3] = file;
                        break;

                    default:
                        SkipList.Add(key);

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"'{file}' is either not named correctly, or it's not the right file.");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
            }
        }

        public static void Steal(string[] args)
        {

        }

        public static void Print()
        {
            foreach (var file in PathGrappler.FileRefs)
            {
                Console.WriteLine($"- {file.Key} :");

                foreach (var channel in PathGrappler.FileRefs[file.Key])
                {
                    Console.WriteLine($"{channel}");
                }

                Console.WriteLine();
            }
        }
    }
}
