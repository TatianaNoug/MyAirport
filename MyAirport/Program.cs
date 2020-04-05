using LLTM.MyAirport.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Configuration;
using Microsoft.Extensions.Logging;

namespace LLTM.MyAirport
{
    class Program
    {

        static void Main(string[] args)
        {
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter("Microsoft", LogLevel.Warning)
                    .AddFilter("System", LogLevel.Warning)
                    .AddFilter("LoggingConsoleApp.Program", LogLevel.Debug)
                    .AddConsole();
            });
            ILogger logger = loggerFactory.CreateLogger<Program>();
            logger.LogInformation("Example log message");

            var connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

            var optionsBuilder = new DbContextOptionsBuilder<MyAirportContext>()
                                    .UseSqlServer(connectionString)
                                    .UseLoggerFactory(loggerFactory);

            using (var db = new MyAirportContext(optionsBuilder.Options)) ;

            System.Console.WriteLine("MyAirport project bonjour!!");
            using (var db = new MyAirportContext(optionsBuilder.Options))
            {
                // Create
                Console.WriteLine("Création du vol LH1232");
                Vol v1 = new Vol
                {
                    Cie = "LH",
                    Des = "BKK",
                    Dhc = Convert.ToDateTime("14/01/2020 16:45"),
                    Imm = "RZ62",
                    Lig = "1232",
                    Pkg = "R52",
                    Pax = 238
                };
                db.Add(v1);

                Console.WriteLine("Creation vol SQ333");
                Vol v2 = new Vol
                {
                    Cie = "SK",
                    Des = "CDG",
                    Dhc = Convert.ToDateTime("14/01/2020 18:20"),
                    Imm = "TG43",
                    Lig = "333",
                    Pkg = "R51",
                    Pax = 423
                };
                db.Add(v2);

                Console.WriteLine("creation du bagage 012387364501");
                Bagage b1 = new Bagage
                {
                    Classe = "Y",
                    CodeIata = "012387364501",
                    DateCreation = Convert.ToDateTime("14/01/2020 12:52"),
                    Destination = "BEG"
                };
                db.Add(b1);

                db.SaveChanges();
                Console.ReadLine();

                // Read
                Console.WriteLine("Voici la liste des vols disponibles");
                var vol = db.Vols
                    .OrderBy(v => v.Cie);
                foreach (var v in vol)
                {
                    Console.WriteLine($"Le vol {v.Cie}{v.Lig} N° {v.VolID} a destination de {v.Des} part à {v.Dhc} heure");
                }
                Console.ReadLine();

                // Update
                Console.WriteLine($"Le bagage {b1.BagageID} est modifié pour être rattaché au vol {v1.VolID} => {v1.Cie}{v1.Lig}");
                b1.Vol = v1;
                db.SaveChanges();
                Console.ReadLine();

                // Delete vol et bagages du vol
                Console.WriteLine($"Suppression du vol {v1.VolID} => {v1.Cie}{v1.Lig}");
                db.Remove(v1);
                db.SaveChanges();
                Console.ReadLine();
            }

        }

       
    }
}
