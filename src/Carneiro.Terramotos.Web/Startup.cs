using System;
using Carneiro.Terramotos.Web.Data;
using Carneiro.Terramotos.Web.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Carneiro.Terramotos.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public IWebHostEnvironment WebHostEnvironment { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            Configuration = configuration;
            WebHostEnvironment = webHostEnvironment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            IMvcBuilder mvcBuilder = services.AddControllersWithViews();

#if DEBUG
            mvcBuilder.AddRazorRuntimeCompilation();
#endif

            services.AddDbContext<EarthQuakeDbContext>(options =>
            {
                DatabaseOptions dbOptions = Configuration.GetSection("Database").Get<DatabaseOptions>();

                options.EnableSensitiveDataLogging(dbOptions.EnableSensitiveDataLogging);
                options.EnableDetailedErrors(dbOptions.EnableDetailedErrors);
                options.UseSqlServer(Configuration.GetConnectionString("DatabaseContext"), providerOptions =>
                 {
                     providerOptions.CommandTimeout(dbOptions.Timeout);
                     providerOptions.EnableRetryOnFailure(
                         maxRetryCount: dbOptions.Failure.Retries,
                         maxRetryDelay: TimeSpan.FromSeconds(dbOptions.Failure.Seconds),
                         errorNumbersToAdd: null);
                 });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
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
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}