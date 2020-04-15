using System.Linq;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using LLTM.MyAirport.EF;
using MyAirport.GraphQL.GraphQLTypes;

namespace MyAirport.GraphQL
{
    public class MyAirportQuery : ObjectGraphType
    {
        public MyAirportQuery(MyAirportContext db)
        {
            Field<ListGraphType<VolType>>(
                "vols",
                resolve: context => db.Vols.Include(v => v.Bagages).ToList());
            Field<ListGraphType<BagageType>>(
                "bagages",
                resolve: context => db.Bagages.Include(b => b.Vol).ToList());


        }
    }
}
