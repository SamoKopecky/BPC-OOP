using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CV08.Entities
{
    public class TempArchive
    {
        public Func<double, string> Converter { get; set; } = d => d.ToString();
        private SortedDictionary<int, YearlyTemp> _archive = new SortedDictionary<int, YearlyTemp>();

        public void Load(string filePath)
        {
            var reader = File.OpenText(filePath);
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                var yearSplit = line.Split(":");
                var year = Convert.ToInt32(yearSplit[0]);
                var temps = yearSplit[1]
                    .Split(';')
                    .Select(Convert.ToDouble)
                    .ToList();
                var yearlyTemp = new YearlyTemp(year, temps);

                try
                {
                    _archive.Add(year, yearlyTemp);
                }
                catch (ArgumentException)
                {
                    Console.WriteLine(
                        $"Can't add the same year multiple times, skipping year {year} in file {filePath}");
                }
            }

            reader.Close();
        }

        public void Save(string filePath)
        {
            var fStream = File.Open(filePath, FileMode.Create);
            var writer = new StreamWriter(fStream);
            var lines = new List<string>();
            foreach (var (key, value) in _archive)
            {
                var stringBuilder = new StringBuilder();
                var strings = value.MonthlyTemps.Select(t => $"{t:F1}").ToList();
                stringBuilder.Append(key + ":");
                stringBuilder.Append(string.Join(";", strings));
                lines.Add(stringBuilder.ToString());
            }

            foreach (var line in lines) writer.WriteLine(line);

            writer.Close();
        }

        public void Calibration(double delta)
        {
            var archive = new SortedDictionary<int, YearlyTemp>();
            foreach (var (key, value) in _archive)
            {
                var newTemps = value.MonthlyTemps.Select(t => t + delta).ToList();
                archive[key] = new YearlyTemp(key, newTemps);
            }

            _archive = archive;
        }

        public YearlyTemp Find(int year)
        {
            return _archive[year];
        }

        public void PrintTemps()
        {
            Console.WriteLine("Currently loaded temperatures: ");
            var lengths = new HashSet<int>();
            foreach (var yearlyTemp in _archive.Values)
            {
                var stringBuilder = new StringBuilder();
                var strings = yearlyTemp.MonthlyTemps.Select(Converter).ToList();
                stringBuilder.Append(yearlyTemp.Year + ":");
                stringBuilder.Append(string.Join("", strings));
                lengths.Add(stringBuilder.Length);
                Console.WriteLine(stringBuilder);
            }

            Console.WriteLine(new string('-', lengths.Max()));
        }

        public void PrintAvgYearlyTemps()
        {
            Console.WriteLine("Average temperatures for each year: ");
            var lengths = new HashSet<int>();
            foreach (var yearlyTemp in _archive.Values)
            {
                var stringBuilder = new StringBuilder();
                stringBuilder.Append(yearlyTemp.Year + ":");
                stringBuilder.Append(Converter(yearlyTemp.AvgYearlyTemp));
                lengths.Add(stringBuilder.Length);
                Console.WriteLine(stringBuilder);
            }

            Console.WriteLine(new string('-', lengths.Max()));
        }

        public void PrintAvgMonthlyTemps()
        {
            Console.WriteLine("Average temperatures for each month: ");
            var avgTemps = new double[12];
            var years = _archive.Values.Count;
            foreach (var yearlyTemp in _archive.Values)
                for (var i = 0; i < 12; i++)
                    avgTemps[i] += yearlyTemp.MonthlyTemps[i];

            avgTemps = avgTemps.Select(t => t / years).ToArray();
            var stringBuilder = new StringBuilder();
            var strings = avgTemps.Select(Converter).ToList();
            stringBuilder.Append("Avg.:");
            stringBuilder.Append(string.Join("", strings));

            Console.WriteLine(stringBuilder);
            Console.WriteLine(new string('-', stringBuilder.Length));
        }
    }
}