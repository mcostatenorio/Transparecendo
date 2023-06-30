using Microsoft.AspNetCore.Mvc;
using Transparecendo.Core.Helpers;
using Newtonsoft.Json;

namespace Transparecendo.Core.Services
{
    /// <summary>
    /// Estrutura de resultado padrão de api
    /// </summary>
    public class Result
    {
        /// <summary>
        /// Estrutura de resultado padrão de api
        /// </summary>
        /// <param name="success">Indicativo de sucesso</param>
        public Result(bool success)
        {
            Success = success;
        }

        /// <summary>
        /// Indicativo de sucesso
        /// </summary>
        public virtual bool Success { get; }

        /// <summary>
        /// Cast padrão de sucesso
        /// </summary>
        /// <param name="error">Erro enum para gerar um <seealso cref="ErrorData"/></param>
        public static implicit operator Result(Enum error) => new ErrorResult(error);

        /// <summary>
        /// Parse do <seealso cref="ActionResult"/>
        /// </summary>
        /// <param name="resultData"><seealso cref="ResultData"/> com para retorno de api</param>
        public static implicit operator ActionResult(Result result) => HttpHelper.Convert(result);
    }

    /// <summary>
    /// Estrutura de resultado padrão de api
    /// </summary>
    /// <typeparam name="T">Tipo do dado</typeparam>
    public class Result<T> : Result, ISuccessResult
    {
        /// <summary>
        /// Estrutura de resultado padrão de api
        /// </summary>
        /// <param name="data"></param>
        public Result(T data)
            : base(true)
        {
            Data = data;
        }

        /// <summary>
        /// Estrutura de resultado padrão de api para retornos de falha
        /// </summary>
        public Result()
            : base(false)
        {
        }

        /// <summary>
        /// Valor da resposta
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public T Data { get; private set; }

        object ISuccessResult.Data => Data;

        /// <summary>
        /// Cast padrão de sucesso
        /// </summary>
        /// <param name="data">Valor retornado</param>
        public static implicit operator Result<T>(T data) => new Result<T>(data);

        /// <summary>
        /// Parse do <seealso cref="ActionResult"/>
        /// </summary>
        /// <param name="resultData"><seealso cref="ResultData"/> com para retorno de api</param>
        public static implicit operator ActionResult(Result<T> result) => HttpHelper.Convert(result);

        /// <summary>
        /// Cast de erro
        /// </summary>
        /// <param name="error">Erro a res convertido</param>
        public static implicit operator Result<T>(Enum error) => new ResponseErrorResult<T>(error);

        /// <summary>
        /// Cast de erro
        /// </summary>
        /// <param name="error">Erro com o valor a ser substituido</param>
        public static implicit operator Result<T>((Enum, object) error) => new ResponseErrorResult<T>(error.Item1, error.Item2);
    }

    /// <summary>
    /// Interface de indicativo de sucesso
    /// </summary>
    public interface ISuccessResult
    {
        /// <summary>
        /// Flag que indica o sucesso da operação
        /// </summary>
        bool Success { get; }

        /// <summary>
        /// Dados a serem retornados
        /// </summary>
        object Data { get; }
    }
}