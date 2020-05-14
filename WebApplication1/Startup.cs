using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using WebApplication1.Models;
using WebApplication1.Repositry;

namespace WebApplication1
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddTransient<IEmployeesRepostiry, EmployeesRepositry>();
            services.AddIdentity<ApplicationUser, IdentityRole>(a =>
            {
                a.Password.RequireDigit = false;
                a.Password.RequireLowercase = false;
                a.Password.RequireDigit = false;
                a.Password.RequiredLength = 6;
                a.Password.RequireUppercase = false;
                a.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<CompanyContext>();

            services.AddAuthentication()
                .AddCookie()
                .AddJwtBearer(a =>
                {
                    a.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                    {
                        ValidIssuer = this.Configuration["Token:Issuar"],
                        ValidAudience = this.Configuration["Token:Audius"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.Configuration["Token:key"]))
                    };
                });

                
            services.AddSwaggerDocument();

            services.AddDbContext<CompanyContext>(a =>
            {
                a.UseSqlServer(this.Configuration.GetConnectionString("con"));
            });
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
           

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseOpenApi(); 
            app.UseSwaggerUi3(); 
        
           
            app.UseRouting();
            app.UseStaticFiles();
            app.UseNodeModules();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("Default",
                    "{controller}/{action}/{id?}",
                    new { controller = "Home", action = "Index" });
            });
        }
    }
}
