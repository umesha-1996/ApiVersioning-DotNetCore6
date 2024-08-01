using Microsoft.AspNetCore.Mvc.Versioning;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApiVersioning(options =>
{
    // When no API version is specified in the request, assume the default version.
    options.AssumeDefaultVersionWhenUnspecified = true;
    // Set the default API version to 1.0.
    options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
    // Report the supported API versions in the response headers.
    options.ReportApiVersions = true;
    // Configure how API versioning should be read from the request
    options.ApiVersionReader = ApiVersionReader.Combine(
        // Read the API version from the query string, e.g., ?api-version=1.0
        //new QueryStringApiVersionReader("api-version"),
        // Read the API version from a custom request header, e.g., x-version: 1.0
        new HeaderApiVersionReader("x-version")//,
        // Read the API version from the media type, e.g., application/json; ver=1.0
       // new MediaTypeApiVersionReader("ver")
        );
});

builder.Services.AddVersionedApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
