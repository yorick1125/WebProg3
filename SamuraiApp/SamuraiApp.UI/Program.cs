using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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
            AddSamurais("Claudiu Sensei", "Aref Sensei", "Sandy Sensei",
                        "Gabriel Sensei", "Larry Sensei", "Ian Sensei",
                        "Helen Sensei", " Vik Sensei", "Chris Sensei");


            //AddSamurais("Shimada", "Okamoto", "Kikuchio", "Hayashida");
            //GetSamurais();
            //AddVariousTypes();
            //QueryFilters();
            QueryAggregates();
            //RetrieveAndUpdateSamurai();
            //RetrieveAndUpdateMultipleSamurais();
            //MultipleDatabaseOperations();
            //RetrieveAndDeleteASamurai();
            //QueryAndUpdateBattles_Disconnected();

            Write("Press any key...");
            ReadKey();
        }


           
        private static void AddSamurais(params string[] names)
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
            // 1 .
            var name = "C%";
            var samurais = _context.Samurais.Where(s => s.Name == name).ToList();
            // 2 .
            var filter = "C%";
            var samurais2 = _context.Samurais
                 .Where(s => EF.Functions.Like(s.Name, filter)).ToList();
            // 3 .
            // This code is equivalent to EF . Functions . Like
            // except that this searches for % C %
            var samurais3 = _context.Samurais
                 .Where(s => s.Name.Contains("C")).ToList();
            Print(samurais, "1. ");         // q : why is this samurai not shown ?
            Print(samurais2, "2. ");
            Print(samurais3, "3. ");
            
        }

        private static void QueryAggregates()
        {
            var name = "Claudiu Sensei";
            var samurai = _context.Samurais.FirstOrDefault(s => s.Name == name);

            int id = 5; // the PK id might need to be different for your scenario
            var samurai2 = _context.Samurais.Find(id);

            Print(samurai);
            Print(samurai2);
        }

        private static void RetrieveAndUpdateSamurai()
        {
            var samurai = _context.Samurais.FirstOrDefault();
            samurai.Name += " San ";

            _context.SaveChanges();
            Print(samurai);
        }

        private static void RetrieveAndUpdateMultipleSamurais()
        {
            var samurais = _context.Samurais.Skip(1).Take(4).ToList();
            samurais.ForEach(s => s.Name += " San " ) ;
            _context.SaveChanges() ;
            Print(samurais );
        }

        private static void MultipleDatabaseOperations()
        {
             var samurai = _context.Samurais.FirstOrDefault();
            samurai.Name += " San " ;
            _context.Samurais.Add( new Samurai { Name = " Shino " } ) ;
            _context.SaveChanges( ) ;
            Print(samurai );
        }

        private static void RetrieveAndDeleteASamurai()
        {
            int id = 6;
            var samurai = _context.Samurais.Find(id);

            if(samurai != null)
            {
                _context.Samurais.Remove(samurai);
                _context.SaveChanges();

                Print(samurai);
            }
            else
            {
                WriteLine($"Samurai with {id} not found");
            }
        }


    }
}
