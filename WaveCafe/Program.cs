using Microsoft.EntityFrameworkCore;
using WaveCafe.DAL;

namespace WaveCafe
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<AppDbContext>(opt =>
            opt.UseSqlServer("server=DESKTOP-GTVND9D;database=WaveCafe;trusted_connection=true;Encrypt=false")
            );

            var app = builder.Build();

            app.UseStaticFiles();


            app.MapControllerRoute(
              name: "areas",
              pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
            );


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"
                );

            app.Run();
        }
    }
}
