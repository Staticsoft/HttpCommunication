using Staticsoft.HttpCommunication.Abstractions;
using Staticsoft.JsonSerialization.Abstractions;

namespace Staticsoft.HttpCommunication.Json
{
    public class JsonHttpRequestFactory : SerializingHttpRequestFactory
    {
        public JsonHttpRequestFactory(JsonSerializer serializer)
            : base(serializer) { }

        protected override string ContentType
            => "application/json";
    }
}
