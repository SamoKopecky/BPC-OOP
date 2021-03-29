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
            archive.Load(GetResourcePath("temps.txt"));
            archive.Load(GetResourcePath("temps1.txt"));
            archive.Calibration(0.2);
            archive.PrintTemps();
            archive.PrintAvgYearlyTemps();
            archive.PrintAvgMonthlyTemps();
            archive.Save(GetResourcePath("tempsOut.txt"));
        }

        private static string GetResourcePath(string resourceName)
        {
            var workingDirectory = Environment.CurrentDirectory;
            var projectDirectory = Directory.GetParent(workingDirectory).Parent?.Parent?.FullName;
            return $@"{projectDirectory}\Resources\{resourceName}";
        }
    }
}