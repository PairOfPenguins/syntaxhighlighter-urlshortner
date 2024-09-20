using Microsoft.EntityFrameworkCore;
using pet2.Controllers;
using pet2.Data;
using pet2.Services.Implementations;
using pet2.Services;

namespace pet2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("NotesPortal")));

            builder.Services.AddHttpClient();

            builder.Services.AddScoped<IUrlShortenerService, UrlShortenerService>();

            var app = builder.Build();


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
                pattern: "{controller=Home}/{action=Index}");

            app.MapControllerRoute(
                name: "share",
                pattern: "{id:guid}",
                defaults: new { controller = "Share", action = "NoteShare" });

            app.Run();
        }
    }
}
