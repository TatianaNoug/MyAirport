using System;
using GraphQL;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;

namespace MyAirport.GraphQL
{
    public class MyAirportSchema : Schema
    {
        public MyAirportSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<MyAirportQuery>();
        }
    }
}
