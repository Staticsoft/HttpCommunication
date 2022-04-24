using Staticsoft.JsonSerialization.Abstractions;
using System.Text;

namespace Staticsoft.HttpCommunication.Abstractions
{
    public class SerializedHttpResponseParser : HttpResponseParser
    {
        readonly Serializer Serializer;

        public SerializedHttpResponseParser(Serializer serializer)
            => Serializer = serializer;

        public T Parse<T>(byte[] body)
            => Serializer.Deserialize<T>(Encoding.UTF8.GetString(body));
    }
}
