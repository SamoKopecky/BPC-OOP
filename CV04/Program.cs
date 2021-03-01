using System;

namespace CV04
{
    class Program
    {
        static void Main(string[] args)

        {
            var stringTest = "Toto je retezec predstavovany nekolika radky,\n"
                             + "ktere jsou od sebe oddeleny znakem LF (Line Feed).\n"
                             + "Je tu i nejaky ten vykricnik! Pro ucely testovani i otaznik?\n"
                             + "Toto je jen zkratka zkr. ale ne konec vety. A toto je\n"
                             + "posledni veta!";
            StringStatistics stringStatistics = new StringStatistics(stringTest);
            Console.WriteLine($"Pocet slov: {stringStatistics.WordCount()}");
            Console.WriteLine($"Pocet radku: {stringStatistics.LineCount()}");
            Console.WriteLine($"Pocet vet: {stringStatistics.SentenceCount()}");
            Console.WriteLine($"Nejdelsi slova: {string.Join(", ", stringStatistics.LongestWords())}");
            Console.WriteLine($"Nejkratsi slova: {string.Join(", ", stringStatistics.ShortestWords())}");
            Console.WriteLine($"Najcetnejsi slova: {string.Join(", ", stringStatistics.MostCommonWords())}");
            Console.WriteLine($"Slova dle abecedy: {string.Join(", ", stringStatistics.SortByAlphabet())}");
        }
    }
}