using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

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
            Greeting(out string filePath);
            FileCheck(filePath, out FileStream fs);
            SuperBowlWinners(information, filePath, ref fs);
            fs.Close();
        }
       static void Greeting(out string filePath)
        {
            Console.WriteLine("Type a name for the text file you will be creating.\nDO NOT add an extension behind it");
            string userPath = Console.ReadLine() + ".txt";
            filePath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop),userPath);
        }
        static void FileCheck(string filePath, out FileStream fs)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            fs = File.Create(filePath);
        }
        static void SuperBowlWinners(List<SuperBowl> information, string filePath, ref FileStream fs)
        {
            AddText(fs, CenterConsoleWrite(138, "Super Bowl Winners") + "\r\n" + "\r\n");
            AddText(fs, " " + new string('-', 138) + "\r\n");
            AddText(fs, "| " + CenterConsoleWrite(8, "SB #") + " | " + CenterConsoleWrite(4, "Year") + " | " + CenterConsoleWrite(20, "Winning Team")
                + " | " + CenterConsoleWrite(26, "Winning QB") + " | " + CenterConsoleWrite(20, "Winning Coach") + " | " + CenterConsoleWrite(26, "MVP") + " | " 
                + CenterConsoleWrite(14, "Point Spread") + " | " + "\r\n");
            AddText(fs, " " + new string('-', 138) + "\r\n");
            foreach (SuperBowl info in information)
            {
                AddText(fs, "| " + CenterConsoleWrite(8, info.SuperBowlNumber) + " | ");
                AddText(fs, CenterConsoleWrite(4, Convert.ToString(info.Date.Year)) + " | ");
                AddText(fs, CenterConsoleWrite(20, info.WinningTeam) + " | ");
                AddText(fs, CenterConsoleWrite(26, info.WinningQB) + " | ");
                AddText(fs, CenterConsoleWrite(20, info.WinningCoach) + " | ");
                AddText(fs, CenterConsoleWrite(26, info.MVP) + " | ");
                AddText(fs, CenterConsoleWrite(14, Convert.ToString(info.PointSpread)) + " | ");
                AddText(fs, "\r\n");
                AddText(fs, " " + new string('-', 138) + "\r\n");
            }
        }
        public static string CenterConsoleWrite(int length, string text)
        {
            int stringLength = text.Length;
            int buffer = (length - stringLength) / 2;
            string spacer = "";
            string newText;
            for (int i = 0; i < buffer; i++)
            {
                spacer += " ";
            }
            if (stringLength % 2 == 0)
            {
                newText = (spacer + text + spacer);
            }
            else
            {
                if (stringLength == 1)
                {
                    try
                    {
                        Convert.ToInt32(text);
                        Convert.ToString(text);
                        newText = (spacer + "0" + text + spacer);
                    }
                    catch
                    {
                        newText = (" " + spacer + text + spacer);
                    }
                }
                else
                {
                    newText = (" " + spacer + text + spacer);
                }
            }
            return newText;
        }
        private static void AddText(FileStream fs, string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fs.Write(info, 0, info.Length);
        }
    }
}
