using System.Threading.Tasks;

namespace Staticsoft.HttpCommunication.Abstractions
{
    public interface Http
    {
        Task<HttpResult<T>> Request<T>(HttpMethod method, string path);
        Task<HttpResult<T>> Request<T>(HttpMethod method, string path, object body);
    }
}
