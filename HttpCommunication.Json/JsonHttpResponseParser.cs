using Staticsoft.HttpCommunication.Abstractions;
using Staticsoft.JsonSerialization.Abstractions;

namespace Staticsoft.HttpCommunication.Json
{
    public class JsonHttpResponseParser : SerializedHttpResponseParser
    {
        public JsonHttpResponseParser(JsonSerializer serializer)
            : base(serializer) { }
    }
}
