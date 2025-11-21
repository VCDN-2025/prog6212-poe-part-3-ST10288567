using ContractMonthlyClaimsSystem_st10288567_3.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ContractMonthlyClaimsSystem_st10288567_3
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // WebApplication.CreateBuilder sets up configuration, logging, and DI by default,
            // allowing the application to initialise its core components efficiently (Microsoft, 2024a).
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container using the built-in dependency injection system,
            // which Microsoft (2024b) notes is essential for separation of concerns.
            builder.Services.AddControllersWithViews();

            // Register ClaimService as a singleton so that all controllers share the same in-memory data store.
            // Microsoft (2024c) explains that singleton services maintain a single instance throughout app lifetime.
            builder.Services.AddSingleton<ClaimService>();

            // Build the web application using the configured builder.
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            // In production, Microsoft (2024d) recommends enabling HSTS and exception handling
            // to improve security and error management.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            // Redirect all HTTP requests to HTTPS for improved transport security (Microsoft, 2024e).
            app.UseHttpsRedirection();

            // Enables serving static assets such as images, CSS, and JavaScript (Microsoft, 2024f).
            app.UseStaticFiles();

            // Adds routing middleware, allowing the application to map incoming requests to controllers.
            // According to Microsoft (2024g), this is required for MVC-style endpoint resolution.
            app.UseRouting();

            // Enables the authorization middleware, although no custom policies are applied here.
            // Microsoft (2024h) emphasises keeping this in the pipeline for security scalability.
            app.UseAuthorization();

            // Configures the default MVC route pattern for controller/action/id.
            // This conventional routing pattern is widely used in MVC applications (Microsoft, 2024i).
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            // Runs the application and begins listening for HTTP requests (Microsoft, 2024j).
            app.Run();
        }
    }
}
