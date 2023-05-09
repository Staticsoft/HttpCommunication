using System.Threading.Tasks;

namespace Staticsoft.HttpCommunication.Abstractions;

public static class HttpExtensions
{
    public static async Task<HttpResult> Request(this Http http, HttpMethod method, string path)
        => await http.Request<EmptyBody>(method, path);

    public static async Task<HttpResult> Request(this Http http, HttpMethod method, string path, object body)
        => await http.Request<EmptyBody>(method, path, body);
}
