using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Owin;
//using Microsoft.Owin.Security.Cookies;
using Utilitarios.Helpers.Authorization;
using System;
using Owin; 

[assembly: OwinStartup(typeof(Frotend.ArchivoCentral.Micetur.Startup))]

namespace Frotend.ArchivoCentral.Micetur
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
            services.AddControllersWithViews();
            services.AddHttpContextAccessor();
        

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


           // app.UseCors(Microsoft.Owin.CorsOptions.AllowAll);
            // app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            //app.UseCookieAuthentication(new CookieAuthenticationOptions
            //{
            //    AuthenticationType = AppAuthenticationType.ApplicationCookie,
            //    LoginPath = new PathString("/authorization/signin"),
            //    CookieName = AppAuthenticationType.CookieName,
            //    CookieHttpOnly = true,
            //    SlidingExpiration = true,
            //    ExpireTimeSpan = TimeSpan.FromDays(1)
            //});


        }
    }
}
