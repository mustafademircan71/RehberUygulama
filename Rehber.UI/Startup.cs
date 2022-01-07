using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rehber.UI
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
            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            services.AddCors();

            services.AddSession();
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
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Kullanici}/{action=Giris}");

                //endpoints.MapControllerRoute(
                //    name: "giris",
                //    pattern: "giris",
                //    defaults: new { controller = "Kullanici", action = "Giris" });

                endpoints.MapControllerRoute(
                    name: "girisUygulama",
                    pattern: "ana-sayfa",
                    defaults: new { controller = "Home", action = "Index" });

                endpoints.MapControllerRoute(
                    name: "rehberlLste",
                    pattern: "liste",
                    defaults: new { controller = "Kullanici", action = "Liste" });

                endpoints.MapControllerRoute(
                    name: "rehberEkle",
                    pattern: "ekle",
                    defaults: new { controller = "Kullanici", action = "Ekle" });

                endpoints.MapControllerRoute(
                    name: "cikis",
                    pattern: "cikis",
                    defaults: new { controller = "Kullanici", Action = "Cikis" });

                endpoints.MapControllerRoute(
                    name: "kayýtOl",
                    pattern: "kayýt-ol",
                    defaults: new { controller = "Kullanici", action = "KayýtOl" });

                endpoints.MapControllerRoute(
                    name: "testLink",
                    pattern: "test",
                    defaults: new { controller = "Kullanici", action = "Test" });

            });
        }
    }
}
