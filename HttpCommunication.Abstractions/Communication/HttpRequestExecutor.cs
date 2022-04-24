using System.Threading.Tasks;

namespace Staticsoft.HttpCommunication.Abstractions
{
    public interface HttpRequestExecutor
    {
        Task<HttpResponse> Execute(HttpRequest request);
    }
}
