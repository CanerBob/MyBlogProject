using MyBlog.Service.Helpers.Images;

namespace MyBlog.Service.Extensions;
public static class ServiceLayerExtensions
{
	public static IServiceCollection LoadServiceLayerExtensions(this IServiceCollection services)
	{
		services.AddScoped<IArticleService, ArticleService>();

		services.AddScoped<ICategoryService, CategoryService>();

		services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

		services.AddScoped<IImageHelper, ImageHelper>();

		services.AddScoped<IUserService, UserService>();

		services.AddAutoMapper(Assembly.GetExecutingAssembly());

		services.AddControllersWithViews().AddFluentValidation(opt =>
		{
			opt.RegisterValidatorsFromAssemblyContaining<ArticleValidator>();
			opt.DisableDataAnnotationsValidation = true;
			opt.ValidatorOptions.LanguageManager.Culture = new CultureInfo("tr");
		});
		return services;
	}
}
