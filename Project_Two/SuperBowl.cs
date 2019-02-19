using System;

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
        public int PointSpread { get; set; }
        public string Stadium { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public SuperBowl(string csvLine)
        {
            string[] information = csvLine.Split(',');
            this.Date = Convert.ToDateTime(information[0]);
            this.SuperBowlNumber = Convert.ToString(information[1]);
            this.Attendance = Convert.ToInt32(information[2]);
            this.WinningQB = Convert.ToString(information[3]);
            this.WinningCoach = Convert.ToString(information[4]);
            this.WinningTeam = Convert.ToString(information[5]);
            this.WinningPoints = Convert.ToInt32(information[6]);
            this.LosingQB = Convert.ToString(information[7]);
            this.LosingCoach = Convert.ToString(information[8]);
            this.LosingTeam = Convert.ToString(information[9]);
            this.LosingPoints = Convert.ToInt32(information[10]);
            this.MVP = Convert.ToString(information[11]);
            this.PointSpread = Convert.ToInt32(information[6]) - Convert.ToInt32(information[10]);
            this.Stadium = Convert.ToString(information[12]);
            this.City = Convert.ToString(information[13]);
            this.State = Convert.ToString(information[14]);
        }
    }
}
