namespace Staticsoft.HttpCommunication.Abstractions
{
    public class HttpResponse
    {
        public readonly int StatusCode;
        public readonly byte[] Body;

        public HttpResponse(int statusCode, byte[] body)
            => (StatusCode, Body) = (statusCode, body);
    }
}
