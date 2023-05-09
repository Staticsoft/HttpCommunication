using Microsoft.Extensions.DependencyInjection;
using Staticsoft.HttpCommunication.Json;
using Staticsoft.Serialization.Net;

namespace Staticsoft.HttpCommunication.Tests;

public class JsonHttpTests : HttpTests
{
    protected override IServiceCollection ClientServices(IServiceCollection services) => base.ClientServices(services)
        .UseJsonHttpCommunication()
        .UseSystemJsonSerializer();
}
