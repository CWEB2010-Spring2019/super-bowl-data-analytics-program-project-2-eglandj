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
        string SuperBowlNumber { get; set; }
        int Attendance { get; set; }
        string WinningQB { get; set; }
        string WinningCoach { get; set; }
        string WinningTeam { get; set; }
        int WinningPoints { get; set; }
        string LosingQB { get; set; }
        string LosingCoach { get; set; }
        string LosingTeam { get; set; }
        int LosingPoints { get; set; }
        string MVP { get; set; }
        string Stadium { get; set; }
        string City { get; set; }
        string State { get; set; }

        public static SuperBowl FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(',');
            SuperBowl superBowlInfo = new SuperBowl();
            superBowlInfo.Date = Convert.ToDateTime(values[0]);
            superBowlInfo.SuperBowlNumber = Convert.ToString(values[1]);
            superBowlInfo.Attendance = Convert.ToInt32(values[2]);
            superBowlInfo.WinningQB = Convert.ToString(values[3]);
            superBowlInfo.WinningCoach = Convert.ToString(values[4]);
            superBowlInfo.WinningTeam = Convert.ToString(values[5]);
            superBowlInfo.WinningPoints = Convert.ToInt32(values[6]);
            superBowlInfo.LosingQB = Convert.ToString(values[7]);
            superBowlInfo.LosingCoach = Convert.ToString(values[8]);
            superBowlInfo.LosingTeam = Convert.ToString(values[9]);
            superBowlInfo.LosingPoints = Convert.ToInt32(values[10]);
            superBowlInfo.MVP = Convert.ToString(values[11]);
            superBowlInfo.Stadium = Convert.ToString(values[12]);
            superBowlInfo.City = Convert.ToString(values[13]);
            superBowlInfo.State = Convert.ToString(values[14]);
            return superBowlInfo;
        }
    }
}
