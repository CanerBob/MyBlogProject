namespace MyBlog.Service.Extensions;
public static class ServiceLayerExtensions
{
    public static IServiceCollection LoadServiceLayerExtensions(this IServiceCollection services)
    {
        services.AddScoped<IArticleService, ArticleService>();

        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        return services;
    }
}
