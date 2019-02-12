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
            for (int i = 0; i < information.Count; i++)
            {
                CenterConsoleWrite(10, information[i].SuperBowlNumber);
                CenterConsoleWrite(10, Convert.ToString(information[i].Date.Year));
                CenterConsoleWrite(30, information[i].WinningTeam);
                CenterConsoleWrite(30, information[i].WinningQB);
                CenterConsoleWrite(20, information[i].WinningCoach);
                CenterConsoleWrite(30, information[i].MVP);
                CenterConsoleWrite(4, Convert.ToString(information[i].WinningPoints - information[i].LosingPoints));
                Console.WriteLine();
            }
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
    }
}
