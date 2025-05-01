using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using CwkSocial.Api.Controllers.Options;

namespace CwkSocial.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true; // Adds a header to responses with the supported API versions
                config.ApiVersionReader = new UrlSegmentApiVersionReader(); // Reads the version from the URL

            })             
                .AddApiExplorer(config =>
                {
                    config.GroupNameFormat = "'v'VVV"; // Version format
                    config.SubstituteApiVersionInUrl = true;
                });

            builder.Services.AddSwaggerGen();

            builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();
            builder.Services.AddEndpointsApiExplorer();

            var app = builder.Build();


            app.UseHttpsRedirection();

            app.UseAuthorization();

            if(app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                            description.GroupName.ToUpperInvariant());

                    }
                });
            }
            app.MapControllers();

            app.Run();
        }
    }
}
