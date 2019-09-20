using System;
using System.Collections.Generic;
using System.IO;

namespace TopTenPopulations
{
    public class CsvReader
    {
        private string _csvFilePath;

        public CsvReader(string filePath)
        {
            this._csvFilePath = filePath;
        }

        public List<Country> ReadAllCountries()
        {

// Instantiating an array without knowing its elements

            List<Country> countries = new List<Country>();

/* using statement is required by StreamReader and makes sure that the StreamReader
 object is disposed of once we've finished with it. 
 It's important, because the StreamReaders actually lock the file they're reading,
 and disposing the StreamReader will unlock the file so other processes can use it.*/

            using (StreamReader sr = new StreamReader(_csvFilePath))
            {
                // read header line, it needs to be ignored.
                sr.ReadLine();

                string csvLine;
                while ((csvLine = sr.ReadLine()) != null)
                { 
                    csvLine = sr.ReadLine();
                    countries.Add(ReadCountryFromCsvLine(csvLine));
                }
            }

            return countries;
        }

        public Country ReadCountryFromCsvLine(string csvLine)
        {
            string[] parts = csvLine.Split(new char[] { ',' });

            string name = parts[0];
            string code = parts[1];
            string region = parts[2];
            int population = int.Parse(parts[3]);

            return new Country(name, code, region, population);
        }
    }
}