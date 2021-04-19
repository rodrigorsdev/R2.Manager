using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using R2.Core.Auth;
using R2.Core.Configuration;
using R2.Manager.Identity.Api.Configuration;

namespace R2.Manager.Identity.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IHostEnvironment hostEnvironment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(hostEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{hostEnvironment.EnvironmentName}.json", true, true)
                .AddEnvironmentVariables();

            if (hostEnvironment.IsDevelopment())
                builder.AddUserSecrets<Startup>();

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentityConfiguration(Configuration);

            services.AddJwtConfiguration(Configuration);

            services.AddApiConfiguration(true);

            services.AddSwaggerConfiguration(
               "v1",
               "R2 Manager Identity API",
               "R2 Manager Solution",
               "Rodrigo Oliveira",
               "rodrigo.soliveira2322@gmail.com",
               "MIT",
               "https://opensource.org/licenses/MIT");
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwaggerConfiguration("/swagger/v1/swagger.json", "v1");

            app.UseApiConfiguration(env, true);
        }
    }
}
