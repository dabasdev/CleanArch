using System.Windows;
using CleanArch.Persistence;
using CleanArch.Persistence.Ioc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WpfApp;

/// <summary>
///     Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public App()
    {
        AppHost = Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
                services.AddPersistenceServices();
                services.AddScoped(typeof(MainWindow));
            })
            .Build();
    }

    public static IHost? AppHost { get; set; }


    protected override async void OnStartup(StartupEventArgs e)
    {
        await AppHost!.StartAsync();

        var main = AppHost?.Services.GetRequiredService<MainWindow>();

        var db = AppHost?.Services.GetRequiredService<AppDbContext>();

        await db!.Database.EnsureCreatedAsync();

        main?.ShowDialog();
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        await AppHost!.StopAsync();
    }
}