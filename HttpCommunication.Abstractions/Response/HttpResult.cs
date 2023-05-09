using System;

namespace Staticsoft.HttpCommunication.Abstractions;

public class HttpResult
{
    public readonly int StatusCode;

    public HttpResult(HttpResponse response)
        => StatusCode = response.StatusCode;
}

public class HttpResult<T> : HttpResult
{
    public T Body
        => LazyBody.Value;

    readonly Lazy<T> LazyBody;

    public HttpResult(HttpResponse response, HttpResponseParser parser) : base(response)
        => LazyBody = new Lazy<T>(() => parser.Parse<T>(response.Body));
}
