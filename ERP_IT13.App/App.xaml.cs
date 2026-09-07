using ERP_IT13.Infrastructure;
using ERP_IT13.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace ERP_IT13.App
{
    public partial class App : Application
    {
        private IHost? _host;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            _host = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration((context, config) =>
                {
                    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                })
                .ConfigureServices((context, services) =>
                {
                    var connectionString = context.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
                    services.AddDbContext<ERPDbContext>(options =>
                        options.UseSqlServer(connectionString));

                    services.AddScoped<IAuthService, AuthService>();

                    services.AddSingleton<MainWindow>();
                })
                .Build();

            _host.Start();

            using (var scope = _host.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<ERPDbContext>();
                var auth = scope.ServiceProvider.GetRequiredService<IAuthService>();
                SeedData.InitializeAsync(db, auth).GetAwaiter().GetResult();
            }

            var mainWindow = _host.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _host?.Dispose();
            base.OnExit(e);
        }
    }
}

