namespace Staticsoft.HttpCommunication.Abstractions;

public interface HttpRequestFactory
{
    HttpRequest Create(HttpMethod method, string path);
    HttpRequest Create(HttpMethod method, string path, object body);
}
