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

/* The OrderBy() method requires a delegate or lambda expression passed 
* in as an argument of the method. 
* LINQ doesn't really support batching, but, it supports method chaining anyway.

* Be aware, because the results depend on the order in wich you are chaining the operations in

* Moreover, LINQ cannot remove any data from a data source, according to the fact, that it is
* designed only to recieve items from the Data Source and pass them on. */

            var filteredCountries = countries.Where(x => !x.Name.Contains(','));//.Take(20);

// The same query below uses the LINQ Query Syntax: it tries to mimic SQL
// but still, is working in the same way. Actually, it just doesn't support 
// all of the LINQ features.

            var filteredCountries2 = from country in countries
                                     where !country.Name.Contains(',')
                                     select country;

            foreach (Country country in filteredCountries2)
            {
                Console.WriteLine($"{PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)} : { country.Name}");
            }
            Console.WriteLine($"{countries.Count} countries");

/* LINQ is not modifying the data source, instead of that, it just filters and sorts
* these data from the Data Source, which is being left unmodified. */

            for (int i = 12; i <= 14; i++)
            {
                Console.WriteLine(countries[i].Name);
            }

        }
    }
}
