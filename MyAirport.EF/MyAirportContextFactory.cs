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
        optionsBuilder.UseSqlServer("Data Source=blog.db");

        return new MyAirportContext(optionsBuilder.Options);
    }
    }
}
