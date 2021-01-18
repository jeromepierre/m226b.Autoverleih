using m226b.Autoverleih.Programm.Data;
using System;

namespace m226b.Autoverleih.Programm
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Willkommen in Jérômes Autoverleih!");
            Repository repo = DataUtil.GenerateMockData();
        }
    }
}
