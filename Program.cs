using Microsoft.EntityFrameworkCore;
using Vinsjansen.Data;
using Vinsjansen.Services;

namespace Vinsjansen
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // var connectionString = Environment.GetEnvironmentVariable("AZURE_SQL_CONNECTIONSTRING");
            // Unsafe way of getting the connection string, but it works for now.
            var connectionString = "Server=tcp:vinsjansen-server.database.windows.net,1433;Initial Catalog=vinsjansen-database;Persist Security Info=False;User ID=vinsjansen-server-admin;Password=2444H3V200VP62N1$;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

			// Add services to the container.
			builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
			builder.Services.AddControllers();
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
			builder.Services.AddTransient<TicketService>();
            builder.Services.AddDbContextFactory<VinsjansenDbContext>((DbContextOptionsBuilder options) => 
            options.UseSqlServer(connectionString));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
				app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Blazor API V1");
                });

				app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.MapControllers();

            app.Run();
        }
    }
}