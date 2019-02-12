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
            TextFile(information);
            /*foreach (SuperBowl bowl in information)
            {
                Console.WriteLine(bowl.Date.Year);
                Console.WriteLine(bowl.Attendance);
                Console.WriteLine(bowl.WinningQB);
            }
            Console.ReadKey();*/
        }
        public static void TextFile(List<SuperBowl> information)
        {
            string filePath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                "SuperBowl.txt");
            /*Console.WriteLine(filePath);
            TextWriter sw = new StreamWriter(filePath);
            Console.ReadKey();*/
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            //Create the file.
            using (FileStream fs = File.Create(filePath))
            {
                for (int i = 0; i < information.Count; i++)
                {
                    AddText(fs, information[i].SuperBowlNumber.PadRight(20));
                    AddText(fs, Convert.ToString(information[i].Date.Year).PadRight(20));
                    AddText(fs, "\r\n");
                    /*AddText(fs, "This is some more text,");
                    AddText(fs, "\r\nand this is on a new line");
                    AddText(fs, "\r\n\r\nThe following is a subset of characters:\r\n");*/
                }
            }

            //Open the stream and read it back.
            using (FileStream fs = File.OpenRead(filePath))
            {
                byte[] b = new byte[1024];
                UTF8Encoding temp = new UTF8Encoding(true);
                while (fs.Read(b, 0, b.Length) > 0)
                {
                    Console.WriteLine(temp.GetString(b));
                }
            }
        }

        private static void AddText(FileStream fs, string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fs.Write(info, 0, info.Length);
        }
    }
}
