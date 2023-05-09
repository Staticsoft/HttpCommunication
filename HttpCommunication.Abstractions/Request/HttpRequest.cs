using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Staticsoft.HttpCommunication.Abstractions;

public record HttpRequest
{
    public readonly HttpMethod Method;
    public readonly string Path;
    public readonly HttpBody Body;

    public IReadOnlyDictionary<string, string> Headers { get; init; } = ImmutableDictionary<string, string>.Empty;

    public HttpRequest(HttpMethod method, string path, HttpBody body)
    {
        Method = method;
        Path = path;
        Body = body;
    }

    public HttpRequest WithHeader(string name, string value)
        => this with { Headers = AddHeader(Headers, name, value) };

    static IReadOnlyDictionary<string, string> AddHeader(IReadOnlyDictionary<string, string> headers, string name, string value) => headers
        .Append(new KeyValuePair<string, string>(name, value))
        .ToImmutableDictionary(kvp => kvp.Key, kvp => kvp.Value);
}
