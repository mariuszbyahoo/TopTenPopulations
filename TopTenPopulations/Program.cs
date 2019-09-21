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

            List<Country> countries = reader.ReadAllCountries();
            
// The OrderBy() method requires a delegate or lambda expression passed 
// in as an argument of the method.
            foreach (Country country in countries.OrderBy(x => x.Name))
// LINQ doesn't really support batching
            {
                Console.WriteLine($"{PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)} : { country.Name}");
            }
            Console.WriteLine($"{countries.Count} countries");
        }
    }
}
