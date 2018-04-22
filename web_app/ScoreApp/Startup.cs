using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using ScoreApp.DataAccess;

namespace ScoreApp
{
    public class Startup
    {
        public Startup(IHostingEnvironment env, IConfiguration config)
        {
            HostingEnvironment = env;
            Configuration = config;
        }

        public IHostingEnvironment HostingEnvironment { get; }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddSingleton(x => new DatabaseContext(Configuration.GetConnectionString("MySqlConnection")));
            services.AddSingleton(typeof(IRepository<>), typeof(Repository<>));

            services.AddSingleton(typeof(IMongoContext), x => new MongoContext(
                Configuration.GetConnectionString("Mongo:ConnectionString"), 
                Configuration.GetConnectionString("Mongo:Database")));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            // Serve the files Default.htm, default.html, Index.htm, Index.html
            // by default (in this order), i.e., without having to explicitly qualify the URL.
            // For example, if your endpoint is http://localhost:3012/ and wwwroot directory
            // has Index.html, then Index.html will be served when someone hits
            // http://localhost:3012/
            app.UseDefaultFiles();

            app.UseStaticFiles();
            app.UseMvc();
            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=Home}/{action=Index}/{id?}");
            //});
        }
    }
}
