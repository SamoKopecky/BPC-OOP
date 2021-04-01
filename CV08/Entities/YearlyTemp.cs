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
        public double MaxTemp => MonthlyTemps.Max();
        public double MinTemp => MonthlyTemps.Min();
        public double AvgYearlyTemp => MonthlyTemps.Average();

        public YearlyTemp(int year, List<double> monthlyTemps)
        {
            Year = year;
            MonthlyTemps = monthlyTemps;
        }
    }
}