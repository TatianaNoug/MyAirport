using System;
using System.Diagnostics;
using System.Linq;
using LLTM.MyAirport.EF;
using GraphQL.Types;

namespace MyAirport.GraphQL.GraphQLTypes
{
    public class VolType : ObjectGraphType<Vol>
    {
        public VolType() : base()
        {
            Field(x => x.VolID).Description("Vol ID");
            Field(x => x.Cie).Description("Compagnie");
            Field(x => x.Des).Description("Destination");
            Field(x => x.Dhc, type: typeof(DateGraphType), nullable: true).Description("Date");
            Field(x => x.Imm).Description("Imm");
            Field(x => x.Lig).Description("Ligne");
            Field(x => x.Pax, type: typeof(ShortGraphType), nullable: true).Description("Pax");
            Field(x => x.Pkg).Description("Pkg");
            Field(name: "Bagages", type: typeof(ListGraphType<BagageType>), resolve: context => context.Source.Bagages);
        }

    }
}
