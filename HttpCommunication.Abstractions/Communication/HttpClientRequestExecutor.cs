using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Net = System.Net;

namespace Staticsoft.HttpCommunication.Abstractions
{
    public class HttpClientRequestExecutor : HttpRequestExecutor
    {
        readonly HttpClient Client;

        public HttpClientRequestExecutor(HttpClient client)
            => Client = client;

        public async Task<HttpResponse> Execute(HttpRequest request)
        {
            var response = await Client.SendAsync(CreateMessage(request), CancellationToken.None);
            var body = await response.Content.ReadAsByteArrayAsync();
            return new HttpResponse(Convert.ToInt32(response.StatusCode), body);
        }

        static HttpRequestMessage CreateMessage(HttpRequest request)
        {
            var message = new HttpRequestMessage()
            {
                Method = GetMethod(request.Method),
                RequestUri = new Uri(request.Path, UriKind.RelativeOrAbsolute)
            };
            message.Content = new ByteArrayContent(request.Body.Value);
            message.Content.Headers.ContentType = new MediaTypeHeaderValue(request.Body.ContentType);

            AddHeaders(message.Headers, request.Headers);
            return message;
        }

        static Net.Http.HttpMethod GetMethod(HttpMethod method) => method switch
        {
            HttpMethod.Get => Net.Http.HttpMethod.Get,
            HttpMethod.Post => Net.Http.HttpMethod.Post,
            HttpMethod.Delete => Net.Http.HttpMethod.Delete,
            HttpMethod.Patch => Net.Http.HttpMethod.Patch,
            HttpMethod.Put => Net.Http.HttpMethod.Put,
            _ => throw new NotSupportedException()
        };

        static void AddHeaders(HttpRequestHeaders httpHeaders, IReadOnlyDictionary<string, string> requestHeaders)
        {
            foreach (var (name, value) in requestHeaders)
            {
                httpHeaders.Add(name, value);
            }
        }
    }
}
