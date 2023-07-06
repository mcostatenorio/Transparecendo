using Transparecendo.Core.Client;
using Transparecendo.Web.WebRequest.Interfaces;

namespace Transparecendo.Web.Request
{
    public class GetWebRequest : HttpApiCallClient, IGetWebRequest
    {
        private readonly IConfiguration _configuration;
        private readonly string _basePath;

        public GetWebRequest(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory, "GetWebRequest")
        {
            _configuration = configuration;
            _basePath = _configuration["Urls:TransparecendoBasePath"];
        }

        protected override string GetEndpoint()
        {
            return _basePath;
        }

        async Task<HttpResult<U>> IGetWebRequest.GetAsync<U>(string path) where U : class
        {
            var request = new HttpRequestParams(path, HttpType.GET);

            return await ExecuteFullAsync<U>(request, true);
        }
    }
}