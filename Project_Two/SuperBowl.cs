using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;

namespace Project_Two
{
    class SuperBowl
    {
        public DateTime Date { get; set; }
        public string SuperBowlNumber { get; set; }
        public int Attendance { get; set; }
        public string WinningQB { get; set; }
        public string WinningCoach { get; set; }
        public string WinningTeam { get; set; }
        public int WinningPoints { get; set; }
        public string LosingQB { get; set; }
        public string LosingCoach { get; set; }
        public string LosingTeam { get; set; }
        public int LosingPoints { get; set; }
        public string MVP { get; set; }
        public string Stadium { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public static SuperBowl FromCsv(string csvLine)
        {
            string[] information = csvLine.Split(',');
            SuperBowl superBowlInfo = new SuperBowl();
            superBowlInfo.Date = Convert.ToDateTime(information[0]);
            superBowlInfo.SuperBowlNumber = Convert.ToString(information[1]);
            superBowlInfo.Attendance = Convert.ToInt32(information[2]);
            superBowlInfo.WinningQB = Convert.ToString(information[3]);
            superBowlInfo.WinningCoach = Convert.ToString(information[4]);
            superBowlInfo.WinningTeam = Convert.ToString(information[5]);
            superBowlInfo.WinningPoints = Convert.ToInt32(information[6]);
            superBowlInfo.LosingQB = Convert.ToString(information[7]);
            superBowlInfo.LosingCoach = Convert.ToString(information[8]);
            superBowlInfo.LosingTeam = Convert.ToString(information[9]);
            superBowlInfo.LosingPoints = Convert.ToInt32(information[10]);
            superBowlInfo.MVP = Convert.ToString(information[11]);
            superBowlInfo.Stadium = Convert.ToString(information[12]);
            superBowlInfo.City = Convert.ToString(information[13]);
            superBowlInfo.State = Convert.ToString(information[14]);
            return superBowlInfo;
        }
    }
}
