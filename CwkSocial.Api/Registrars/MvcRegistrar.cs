
using Asp.Versioning;

namespace CwkSocial.Api.Registrars
{
    public class MvcRegistrar : IWebApplicationBuilderRegistrar
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
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

            builder.Services.AddEndpointsApiExplorer();
        }
    }
}
