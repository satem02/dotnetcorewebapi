using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business;
using Business.Base;
using Business.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Models;
using Swashbuckle.AspNetCore.Swagger;

namespace EndPoint {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            services.AddMvc ();
            
            services.Configure<Settings> (s => {
                s.ConnectionString = Configuration.GetSection ("MongoConnection:ConnectionString").Value;
                s.Database = Configuration.GetSection ("MongoConnection:Database").Value;
            });

            services.AddSwaggerGen (c => {
                c.SwaggerDoc ("v1", new Info { Title = "ASP.NET Core RESTful API", Version = "v1" });
            });

            services.AddDbContext<DataContext> (s => {
                s.UseSqlServer (Configuration.GetConnectionString ("DbConnection"));
                s.UseQueryTrackingBehavior (QueryTrackingBehavior.NoTracking);
            });

            services.AddScoped (typeof (IRepository<>), typeof (Repository<>));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            }

            app.UseMvc ();

            app.UseSwagger ();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI (c => {
                c.SwaggerEndpoint ("/swagger/v1/swagger.json", "ASP.NET Core RESTful API v1");
            });
        }
    }
}