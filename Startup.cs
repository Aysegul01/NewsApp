using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NewsApp.Models;
using NewsApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static NewsApp.Service.Sevice;

namespace NewsApp
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
            services.AddDbContext<NewsDbContext>(options =>
          options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddControllersWithViews();
            services.AddControllersWithViews();
            // Servisleri ekleyin
           // services.AddSingleton<CacheService>();
           // services.AddSingleton<UpdateService>();

            // Timer'� ba�lat�n
           // services.BuildServiceProvider().GetService<UpdateService>().StartUpdateTimer();


            // Dependency Injection
            services.AddScoped<INewsService, NewsService>();
            // Di�er servisler...

        }

        


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=news}/{action=Index}/{id?}");
            });
        }
    }
}


