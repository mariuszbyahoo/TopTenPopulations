using System;

namespace TopTenPopulations
{
    public class CsvReader
    {
        private string filePath;

        public CsvReader(string filePath)
        {
            this.filePath = filePath;
        }

        public Country[] ReadFirstNCountries(int nCountries)
        {
// Instantiating an array without knowing its elements
            Country [] countries = new Country[nCountries];
            return countries;
        }

        public Country ReadCountryFromCsvLine(string csvLine)
        {
            string[] parts = csvLine.Split(',');

            string name = parts[0];
            string code = parts[1];
            string region = parts[2];
            int population = int.Parse(parts[3]);

            return new Country(name, code, region, population);
        }
    }
}