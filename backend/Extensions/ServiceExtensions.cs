public static class ServiceExtensions
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<IPortfolioService, PortfolioService>();
        // ... outros registros
    }
}