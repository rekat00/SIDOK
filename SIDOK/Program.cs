using SIDOK.Repository;
using SIDOK.Repository.Interfaces;
using SIDOK.Services;
using SIDOK.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SIDOK.Data;


namespace SIDOK
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<SIDOK1Context>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("SIDOK1Context") ?? throw new InvalidOperationException("Connection string 'SIDOK1Context' not found.")));

            builder.Services.AddScoped<IDokterRepository, DokterRepository>();
            builder.Services.AddScoped<IDokterService, DokterService>();

            builder.Services.AddScoped<IPoliRepository, PoliRepository>();
            builder.Services.AddScoped<IPoliServices, PoliService>();

            builder.Services.AddScoped<IJadwalRepository, JadwalRepository>();
            builder.Services.AddScoped<IJadwalService, JadwalService>();

            builder.Services.AddScoped<ISpesialisasiRepository, SpesialisasiRepository>();
            builder.Services.AddScoped<ISpesialisasiService, SpesialisasiService>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

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