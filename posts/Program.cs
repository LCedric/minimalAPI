using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);


/*
var corsPolicy = "AllowAll";

builder.Services.AddCors(options =>
{
    options.AddPolicy(corsPolicy, builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});
*/


builder.Services.AddFastEndpoints();
/*
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option => { 
    option.SwaggerDoc("v1", new OpenApiInfo { Title="Post", Version="v1" });
});
*/
var app = builder.Build();


app.UseFastEndpoints(); 
//app.UseCors(corsPolicy);

//app.UseSwagger();
//app.UseSwaggerUI(c =>
//{
//    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
//});


app.MapGet("/", () => "Hello World!");

app.Run();
