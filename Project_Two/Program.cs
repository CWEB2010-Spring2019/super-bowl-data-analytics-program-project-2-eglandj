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
            List<SuperBowl> values = File.ReadAllLines(@"..\..\..\Super_Bowl_Project.csv")
                                           .Skip(1)
                                           .Select(v => SuperBowl.FromCsv(v))
                                           .ToList();
            foreach (SuperBowl bowl in values)
            {
                Console.WriteLine(bowl.Date.Year);
            }
            Console.ReadKey();
        }
    }
}
