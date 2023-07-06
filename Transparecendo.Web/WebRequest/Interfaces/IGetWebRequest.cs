using Transparecendo.Core.Client;

namespace Transparecendo.Web.WebRequest.Interfaces
{
    public interface IGetWebRequest
    {
        Task<HttpResult<U>> GetAsync<U>(string path) where U : class;
    }
}
