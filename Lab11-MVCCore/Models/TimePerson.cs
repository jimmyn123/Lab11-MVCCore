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
            // creates a new path with the current directory
            string path = Environment.CurrentDirectory;
            // combines the current directory and locates the person of the year csv.
            string newPath = Path.GetFullPath(Path.Combine(path, @"wwwroot\personOfTheYear.csv"));
            // reads all the lines of the csv
            string[] myFile = File.ReadAllLines(newPath);

            // loops through skipping the first line and parses the csv
            for (int i = 1; i < myFile.Length; i++)
            {
                // splits each line by the commas
                string[] fields = myFile[i].Split(',');
                // creates a new person and adds to list
                people.Add(new TimePerson
                {
                    // parses everything between commas into the appropriate fields for our person
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

            // LINQ lambda functions to filter to the appropriate year
            List<TimePerson> listofPeople = people.Where(p => (p.Year >= begYear) && (p.Year <= endYear)).ToList();

            // returns the list of people who match
            return listofPeople;
        }
    }
}
