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
            throw new NotImplementedException();
        }
    }
}