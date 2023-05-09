using Microsoft.AspNetCore.Mvc;

namespace Staticsoft.TestServer.Controllers;

[ApiController]
public class TestController
{
    [HttpGet("/TestGetRequest")]
    public Response TestRequest()
        => new() { Text = "TestResponse" };

    [HttpPost("/TestPostRequest")]
    public Response TestPostRequest([FromBody] PostRequestBody body)
        => new() { Text = body.Text };
}
