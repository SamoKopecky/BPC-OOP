using System;
using System.IO;
using CV08.Entities;

namespace CV08
{
    class Program
    {
        static void Main(string[] args)
        {
            var archive = new TempArchive {Converter = d => $"{d,7:F1}"};
            archive.Load(@"Resources\temps.txt");
            archive.Load(@"Resources\temps1.txt");
            archive.Calibration(0.2);
            archive.PrintTemps();
            archive.PrintAvgYearlyTemps();
            archive.PrintAvgMonthlyTemps();
            archive.Save(@"tempsOut.txt");
        }
    }
}