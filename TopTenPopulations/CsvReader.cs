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
    }
}