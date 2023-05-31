using Web.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddFastEndpoints();
builder.Services.AddSwaggerDocWithVersions();


var app = builder.Build();
app.UseAuthorization();
app.UseFastEndpointsAndConfigurations();
app.UseSwaggerUi3WithOpenApiSpec();
app.UseRedirectionOptions();

app.Run();