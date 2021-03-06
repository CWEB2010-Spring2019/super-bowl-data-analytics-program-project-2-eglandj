﻿using System;
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
            List<SuperBowl> information = File.ReadAllLines(@"..\..\..\Super_Bowl_Project.csv")//Reading all lines from the csv file
                                           .Skip(1)//Skips the first line in the csv file
                                           .Select(superbowl => new SuperBowl(superbowl))//Creating new objects for the read data
                                           .ToList();//Putting the objects into a list
            //Invoking methods and passing in the 
            //specific parameters
            Greeting(out string filePath);
            FileCheck(filePath, out FileStream fs);
            SuperBowlWinners(information, ref fs);
            TopFiveBowls(information, filePath, ref fs);
            MostHostedSuperbowls(information, filePath, ref fs);
            MVP_Winners(information, filePath, ref fs);
            RandomQuestions(information, filePath, ref fs);
            fs.Close();//Closing the file after it has been written too
            
        }
       static void Greeting(out string filePath)
       {
            Console.WriteLine("Type a name for the text file you will be creating.\nDO NOT add an extension behind it");
            string userPath = Console.ReadLine() + ".txt";//Getting username for file and making in a text file
            filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),userPath);//Creating a path for the file to be placed on desktop
       }
        static void FileCheck(string filePath, out FileStream fs)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);//Deletes the file if it already exists
            }
            try
            {
                fs = File.Create(filePath);//Creates the file path if user enters a valid name option
                Console.WriteLine("Your new text file has been created on your desktop.");
            }
            catch
            {
                //Creating a default file name for the user if they entered an invalid option
                Console.WriteLine("That was an invalid option...\nA file with the default name Superbowl has been added to your desktop.");
                fs = File.Create(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Superbowl.txt"));
            }
        }
        static void SuperBowlWinners(List<SuperBowl> information, ref FileStream fs)
        {
            int length = 124;
            AddText(fs, "\r\n" + CenterConsoleWrite(length, "Super Bowl Winners") + "\r\n");
            AddText(fs, " " + new string('-', length) + "\r\n");
            AddText(fs, "|" + CenterConsoleWrite(8, "SB #") + "|" + CenterConsoleWrite(6, "Year") + "|" + CenterConsoleWrite(22, "Winning Team")
                + "|" + CenterConsoleWrite(28, "Winning QB") + "|" + CenterConsoleWrite(20, "Winning Coach") + "|" + CenterConsoleWrite(26, "MVP") + "|" 
                + CenterConsoleWrite(8, "Spread") + "|" + "\r\n");
            AddText(fs, " " + new string('=', length) + "\r\n");
            foreach (SuperBowl info in information)
            {
                AddText(fs, "|" + CenterConsoleWrite(8, info.SuperBowlNumber) + "|");
                AddText(fs, CenterConsoleWrite(6, Convert.ToString(info.Date.Year)) + "|");
                AddText(fs, CenterConsoleWrite(22, info.WinningTeam) + "|");
                AddText(fs, CenterConsoleWrite(28, info.WinningQB) + "|");
                AddText(fs, CenterConsoleWrite(20, info.WinningCoach) + "|");
                AddText(fs, CenterConsoleWrite(26, info.MVP) + "|");
                AddText(fs, CenterConsoleWrite(8, Convert.ToString(info.PointSpread)) + "|");
                AddText(fs, "\r\n");
                AddText(fs, " " + new string('-', length) + "\r\n");
            }
            AddText(fs, "\r\n");
        }
        static void TopFiveBowls(List<SuperBowl> information, string filePath, ref FileStream fs)
        {
            int length = 124;
            AddText(fs, CenterConsoleWrite(length, "Top 5 Attended Super Bowls") + "\r\n");
            AddText(fs, " " + new string('-', length) + "\r\n");
            AddText(fs, "|" + CenterConsoleWrite(12, "Attendance") + "|" + CenterConsoleWrite(6, "Year") + "|" + CenterConsoleWrite(20, "Winning Team")
                + "|" + CenterConsoleWrite(26, "Losing Team") + "|" + CenterConsoleWrite(18, "City") + "|" + CenterConsoleWrite(18, "State") + "|"
                + CenterConsoleWrite(18, "Stadium") + "|" + "\r\n");
            AddText(fs, " " + new string('=', length) + "\r\n");

            IEnumerable<SuperBowl> attendenceList = information.OrderByDescending(bowl => bowl.Attendance).Take(5);
            foreach (SuperBowl info in attendenceList)
            {
                AddText(fs, "|" + CenterConsoleWrite(12, info.Attendance.ToString("n0")) + "|");
                AddText(fs, CenterConsoleWrite(6, Convert.ToString(info.Date.Year)) + "|");
                AddText(fs, CenterConsoleWrite(20, info.WinningTeam) + "|");
                AddText(fs, CenterConsoleWrite(26, info.LosingTeam) + "|");
                AddText(fs, CenterConsoleWrite(18, info.City) + "|");
                AddText(fs, CenterConsoleWrite(18, info.State) + "|");
                AddText(fs, CenterConsoleWrite(18, info.Stadium) + "|");
                AddText(fs, "\r\n");
                AddText(fs, " " + new string('-', length) + "\r\n");
            }
            AddText(fs, "\r\n");
        }
        static void MostHostedSuperbowls(List<SuperBowl> information, string filePath, ref FileStream fs)
        {
            int length = 124;
            AddText(fs, CenterConsoleWrite(length, "State With The Most Hosted Super Bowls") + "\r\n");
            AddText(fs, " " + new string('-', length) + "\r\n");
            AddText(fs, "|" + CenterConsoleWrite(20, "Super Bowl Number") + "|" + CenterConsoleWrite(10, "Year") + "|" + CenterConsoleWrite(30, "City") + "|" + 
                CenterConsoleWrite(30, "State") + "|" +  CenterConsoleWrite(30, "Stadium") + "|" + "\r\n");
            AddText(fs, " " + new string('=', length) + "\r\n");

            var HostedGroup =
                from info in information
                group info by info.State into stateGroups
                orderby stateGroups.Count() descending
                select stateGroups;

            var SortedHost =
                from city in HostedGroup.First()
                orderby city.City
                select city;

            foreach (var city in SortedHost)
            {
                AddText(fs, "|" + CenterConsoleWrite(20, city.SuperBowlNumber) + "|");
                AddText(fs, CenterConsoleWrite(10, city.Date.Year.ToString()) + "|");
                AddText(fs, CenterConsoleWrite(30, city.City) + "|");
                AddText(fs, CenterConsoleWrite(30, city.State) + "|");
                AddText(fs, CenterConsoleWrite(30, city.Stadium) + "|");
                AddText(fs, "\r\n");
                AddText(fs, " " + new string('-', length) + "\r\n");
            }
            AddText(fs, "\r\n");
        }
        static void MVP_Winners(List<SuperBowl> information, string filePath, ref FileStream fs)
        {
            int length = 124;
            AddText(fs, CenterConsoleWrite(length, "MVP More Than Once") + "\r\n");
            AddText(fs, " " + new string('-', length) + "\r\n");
            AddText(fs, "|" + CenterConsoleWrite(12, "SB #") + "|" + CenterConsoleWrite(12, "Year") + "|" +
                CenterConsoleWrite(32, "MVP") + "|" + CenterConsoleWrite(32, "Winning Team") + "|" +
                CenterConsoleWrite(32, "Losing Team") + "|" + "\r\n");
            AddText(fs, " " + new string('=', length) + "\r\n");

            var MVP =
                from info in information
                group info by info.MVP into MVP_Groups
                orderby MVP_Groups.Count() descending
                where MVP_Groups.Count() > 1
                select MVP_Groups;
            
            foreach (var groupOfMVP in MVP)
            {
                foreach (var info in groupOfMVP)
                {
                    AddText(fs, "|" + CenterConsoleWrite(12, info.SuperBowlNumber) + "|");
                    AddText(fs, CenterConsoleWrite(12, Convert.ToString(info.Date.Year)) + "|");
                    AddText(fs, CenterConsoleWrite(32, info.MVP) + "|");
                    AddText(fs, CenterConsoleWrite(32, info.WinningTeam) + "|");
                    AddText(fs, CenterConsoleWrite(32, info.LosingTeam) + "|");
                    AddText(fs, "\r\n");
                    AddText(fs, " " + new string('-', length) + "\r\n");
                }
            }
            AddText(fs, "\r\n");
        }
        static void RandomQuestions(List<SuperBowl> information, string filePath, ref FileStream fs)
        {
            var WinningCoach =
                from info in information
                group info by info.WinningCoach into WinningCoachGroups
                orderby WinningCoachGroups.Count() descending
                select WinningCoachGroups;

            var WinningTeam =
                from info in information
                group info by info.WinningTeam into WinningTeamGroups
                orderby WinningTeamGroups.Count() descending
                select WinningTeamGroups;

            var LosingCoach =
                from info in information
                group info by info.LosingCoach into LosingCoachGroups
                orderby LosingCoachGroups.Count() descending
                select LosingCoachGroups;

            var LosingTeam =
                from info in information
                group info by info.LosingTeam into LosingTeamGroups
                orderby LosingTeamGroups.Count() descending
                select LosingTeamGroups;
            
            IEnumerable<SuperBowl> pointSpread = information.OrderByDescending(bowl => bowl.PointSpread).Take(1);
            double AverageValue = information.Average(info => info.Attendance);

            int length = 124;
            AddText(fs, CenterConsoleWrite(length, "Fun Facts") + "\r\n");
            AddText(fs, " " + new string('=', length) + "\r\n");
            AddText(fs, "|" + CenterConsoleWrite(42, "Coach with most SB wins") + "|" + CenterConsoleWrite(40, WinningCoach.First().Key) + "|" +
                CenterConsoleWrite(40, WinningCoach.First().Count().ToString()) + "|" + "\r\n");
            AddText(fs, " " + new string('=', length) + "\r\n");
            AddText(fs, "|" + CenterConsoleWrite(42, "Team with most SB wins") + "|" + CenterConsoleWrite(40, WinningTeam.First().First().WinningTeam) + "|" +
                CenterConsoleWrite(40, WinningTeam.First().Count().ToString()) + "|" + "\r\n");
            AddText(fs, " " + new string('=', length) + "\r\n");
            AddText(fs, "|" + CenterConsoleWrite(42, "Coach With Most SB Losses") + "|" + CenterConsoleWrite(40,LosingCoach.First().First().LosingCoach) + "|" +
                CenterConsoleWrite(40, LosingCoach.First().Count().ToString()) + "|" + "\r\n");
            AddText(fs, " " + new string('=', length) + "\r\n");
            AddText(fs, "|" + CenterConsoleWrite(42, "Team With Most SB Losses") + "|" + CenterConsoleWrite(40, LosingTeam.First().First().LosingTeam) + "|" +
                CenterConsoleWrite(40, LosingTeam.First().Count().ToString()) + "|" + "\r\n");
            AddText(fs, " " + new string('=', length) + "\r\n");
            AddText(fs, "|" + CenterConsoleWrite(30, "Largest Point Spread") + "|" + CenterConsoleWrite(30, pointSpread.First().SuperBowlNumber) + "|" + 
                CenterConsoleWrite(30, pointSpread.First().Date.Year.ToString()) + "|" + 
                CenterConsoleWrite(30, pointSpread.First().PointSpread.ToString()) + " |" + "\r\n");
            AddText(fs, " " + new string('=', length) + "\r\n");
            AddText(fs, "|" + CenterConsoleWrite(62, "Average Super Bowl Attendance") + "|" + CenterConsoleWrite(60, AverageValue.ToString("n0")) + " |" + "\r\n");
            AddText(fs, " " + new string('=', length) + "\r\n");
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
