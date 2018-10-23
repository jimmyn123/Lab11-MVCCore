using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Lab11_MVCCore.Models
{
    public class TimePerson
    {
        // the properties of the person on time
        public int Year { get; set; }
        public string Honor { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int Birth_Year { get; set; }
        public int DeathYear { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Context { get; set; }

        /// <summary>
        /// This will give you a list of the TimePerson that has been on Time magazine fromt the beginning year to the end year.
        /// This is static because you do not need to make an instance of timeperson to find a person in a time frame.
        /// </summary>
        /// <param name="begYear">the beginning year</param>
        /// <param name="endYear">the end year</param>
        /// <returns>A list of all persons on time in this year range</returns>
        public static List<TimePerson> GetPersons(int begYear, int endYear)
        {
            // Creates a new list of TimePerson to return later
            List<TimePerson> people = new List<TimePerson>();
            string path = Environment.CurrentDirectory;
            string newPath = Path.GetFullPath(Path.Combine(path, @"wwwroot\personOfTheYear.csv"));
            string[] myFile = File.ReadAllLines(newPath);

            for (int i = 1; i < myFile.Length; i++)
            {
                string[] fields = myFile[i].Split(',');
                people.Add(new TimePerson
                {
                    Year = Convert.ToInt32(fields[0]),
                    Honor = fields[1],
                    Name = fields[2],
                    Country = fields[3],
                    Birth_Year = (fields[4] == "") ? 0 : Convert.ToInt32(fields[4]),
                    DeathYear = (fields[5] == "") ? 0 : Convert.ToInt32(fields[5]),
                    Title = fields[6],
                    Category = fields[7],
                    Context = fields[8],
                });
            }

            List<TimePerson> listofPeople = people.Where(p => (p.Year >= begYear) && (p.Year <= endYear)).ToList();
            return listofPeople;
        }
}
