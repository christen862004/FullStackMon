using FullStackMon.Filtters;
using FullStackMon.Models;
using FullStackMon.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FullStackMon
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //build in service
            //alread register
            //need to register
            // Add services to the container.Day8
            builder.Services.AddControllersWithViews();
            
            #region Global Filter Attribute
            //builder.Services.AddControllersWithViews(options =>
            //{
            //    //create global attrib
            //    options.Filters.Add(new HandelErrorAttribute());
            //});
            #endregion

            builder.Services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });//--------midleware
            builder.Services.AddDbContext<ITIContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
            });
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 5;
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;

            }).AddEntityFrameworkStores<ITIContext>();
            //custom service
            //builder.Services.AddScoped<IEmployeeRepository, EmpMemeoryREposirory>();//register
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();//register

            //builder.Services.AddScoped<IRepository<Employee>, EmployeeRepository>();//register
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();

            var app = builder.Build();
            #region Custom inline Midelware
            //app.Use(async (httpContext, next) =>
            //{
            //    //if(httpContext.Request.ur)
            //   await httpContext.Response.WriteAsync("1- Middelware 1 \n");
            //    //....
            //   await next.Invoke();
            //    //...
            //   // await httpContext.Response.WriteAsync("1-1 Middelware 1 \n");

            //});
            //app.Use(async (httpContext, next) =>
            //{
            //    //if(httpContext.Request.ur)
            //    //await httpContext.Response.WriteAsync("2- Middelware 2 \n");
            //    //....
            //    await next.Invoke();
            //    //...
            //    await httpContext.Response.WriteAsync("2-2 Middelware 2 \n");

            //});
            //app.Run(async (httpContex) =>
            //{
            //    await httpContex.Response.WriteAsync("3- terminate \n");
            //});

            #endregion

            #region built in PipleLine
            //Configure the HTTP request pipeline. Day2 ,3 middleware

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();//image/1.png & style.css

            app.UseRouting();//mapping 
            
            app.UseSession();//----------------

            app.UseAuthorization();
            
            //app.MapControllerRoute(
            //  name: "Route1",
            //  pattern: "{controller}/{action}", 
            //  defaults: new {Controller="Route"});//one sinment ==>litter r1
            ////r1/ahmed
            //r1/ahmed/12
            //app.MapControllerRoute(
            // name: "Route2",
            //  pattern: "r1/{name}/{age:int:range(10,60)}",

            // defaults: new { Controller = "Route", action = "Method2" });//one sinment ==>litter r1

            //DEfault route /Controller/Action
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Employee}/{action=Index}/{id?}");//staff (define route &execute)
            #endregion


            app.Run();
        }
    }
}
