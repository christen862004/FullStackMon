namespace FullStackMon
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.Day8
            builder.Services.AddControllersWithViews();
                   
            builder.Services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });//--------midleware


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

            app.UseRouting();
            
            app.UseSession();//----------------

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Department}/{action=Index}/{id?}");
            #endregion


            app.Run();
        }
    }
}
