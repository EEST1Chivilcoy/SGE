using PaginaEEST1.Data;
using PaginaEEST1.Services;
using Microsoft.EntityFrameworkCore;
using PaginaEEST1.Components;
// Entra ID
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using AntDesign;
using ImageService = PaginaEEST1.Services.ImageService;
using Microsoft.Extensions.Options;

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

            // Entra ID con sincronizaci�n de usuario
            builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
                .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAd"))
                .EnableTokenAcquisitionToCallDownstreamApi()
                .AddInMemoryTokenCaches();

            // Configurar el evento OnTokenValidated para sincronizar el usuario
            builder.Services.Configure<OpenIdConnectOptions>(OpenIdConnectDefaults.AuthenticationScheme, options =>
            {
                options.Events = new OpenIdConnectEvents
                {
                    OnTokenValidated = async context =>
                    {
                        if (context.Principal != null && context.Principal.Identity is ClaimsIdentity claimsIdentity && claimsIdentity.IsAuthenticated)
                        {
                            // Obtener el servicio de usuario
                            var userService = context.HttpContext.RequestServices.GetRequiredService<IUserService>();

                            // Sincronizar el usuario con la base de datos
                            await userService.SynchronizeUser(claimsIdentity);
                        }
                    }
                };
            });

            // Agregar controladores con vistas y Entra ID UI
            builder.Services.AddControllersWithViews()
                .AddMicrosoftIdentityUI();

            // Agregar autorización
            builder.Services.AddAuthorization();

            // Servicios
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();
            builder.Services.AddHostedService<InitData>();
            builder.Services.AddAntDesign();

            // Registrar los Servicios Hospedados personalizados
            builder.Services.AddHostedService<RequestsHostedService>();

            // Registrar los servicios personalizados
            builder.Services.AddScoped<IItemService, ItemService>();
            builder.Services.AddScoped<IComputerService, ComputerService>();
            builder.Services.AddScoped<IQRService, QRService>();
            builder.Services.AddScoped<IRequestService, RequestService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IAreaService, AreaService>();
            builder.Services.AddScoped<IImageService, ImageService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<ILoanService, LoanService>();

            // Registrar los servicios Singleton


            // Cache
            builder.Services.AddMemoryCache();

            // Configurar la localización
            builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

            builder.Services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new List<CultureInfo>
                {
                    new CultureInfo("es-AR")
                };

                options.DefaultRequestCulture = new RequestCulture("es-AR");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });

            var app = builder.Build();

            // Configurar el pipeline de solicitud HTTP
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            //Localizacion AntDesign
            LocaleProvider.SetLocale("es-Es");

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAntiforgery();

            // Añadir el middleware de localización
            var localizationOptions = app.Services.GetService<IOptions<RequestLocalizationOptions>>()?.Value;

            // Middleware de autenticación y autorización
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();
            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}