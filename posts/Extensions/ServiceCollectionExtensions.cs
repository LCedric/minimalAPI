using FastEndpoints.Swagger;
using NSwag.Generation.AspNetCore;

namespace Web.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddSwaggerDocWithVersions(this IServiceCollection services)
    {
        services
            .SwaggerDocument(o =>
            {
                o.MaxEndpointVersion = 1;
                o.ExcludeNonFastEndpoints = true;
                o.EnableJWTBearerAuth = false;
                o.ShortSchemaNames = true;
                o.AutoTagPathSegmentIndex = 1;
                o.DocumentSettings = s => SetDefaults(s, 1);
            })
            .SwaggerDocument(o =>
            {
                o.MaxEndpointVersion = 2;
                o.ExcludeNonFastEndpoints = true;
                o.EnableJWTBearerAuth = false;
                o.ShortSchemaNames = true;
                o.AutoTagPathSegmentIndex = 1;
                o.DocumentSettings = s => SetDefaults(s, 2);
            });
    }

    private static void SetDefaults(AspNetCoreOpenApiDocumentGeneratorSettings s, int version)
    {
        s.Title = $"FastEndpoints api v{version}";
        s.DocumentName = $"v{version}";
        s.Version = $"v{version}.0";
        s.GenerateEnumMappingDescription = true;
    }
}