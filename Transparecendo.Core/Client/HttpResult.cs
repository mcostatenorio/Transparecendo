using Microsoft.Extensions.Primitives;
using System.Net;
using System.Net.Http.Headers;

namespace Transparecendo.Core.Client
{
    /// <summary>
    /// Estrutura padronizada com os detalhes da respostas
    /// </summary>
    public class HttpResult
    {
        /// <summary>
        /// Estrutura bruta do body
        /// </summary>
        public string? Raw { get; set; }

        /// <summary>
        /// Flag que retorna se o status é de sucesso ou não
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Status code da chamada
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// Content-Type da response
        /// </summary>
        public MediaTypeHeaderValue? ContentType { get; set; }

        /// <summary>
        /// Headers da resposta
        /// </summary>
        public Dictionary<string, StringValues> Headers { get; set; } = new Dictionary<string, StringValues>();
    }

    /// <summary>
    /// Estrutura padronizada com os detalhes da respostas
    /// </summary>
    public class HttpResult<T> : HttpResult where T : class
    {
        /// <summary>
        /// Objeto traduzido na resposta
        /// </summary>
        public T? Obj { get; set; }
    }

    /// <summary>
    /// Estrutura padronizada com os detalhes da respostas
    /// </summary>
    public class HttpResult<T, TError> : HttpResult<T> where T : class where TError : class
    {
        /// <summary>
        /// Objecto em caso de erro na chamada
        /// </summary>
        public TError? Error { get; set; }
    }
}