using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MyCompany
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //add MVC
            services.AddControllersWithViews()
                //.NET Core 3.0 compatibility
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0).AddSessionStateTempDataProvider();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //����� �� �������� ������

            // "debug mode" on :)
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseRouting();

            // ������ css, js �����
            app.UseStaticFiles();

            //���� �������������
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}