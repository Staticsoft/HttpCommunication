using Microsoft.Extensions.DependencyInjection;
using Staticsoft.HttpCommunication.Abstractions;

namespace Staticsoft.HttpCommunication.Json;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection UseJsonHttpCommunication(this IServiceCollection services) => services
        .AddSingleton<HttpRequestFactory, JsonHttpRequestFactory>()
        .AddSingleton<HttpResponseParser, JsonHttpResponseParser>()
        .AddSingleton<HttpRequestExecutor, HttpClientRequestExecutor>()
        .AddSingleton<Http, AbstractHttp>();
}
