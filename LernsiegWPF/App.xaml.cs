using System.Windows;
using LernsiegDatabase;
using LernsiegViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LernsiegWPF;

public partial class App
{
    private readonly IHost _host;

    public App() =>
        _host = Host.CreateDefaultBuilder()
            .ConfigureServices((ctx, services) => ConfigureServices(ctx.Configuration, services))
            .Build();

    private static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
    {
        services.AddSingleton<MainWindow>();
        services.AddSingleton<MainViewModel>();
        services.AddDbContext<LernsiegContext>(
            x => x.UseSqlite(configuration.GetConnectionString("sqlite"))
        );
    }

    protected override async void OnStartup(StartupEventArgs e)
    {
        await _host.StartAsync();

        var context = _host.Services.GetRequiredService<LernsiegContext>();
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
        DatabaseSeeder.Seed(context);

        var mainWindow = _host.Services.GetRequiredService<MainWindow>();
        mainWindow.Show();
        base.OnStartup(e);
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        using (_host)
            await _host.StopAsync();
        base.OnExit(e);
    }
}
