namespace LangProwess.Web.Infrastructure;

public static class FallbackExtensions
{
	public static IEndpointConventionBuilder MapFallbackWithApi(this IEndpointRouteBuilder app)
		=> app.MapFallback(CreateRequestDelegate(app, "index.html", null));

	private static RequestDelegate CreateRequestDelegate(
			IEndpointRouteBuilder endpoints,
			string filePath,
			StaticFileOptions? options = null)
	{
		var app = endpoints.CreateApplicationBuilder();
		app.Use(next => context =>
		{
			string path = context.Request.Path.ToString();
			if (path.StartsWith("/api/") || path == "/api")
			{
				context.Response.StatusCode = 404;
				return Task.CompletedTask;
			}
			else
			{
				context.Request.Path = "/" + filePath;

				context.SetEndpoint(null);

				return next(context);
			}
		});

		if (options is null)
			app.UseStaticFiles();
		else
			app.UseStaticFiles(options);

		return app.Build();
	}
}
