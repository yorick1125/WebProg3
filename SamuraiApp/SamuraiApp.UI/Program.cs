using System;
using System.Collections.Generic;
using System.Linq;
using SamuraiApp.Data;
using SamuraiApp.Domain;
using static System.Console;

namespace SamuraiApp.UI
{

    class Program
    {
        private static SamuraiContext _context = new SamuraiContext();

        private static void Main(string[] args)
        {
            AddSamurai("Claudiu Sensei", "Aref Sensei", "Sandy Sensei", "Gabriel Sensei");

            //AddSamurais("Shimada", "Okamoto", "Kikuchio", "Hayashida");
            GetSamurais();
            //AddVariousTypes();
            //QueryFilters();
            //QueryAggregates();
            //RetrieveAndUpdateSamurai();
            //RetrieveAndUpdateMultipleSamurais();
            //MultipleDatabaseOperations();
            //RetrieveAndDeleteASamurai();
            //QueryAndUpdateBattles_Disconnected();

            Write("Press any key...");
            ReadKey();
        }


           
        private static void AddSamurai(params string[] names)
        {
            foreach (string name in names)
            {
                _context.Samurais.Add(new Samurai { Name = name });
                // The DbContext tracks the new Samurai inserts
            }
            _context.SaveChanges();
        }

        private static void GetSamurais()
        {
            var samurais = _context.Samurais.ToList();

            WriteLine($"Samurai count is {samurais.Count}");
            foreach(var samurai in samurais)
            {
                WriteLine(samurai.Name);
            }
        }

        private static void Print(IEnumerable<Samurai> samurais, string extra = "")
        {
            foreach(var samurai in samurais)
            {
                WriteLine(extra + samurai.Name);
            }
        }

        private static void Print(Samurai samurai)
        {
            if (samurai != null)
                WriteLine(samurai.Name);
            else
                WriteLine("Samurai is Null");
        }

        private static void AddVariousTypes()
        {
            // Bulk operations (4 inserts or more) are very efficient
            _context.AddRange(
                new Samurai { Name = "Shimada" },
                new Samurai { Name = "Okamoto" },
                new Battle { Name = "Battle of Anegawa" },
                new Battle { Name = "Battle of Nagashino" });

            _context.SaveChanges();
        }

        private static void QueryFilters()
        {
            // 1. 
            var name = "C%";
        }

        private static void QueryAggregates()
        {

        }

        private static void RetrieveAndUpdateSamurai()
        {

        }

        private static void RetrieveAndUpdateMultipleSamurai()
        {

        }

        private static void MultipleDatabaseOperations()
        {

        }

        private static void RetrieveAndDeleteASamurai()
        {

        }


    }
}
