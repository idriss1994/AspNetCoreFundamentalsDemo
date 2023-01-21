namespace AspNetCoreFundamentalsDemo
{
    public static class MyConfigServiceCollectionExtensions
    {
        public static IServiceCollection AddConfig(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<PositionOptions>(
                configuration.GetSection(PositionOptions.Position));
            services.Configure<ColorOptions>(
                configuration.GetSection(ColorOptions.Color));

            return services;
        }

        public static IServiceCollection AddMyDependencyGroup(this IServiceCollection services)
        {
            services.AddScoped<IMyDependency, MyDependency>();
            services.AddScoped<IMyDependency2, MyDependency2>();

            return services;
        }
    }

    // Class for demo
    public class PositionOptions 
    {
        public static string Position { get; set; } = string.Empty;
    }
    public class ColorOptions
    {
        public static string Color { get; set; } = string.Empty;
    }
}
