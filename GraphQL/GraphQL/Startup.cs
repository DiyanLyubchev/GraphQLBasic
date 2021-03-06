using GraphQL.Db.Context;
using GraphQL.DbManager;
using GraphQL.GraphQLServices;
using GraphQL.Model;
using GraphQL.Server.Ui.Voyager;
using HotChocolate.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
namespace GraphQL
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
            services.AddGraphQLServer()
                   .AddQueryType<Qurey>()
                   .AddMutationType<Mutation>()
                   .AddType<CarInput>()
                   .AddType<CarInputType>()
                   .AddProjections()
                   .AddFiltering()
                   .AddSorting()
                   .AddInMemorySubscriptions();

            services.AddScoped<Mutation>();

            string conectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<GasCarDbContext>(options =>
            options.UseSqlServer(conectionString));

            services.AddControllers();

            services.AddScoped<IGasCarDbManager, GasCarDbManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGraphQL();
            });

            app.UseGraphQLVoyager(new GraphQLVoyagerOptions()
            {
                GraphQLEndPoint = "/graphql",
                Path = "/graphql-voyager"
            });

            //app.ApplicationServices
            //   .CreateScope()
            //   .ServiceProvider
            //   .GetService<GasCarDbContext>();
        }
    }
}
