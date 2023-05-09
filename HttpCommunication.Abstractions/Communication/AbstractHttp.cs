using System.Threading.Tasks;

namespace Staticsoft.HttpCommunication.Abstractions;

public class AbstractHttp : Http
{
    readonly HttpRequestFactory Factory;
    readonly HttpRequestExecutor Executor;
    readonly HttpResponseParser Parser;

    public AbstractHttp(HttpRequestFactory factory, HttpRequestExecutor executor, HttpResponseParser parser)
    {
        Factory = factory;
        Executor = executor;
        Parser = parser;
    }

    public Task<HttpResult<T>> Request<T>(HttpMethod method, string path)
        => ExecuteRequest<T>(Factory.Create(method, path));

    public Task<HttpResult<T>> Request<T>(HttpMethod method, string path, object body)
        => ExecuteRequest<T>(Factory.Create(method, path, body));

    async Task<HttpResult<T>> ExecuteRequest<T>(HttpRequest request)
    {
        var response = await Executor.Execute(request);
        return new HttpResult<T>(response, Parser);
    }
}
