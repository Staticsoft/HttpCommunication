namespace Staticsoft.HttpCommunication.Abstractions;

public class HttpBody
{
    public readonly byte[] Value;
    public readonly string ContentType;

    public HttpBody(byte[] value, string contentType)
        => (Value, ContentType) = (value, contentType);
}
