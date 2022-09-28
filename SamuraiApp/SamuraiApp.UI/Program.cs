using System;
using System.Linq;
using SamuraiApp.Data;
using SamuraiApp.Domain;
using static System.Console;

namespace SamuraiApp.UI
{

    class Program
    {
        private static SamuraiContext _context = new SamuraiContext();

        static void Main(string[] args)
        {
            _context.Database.EnsureCreated();
            GetSamurais("Before Add:");
            AddSamurai();
            GetSamurais("After Add:");

            Write("Press any key...");
            ReadKey();
        }

        private static void AddSamurai()
        {
            var samurai = new Samurai { Name = "Yorick" };
            _context.Samurais.Add(samurai);
            _context.SaveChanges();
        }

        private static void GetSamurais(string text)
        {
            var samurais = _context.Samurais.ToList();

            WriteLine($"{text}: Samurai count is {samurais.Count}");
            foreach(var samurai in samurais)
            {
                WriteLine(samurai.Name);
            }
        }
    }
}
