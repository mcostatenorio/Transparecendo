using Polly;

namespace Transparecendo.Core.Client
{
    public class HttpRequestParams
    {
        /// <summary>
        /// Construtor para utilização default GET
        /// </summary>
        /// <param name="path">Endereço do request a partir do fim da uri base.</param>
        public HttpRequestParams(string path)
        {
            this.Path = path;
            this.Method = HttpType.GET;
            this.MediaType = MediaTypeConstants.APP_JSON;
            this.ApiType = ApiType.Internal;
        }

        /// <summary>
        /// Construtor para definir path e tipo de método
        /// </summary>
        /// <param name="path">Endereço do request a partir do fim da uri base.</param>
        /// <param name="method">Método HTTP do request.</param>
        public HttpRequestParams(string path, HttpType method)
        {
            this.Path = path;
            this.Method = method;
            this.MediaType = MediaTypeConstants.APP_JSON;
            this.ApiType = ApiType.Internal;
        }

        /// <summary>
        /// Construtor para definir path, tipo de método e objeto de envio
        /// </summary>
        /// <param name="path">Endereço do request a partir do fim da uri base.</param>
        /// <param name="method">Método HTTP do request.</param>
        /// <param name="data">Parâmetros que serão passados no body (casos POST, PUT ou PATCH).</param>
        public HttpRequestParams(string path, HttpType method, object? data)
        {
            this.Path = path;
            this.Method = method;
            this.Data = data;
            this.MediaType = MediaTypeConstants.APP_JSON; ;
            this.ApiType = ApiType.Internal;
        }


        /// <summary>
        /// Construtor para definir path, tipo de método e objeto de envio
        /// </summary>
        /// <param name="path">Endereço do request a partir do fim da uri base.</param>
        /// <param name="method">Método HTTP do request.</param>
        /// <param name="data">Parâmetros que serão passados no body (casos POST, PUT ou PATCH).</param>
        /// <param name="mediaType">ContentType da chamada</param>
        public HttpRequestParams(string path, HttpType method, object? data, string mediaType)
        {
            this.Path = path;
            this.Method = method;
            this.Data = data;
            this.MediaType = mediaType;
            this.ApiType = ApiType.Internal;
        }

        /// <summary>
        /// Construtor para definir path, tipo de método, objeto de envio e tipo de envio (JSON, XML)
        /// </summary>
        /// <param name="path">Endereço do request a partir do fim da uri base.</param>
        /// <param name="method">Método HTTP do request.</param>
        /// <param name="data">Parâmetros que serão passados no body (casos POST, PUT ou PATCH).</param>
        /// <param name="headers">Cabeçalho da chamada</param>
        /// <param name="mediaType">ContentType da chamada</param>
        /// <param name="apiType">Se a API é interna ou externa</param>
        public HttpRequestParams(string path, HttpType method, object? data, string mediaType, ApiType apiType)
        {
            this.Path = path;
            this.Method = method;
            this.Data = data;
            this.MediaType = mediaType;
            this.ApiType = apiType;
        }

        /// <summary>
        /// Construtor para definir path, tipo de método, objeto de envio, tipo de envio (JSON, XML) e policy
        /// </summary>
        /// <param name="path">Endereço do request a partir do fim da uri base.</param>
        /// <param name="method">Método HTTP do request.</param>
        /// <param name="data">Parâmetros que serão passados no body (casos POST, PUT ou PATCH).</param>
        /// <param name="headers">Cabeçalho da chamada</param>
        /// <param name="mediaType">ContentType da chamada</param>
        /// <param name="apiType">Se a API é interna ou externa</param>
        /// <param name="policy">Politica de tratamento de falha da chamada</param>
        public HttpRequestParams(string path, HttpType method, object? data, string mediaType, ApiType apiType, IAsyncPolicy<HttpResponseMessage>? policy)
        {
            this.Path = path;
            this.Method = method;
            this.Data = data;
            this.MediaType = mediaType;
            this.ApiType = apiType;
            this.Policy = policy;
        }

        public string Path { get; private set; }

        public HttpType Method { get; private set; }

        public object? Data { get; private set; }

        private Dictionary<string, string>? Headers { get; set; }

        public string MediaType { get; private set; }

        public ApiType ApiType { get; private set; }

        public IAsyncPolicy<HttpResponseMessage>? Policy { get; private set; }

        public void SetPath(string path)
        {
            this.Path = path;
        }

        public bool HasPath() =>
             !string.IsNullOrWhiteSpace(this.Path);

        public Dictionary<string, string> GetHeaders()
        {
            if (this.Headers == null)
                return new Dictionary<string, string>();

            return this.Headers;
        }

        public bool HasHeader() =>
            this.Headers != null && this.Headers.Count > 0;

        public void SetMethod(HttpType method)
        {
            this.Method = method;
        }

        public void SetMediaType(string mediaType)
        {
            this.MediaType = mediaType;
        }

        public void SetApiType(ApiType apiType)
        {
            this.ApiType = apiType;
        }

        public void SetPolicy(IAsyncPolicy<HttpResponseMessage> policy)
        {
            this.Policy = policy;
        }

        public void RemoveDefaultPolicy()
        {
            this.Policy = null;
        }

        public void AddHeader(string key, string value)
        {
            if (this.Headers == null)
                this.Headers = new Dictionary<string, string>();

            this.Headers.Add(key, value);
        }
    }
}