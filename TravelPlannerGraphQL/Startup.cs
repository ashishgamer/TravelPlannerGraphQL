using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TravelPlannerGraphQL.Models;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Playground;
using HotChocolate;

namespace TravelPlannerGraphQL
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSingleton<TravelRepository>();
            services.AddScoped<TravelQuery>();

            services.AddGraphQLServer()
                .AddQueryType<TravelQuery>()
                .AddApolloTracing()
                .AddInMemorySubscriptions();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UsePlayground(new PlaygroundOptions
                {
                    QueryPath = "/graphql",
                    Path = "/playground",
                });
            }

            app.UseCors(builder => builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin()
            );

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGraphQL("/graphql");
            });
        }
    }
}
