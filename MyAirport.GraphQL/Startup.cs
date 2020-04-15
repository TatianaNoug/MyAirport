using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui;
using GraphQL.Server.Ui.GraphiQL;
using GraphQL.Server.Ui.Playground;
using LLTM.MyAirport.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using MyAirport.GraphQL.GraphQLTypes;
using Microsoft.AspNetCore.Http;


namespace MyAirport.GraphQL
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MyAirportContext>(options =>
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                options.UseSqlServer(connectionString);
            });

            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

           // services.AddScoped<IServiceProvider>(c => new FuncServiceProvider(c.GetRequiredService));
            services.AddScoped<VolType>();
            services.AddScoped<BagageType>();
            services.AddScoped<MyAirportQuery>();
            services.AddScoped<MyAirportSchema>();
            services.AddGraphQL(x =>
            {
                x.ExposeExceptions = true;
            })
                .AddGraphTypes(ServiceLifetime.Scoped)
                .AddNewtonsoftJson(deserializerSettings => { }, serializerSettings => { })
                .AddDataLoader();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }



            app.UseGraphQL<MyAirportSchema>();

            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());

            app.UseGraphiQLServer(new GraphiQLOptions { GraphiQLPath = "/graphql" });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context => { await context.Response.WriteAsync("Hello World!"); });
            });
        }
    }
}
