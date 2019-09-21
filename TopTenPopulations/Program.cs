using System;
using System.Collections.Generic;
using System.Linq;

namespace AllCountriesPopulation
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"A:\data\Pop by Largest Final.csv";
            CsvReader reader = new CsvReader(filePath);

            Dictionary<string, List<Country>> countries = reader.ReadAllCountries();

            foreach(string region in countries.Keys)
                Console.WriteLine(region);
            Console.WriteLine("Which region do you want?");
            string chosenRegion = Console.ReadLine();

            if (countries.ContainsKey(chosenRegion))
            {
                foreach (Country country in countries[chosenRegion].Take(10))
                {
                    Console.WriteLine($"{PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)} : { country.Name}");
                }
                Console.WriteLine($"{countries.Count} countries");
            }
            else
            {
                Console.WriteLine("This is not a valid region");
            }
        }
    }
}
