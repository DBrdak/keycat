using KeyCat.CLI.Application;
using KeyCat.Data;
using Microsoft.Extensions.DependencyInjection;

namespace KeyCat.CLI;

internal class Program
{
    public static async Task Main(string[] args)
    {
        var services = new ServiceCollection();

        ConfigureServices(services);

        var serviceProvider = services.BuildServiceProvider();

        await serviceProvider.GetService<App>()?.Run(args);
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddTransient<App>();
        services.AddTransient<HotkeyRepository>();
    }
}