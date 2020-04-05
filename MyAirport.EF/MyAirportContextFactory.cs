using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;


namespace LucLopTatMei.MyAirport.EF
{
    class MyAirportContextFactory : IDesignTimeDbContextFactory<MyAirportContext>
    {
        public MyAirportContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<MyAirportContext>();
        optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Airport;Integrated Security=True");

        return new MyAirportContext(optionsBuilder.Options);
    }
    }
}
