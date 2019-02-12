using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Project_Two
{
    class Program
    {
        static void Main(string[] args)
        {
            /**Your application should allow the end user to pass end a file path for output 
            * or guide them through generating the file.
            **/
            List<SuperBowl> information = File.ReadAllLines(@"..\..\..\Super_Bowl_Project.csv")
                                           .Skip(1)
                                           .Select(v => SuperBowl.FromCsv(v))
                                           .ToList();
            TextFile();
            /*foreach (SuperBowl bowl in information)
            {
                Console.WriteLine(bowl.Date.Year);
                Console.WriteLine(bowl.Attendance);
                Console.WriteLine(bowl.WinningQB);
            }
            Console.ReadKey();*/
        }
        public static void CenterConsoleWrite(int length, string text)
        {
            int stringLength = text.Length;
            int buffer = (length - stringLength) / 2;
            string spacer = "";
            for (int i = 0; i < buffer; i++)
            {
                spacer += " ";
            }
            if (stringLength % 2 == 0)
            {
                Console.Write(spacer + text + spacer);
            }
            else
            {
                Console.Write(" " + spacer + text + spacer);
            }
        }
        public static void TextFile()
        {
            string filePath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                "SuperBowl.txt");
            Console.WriteLine(filePath);
            TextWriter sw = new StreamWriter(filePath);
            Console.ReadKey();
        }
    }
}
