using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Staticsoft.TestServer;

public class TestStartup
{
    public void ConfigureServices(IServiceCollection services) => services
        .AddControllers();

    public void Configure(IApplicationBuilder app, IWebHostEnvironment _) => app
        .UseRouting()
        .UseEndpoints(endpoints => endpoints.MapControllers());
}
