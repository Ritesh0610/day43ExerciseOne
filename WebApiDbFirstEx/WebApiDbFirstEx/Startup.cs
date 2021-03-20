using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiDbFirstEx.Models;

namespace WebApiDbFirstEx
{
    public class Startup
    {
        readonly string allowedOrigins = "allowedSelectedOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            services.AddControllers().AddJsonOptions(options=> {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
                options.JsonSerializerOptions.DictionaryKeyPolicy = null;            
            });

            services.AddDbContext<StudentDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("StudentDbContext")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(options=> {
                options.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod();
            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
