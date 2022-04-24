using Staticsoft.HttpCommunication.Abstractions;
using Staticsoft.Testing;
using Staticsoft.TestServer;
using System.Threading.Tasks;
using Xunit;

namespace Staticsoft.HttpCommunication.Tests
{
    public abstract class HttpTests<TSPF> : TestBase<TSPF>
        where TSPF : ServiceProviderFactory, new()
    {
        Http Http
            => Get<Http>();

        [Fact]
        public async Task CanMakeGetRequest()
        {
            var result = await Http.Request<Response>(HttpMethod.Get, "/TestGetRequest");
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("TestResponse", result.Body.Text);
        }

        [Fact]
        public async Task CanMakePostRequestWithRequestBody()
        {
            var result = await Http.Request<Response>(HttpMethod.Post, "/TestPostRequest", new PostRequestBody { Text = "TestResponse" });
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("TestResponse", result.Body.Text);
        }

        [Fact]
        public async Task CanMakeFailingRequest()
        {
            var result = await Http.Request<Response>(HttpMethod.Get, "/NonExistingEndpoint");
            Assert.Equal(404, result.StatusCode);
        }
    }
}
