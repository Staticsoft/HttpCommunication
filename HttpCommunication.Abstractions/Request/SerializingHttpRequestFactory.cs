using Staticsoft.JsonSerialization.Abstractions;
using System;
using System.Text;

namespace Staticsoft.HttpCommunication.Abstractions
{
    public abstract class SerializingHttpRequestFactory : HttpRequestFactory
    {
        readonly Serializer Serializer;

        public SerializingHttpRequestFactory(Serializer serializer)
            => Serializer = serializer;

        public HttpRequest Create(HttpMethod method, string path)
            => Create(method, path, new HttpBody(Array.Empty<byte>(), ContentType));

        public HttpRequest Create(HttpMethod method, string path, object body)
            => Create(method, path, new HttpBody(Encoding.UTF8.GetBytes(Serializer.Serialize(body)), ContentType));

        HttpRequest Create(HttpMethod method, string path, HttpBody body)
            => new HttpRequest(method, path, body);

        protected abstract string ContentType { get; }
    }
}
