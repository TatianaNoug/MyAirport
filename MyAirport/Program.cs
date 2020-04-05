using LucLopTatMei.MyAirport.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Configuration;

namespace LucLopTatMei.MyAirport
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

            var optionsBuilder = new DbContextOptionsBuilder<MyAirportContext>()
                                    .UseSqlServer(connectionString);
            
            using (var db = new MyAirportContext(optionsBuilder.Options)) ;
        }
    }
}
