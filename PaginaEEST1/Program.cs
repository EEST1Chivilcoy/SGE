using PaginaEEST1.Data;
using PaginaEEST1.Services;
using Microsoft.EntityFrameworkCore;
using PaginaEEST1.Components;

namespace PaginaEEST1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration["ConnectionString"];
            var serverVersion = ServerVersion.AutoDetect(connectionString);

            builder.Services.AddDbContextFactory<PaginaDbContext>(options =>
                options.UseMySql(connectionString, serverVersion)
                       .LogTo(Console.WriteLine, LogLevel.Information)
                       .EnableSensitiveDataLogging() // Muestra datos sensibles en los logs (solo para desarrollo)
                       .EnableDetailedErrors()       // Detalla los errores en los logs
            );

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();
            builder.Services.AddHostedService<InitData>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
