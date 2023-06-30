using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Transparecendo.Core.Helpers;

namespace Transparecendo.Core.Client
{
    public abstract class HttpApiCallClient
    {
        public HttpApiCallClient(IHttpClientFactory clientFactory, string clientName, object? fallbackObject = null, bool ignoreDefaultPolicies = false)
        {
            this._clientFactory = clientFactory;
            this._clientName = clientName;
            this._client = _clientFactory.CreateClient(this._clientName);
            this._fallbackObject = fallbackObject;
            this._ignoreDefaultPolicies = ignoreDefaultPolicies;
        }

        private string GenerateRandomClientName()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }

        protected IHttpClientFactory _clientFactory;

        protected HttpClient _client;

        public string _clientName;

        public object? _fallbackObject;

        public bool _ignoreDefaultPolicies { get; set; }

        protected abstract string GetEndpoint();

        protected void CreateHttpClient(IHttpClientFactory clientFactory)
        {
            var endpoint = GetEndpoint();
            if (!string.IsNullOrEmpty(endpoint) && _client.BaseAddress == null)
                _client.BaseAddress = new Uri(endpoint);
        }

        /// <summary>
        /// Método que executa uma chamada a uma API externa.
        /// </summary>
        /// <typeparam name="T">Tipo de retorno esperado.</typeparam>
        /// <param name="httpRequestParams">Parâmetros para a execução do request.</param>
        /// <param name="deserializeOnError">Flag que indica se é para deserializar o body em caso de erro</param>
        /// <returns>Objeto populado com resposta da requisição.</returns>
        public virtual async Task<HttpResult<T>> ExecuteFullAsync<T>(HttpRequestParams httpRequestParams, bool deserializeOnError = false) where T : class
        {
            var result = await CoreExecuteFullAsync<HttpResult<T>>(httpRequestParams);

            var httpBody = new HttpBody();

            if (result.Success || deserializeOnError)
                result.Obj = httpBody.ParseResponse<T>(result.Raw, result.ContentType?.MediaType);

            return result;
        }

        /// <summary>
        /// Método que executa uma chamada a uma API externa.
        /// </summary>
        /// <typeparam name="T">Tipo de retorno esperado.</typeparam>
        /// <typeparam name="TError">Tipo de retorno esperado caso ter erro.</typeparam>
        /// <param name="httpRequestParams">Parâmetros para a execução do request.</param>
        /// <returns>Objeto populado com resposta da requisição.</returns>
        public virtual async Task<HttpResult<T, TError>> ExecuteFullAsync<T, TError>(HttpRequestParams httpRequestParams) where T : class where TError : class
        {
            var result = await CoreExecuteFullAsync<HttpResult<T, TError>>(httpRequestParams);

            var httpBody = new HttpBody();

            if (result.Success)
                result.Obj = httpBody.ParseResponse<T>(result.Raw, result.ContentType?.MediaType);
            else
                result.Error = httpBody.ParseResponse<TError>(result.Raw, result.ContentType?.MediaType);

            return result;
        }


        /// <summary>
        /// Método que executa uma chamada a uma API externa.
        /// </summary>
        /// <param name="httpRequestParams">Parâmetros para a execução do request.</param>
        /// <returns>Response body em string.</returns>
        public virtual async Task<HttpResult> ExecuteFullAsync(HttpRequestParams httpRequestParams)
        {
            var result = await CoreExecuteFullAsync<HttpResult>(httpRequestParams);
            return result;
        }

        /// <summary>
        /// Método que executa uma chamada a uma API externa.
        /// </summary>
        /// <typeparam name="T">Tipo de retorno esperado.</typeparam>
        /// <param name="httpRequestParams">Parâmetros para a execução do request.</param>
        /// <returns></returns>
        protected virtual async Task<T> CoreExecuteFullAsync<T>(HttpRequestParams httpRequestParams) where T : HttpResult, new()
        {
            CreateHttpClient(_clientFactory);
            var result = new T();

            try
            {
                var (response, request) = await ExecuteRawAsync(httpRequestParams);

                try
                {
                    result.Raw = await response.Content.ReadAsStringAsync();
                    if (httpRequestParams.ApiType == ApiType.Internal && response.IsSuccessStatusCode)
                        result.Raw = JsonHelper.GetFirstPropertyAtRootLevel("data", result.Raw);

                    result.StatusCode = response.StatusCode;
                    result.ContentType = response.Content.Headers.ContentType;
                    result.Success = response.IsSuccessStatusCode;


                    foreach (var (key, value) in response.Headers)
                    {
                        result.Headers.Add(key, new StringValues(value.ToArray()));
                    }
                }
                finally
                {
                    response.Dispose();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace); //TODO: incluir log aqui quando for criada a classe de log
                Console.WriteLine(ex.Message); //TODO: incluir log aqui quando for criada a classe de log
            }

            return result;
        }

        /// <summary>
        /// Método que executa uma chamada a uma API externa.
        /// </summary>
        /// <typeparam name="T">Tipo de retorno esperado.</typeparam>
        /// <param name="httpRequestParams">Parâmetros para a execução do request.</param>
        /// <returns>Objeto populado com resposta da requisição.</returns>
        public virtual async Task<T?> ExecuteAsync<T>(HttpRequestParams httpRequestParams) where T : class
        {
            var (responseString, contentType) = await CoreExecuteAsync(httpRequestParams);

            var httpBody = new HttpBody();
            var result = httpBody.ParseResponse<T>(responseString, contentType);

            return result as T;
        }

        /// <summary>
        /// Método que executa uma chamada a uma API externa.
        /// </summary>
        /// <param name="httpRequestParams">Parâmetros para a execução do request.</param>
        /// <returns>Response body em string.</returns>
        public virtual async Task<string?> ExecuteAsync(HttpRequestParams httpRequestParams)
        {
            var (result, _) = await CoreExecuteAsync(httpRequestParams);
            return result;
        }

        /// <summary>
        /// Método que executa uma chamada a uma API externa.
        /// </summary>
        /// <param name="httpRequestParams">Parâmetros para a execução do request.</param>
        /// <returns>Retorna o response como string e o contenttype</returns>
        protected virtual async Task<(string?, string?)> CoreExecuteAsync(HttpRequestParams httpRequestParams)
        {
            CreateHttpClient(_clientFactory);
            var result = string.Empty;
            var contentType = MediaTypeConstants.APP_JSON;

            try
            {
                var (response, request) = await ExecuteRawAsync(httpRequestParams);

                try
                {
                    result = await response.Content.ReadAsStringAsync();

                    if (httpRequestParams.ApiType == ApiType.Internal &&
                            httpRequestParams.MediaType == MediaTypeConstants.APP_JSON)
                        result = JsonHelper.GetFirstPropertyAtRootLevel("data", result);

                    contentType = response.Content.Headers.ContentType?.MediaType;
                }
                finally
                {
                    response.Dispose();
                }
            }
            catch
            {
                contentType = null;
            }

            return (result, contentType);
        }

        /// <summary>
        /// Método que executa uma chamada a uma API externa.
        /// </summary>
        /// <param name="httpRequestParams">Parâmetros para a execução do request.</param>
        /// <returns>Retorna o response e o request formatado</returns>
        protected virtual async Task<(HttpResponseMessage, string?)> ExecuteRawAsync(HttpRequestParams httpRequestParams)
        {
            string? requestString = null;

            var httpBody = new HttpBody();

            Func<Task<HttpResponseMessage>> function = async () =>
            {
                var request = new HttpRequestMessage();

                if (httpRequestParams.HasPath())
                    if (_client.BaseAddress != null)
                        request.RequestUri = new Uri(httpRequestParams.Path, UriKind.Relative);
                    else
                        request.RequestUri = new Uri(httpRequestParams.Path, UriKind.Absolute);

                if (httpRequestParams.HasHeader())
                    foreach (var (key, value) in httpRequestParams.GetHeaders())
                        request.Headers.Add(key, value);

                switch (httpRequestParams.Method)
                {
                    case HttpType.GET:
                        request.Method = HttpMethod.Get;
                        break;

                    case HttpType.POST:
                        request.Method = HttpMethod.Post;
                        (request.Content, requestString) = httpBody.ParseRequest(httpRequestParams.Data, httpRequestParams.MediaType);
                        break;

                    case HttpType.PUT:
                        request.Method = HttpMethod.Put;
                        (request.Content, requestString) = httpBody.ParseRequest(httpRequestParams.Data, httpRequestParams.MediaType);
                        break;

                    case HttpType.DELETE:
                        request.Method = HttpMethod.Delete;
                        break;

                    case HttpType.PATCH:
                        request.Method = HttpMethod.Patch;
                        (request.Content, requestString) = httpBody.ParseRequest(httpRequestParams.Data, httpRequestParams.MediaType);
                        break;

                    case HttpType.HEAD:
                        request.Method = HttpMethod.Head;
                        break;

                    default:
                        throw new ArgumentOutOfRangeException($"Utilize um método suportado pela lib ({nameof(HttpType)})");
                }
                return await _client.SendAsync(request);
            };

            if (httpRequestParams.Policy != null)
                return (await httpRequestParams.Policy.ExecuteAsync(function), requestString);

            return (await function(), requestString);
        }
    }
}
