using Microsoft.Extensions.DependencyInjection;
using Staticsoft.HttpCommunication.Json;
using Staticsoft.Serialization.Net;
using Staticsoft.Testing;
using Staticsoft.TestServer;

namespace Staticsoft.HttpCommunication.Tests
{
    public class JsonHttpTests : HttpTests<JsonHttpDependencies> { }

    public class JsonHttpDependencies : IntegrationServicesBase<TestStartup>
    {
        protected override IServiceCollection Services => base.Services
            .UseJsonHttpCommunication()
            .UseSystemJsonSerializer();
    }
}
