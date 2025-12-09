using Microsoft.Build.Framework;
using System.Security.Cryptography.X509Certificates;

namespace MVCToDoWebApp
{
    public class Program
    {
        public static ToDoRepo repo = new ToDoRepo(); 
        //i know this is a bad but i don't know where else to put the repo since we didn't do it in class

        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //my DI
            builder.Services.AddTransient<Models.IToDoViewModels, Models.ToDoViewModels>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
