namespace Staticsoft.HttpCommunication.Abstractions
{
    public interface HttpResponseParser
    {
        T Parse<T>(byte[] body);
    }
}
