using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;
using LLTM.MyAirport.EF;

namespace MyAirport.GraphQL.GraphQLTypes
{
    public class BagageType : ObjectGraphType<Bagage>
    {
        public BagageType() : base()
        {

            Field(x => x.BagageID).Description("Bagage Id");
            Field(x => x.Classe).Description("Classe");
            Field(x => x.Escale).Description("Escale");
            Field(x => x.Prioritaire, type: typeof(BooleanGraphType), nullable: true).Description("Prioritaire");
            Field(x => x.Ssur).Description("Ssur");
            Field(x => x.Sta).Description("Sta");
            Field(x => x.CodeIata).Description("Code Iata");
            Field(x => x.DateCreation).Description("Date création du bagage");
            Field(x => x.Destination).Description("Destination");
            Field(name: "Vol", type: typeof(VolType), resolve: context => context.Source.Vol);
        }
    }
}
