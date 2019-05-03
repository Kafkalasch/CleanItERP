using CleanItERP.Services;
using CleanItERP.DataModel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CleanItERP
{
    public class Startup
    {
        private const string AllowAnyOriginPolicy = "AllowAnyOrigin";
        private IHostingEnvironment Environment {get;}
        public Startup(IHostingEnvironment env)
        {
            Environment = env;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });

            services.AddDbContext<CleanItERPContext>(
                options => options.UseSqlite("DataSource = sqliteDatabase.db")
            );

            services.AddScoped<IOrderListService, OrderListService>();
            services.AddScoped<IBranchListService, BranchListService>();
            services.AddScoped<ITextileStateListService, TextileStateListService>();
            services.AddScoped<ITextileTypeListService, TextileTypeListService>();

            if(Environment.IsDevelopment()){
                services.AddCors(options =>
                    {
                        options.AddPolicy(
                            AllowAnyOriginPolicy,
                            policy => policy.AllowAnyOrigin());
                    });
            }

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCors(AllowAnyOriginPolicy);
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
                app.UseHttpsRedirection();
            }

            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc();

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseProxyToSpaDevelopmentServer("http://localhost:8080");
                }
            });

        }
    }
}
