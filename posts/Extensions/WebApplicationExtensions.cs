using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.AspNetCore.Rewrite;
using NSwag.AspNetCore;

namespace Web.Extensions;

public static class WebApplicationExtensions
{
    public static void UseRedirectionOptions(this WebApplication app)
    {
        app.UseHttpsRedirection();
        var option = new RewriteOptions();
        option.AddRedirect("^$", "swagger");
        app.UseRewriter(option);
    }

    public static void UseFastEndpointsAndConfigurations(this WebApplication app)
    {
        if (app.Environment.IsProduction())
        {
            app.UseDefaultExceptionHandler(); // Sanitize exceptions so we dont leak internal code exceptions to the api.
        }

        app.UseFastEndpoints(c =>
        {
            c.Versioning.DefaultVersion = 1;
            c.Versioning.Prefix = "v";
            c.Versioning.PrependToRoute = true;
            c.Endpoints.RoutePrefix = "api";
            c.Endpoints.ShortNames = false;
        });
    }

    public static void UseSwaggerUi3WithOpenApiSpec(this WebApplication app)
    {
        const string customStylesheetPath = "/swagger-ui/SwaggerDark.css";

        Action<SwaggerUi3Settings>? uiConfig = c =>
        {
            c.DocExpansion = "list";
            c.DefaultModelsExpandDepth = 2;
            c.DefaultModelExpandDepth = 2;
            c.CustomStylesheetPath = customStylesheetPath;
        };
        
        app.UseSwaggerGen(uiConfig: uiConfig);

        app.MapGet(customStylesheetPath, async (CancellationToken cancellationToken) =>
        {
            var css = await File.ReadAllBytesAsync("Styles/SwaggerDark.css", cancellationToken);
            return Results.File(css, "text/css");
        }).ExcludeFromDescription();
    }
}
