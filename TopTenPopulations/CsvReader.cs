using System;
using System.Collections.Generic;
using System.IO;

namespace AllCountriesPopulation
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
                    countries.Add(ReadCountryFromCsvLine(csvLine));
                }
            }
            return countries;
        }

        public Country ReadCountryFromCsvLine(string csvLine)
        {
            Console.WriteLine(csvLine);
            string[] parts = csvLine.Split(',');

            string name;
            string code;
            string region;
            string popText;
            switch (parts.Length)
            {
                case 4:
                    name = parts[0];
                    code = parts[1];
                    region = parts[2];
                    popText = parts[3];
                    break;
                case 5:
                    name = parts[0] + ", " + parts[1];
                    name = name.Replace("\"", null).Trim();
                    code = parts[2];
                    region = parts[3];
                    popText = parts[4];
                    break;
                default:
                    throw new Exception($"Can't parse country from csvLine: {csvLine}");
            }
            // TryParse leaves population=0 if can't parse
            int.TryParse(popText, out int population);
            return new Country(name, code, region, population);
        }
    }
}