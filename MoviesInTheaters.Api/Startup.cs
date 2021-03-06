using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemasInTheaters.Shared.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MoviesInTheaters.Api.Internal;
using MoviesInTheaters.Data.Context;
using MoviesInTheaters.Shared.Services;
using MoviesInTheaters.Shared.UnitOfWork;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MoviesInTheaters.Api
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
            services.AddControllers();  
            services.AddDbContext<MovieDbContext>(options => options.UseMySql(Environment.GetEnvironmentVariable("MOVIE_APP_DB_CONNECTION")), ServiceLifetime.Scoped);
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICinemaService,CinemaService>();
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<ICinemaMovieService, CinemaMovieService>();

            services.AddControllersWithViews(options =>
            {
                options.Filters.Add(new ResponseWrapperFilter());

            }).AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver { NamingStrategy = new CamelCaseNamingStrategy() };
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });


            services.AddAutoMapper(typeof(Startup));
         
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
            });
    
        }
    }
}
