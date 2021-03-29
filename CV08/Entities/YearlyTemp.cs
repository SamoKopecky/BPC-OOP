using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CV08.Entities
{
    public class YearlyTemp
    {
        public int Year { get; set; }
        public List<double> MonthlyTemps { get; set; }
        public double MaxTemp { get; }
        public double MinTemp { get; }
        public double AvgYearlyTemp { get; }

        public YearlyTemp(int year, List<double> monthlyTemps)
        {
            Year = year;
            MonthlyTemps = monthlyTemps;
            MaxTemp = MonthlyTemps.Max();
            MinTemp = MonthlyTemps.Min();
            AvgYearlyTemp = MonthlyTemps.Average();
        }
    }
}