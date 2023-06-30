namespace Transparecendo.Core.Services
{
    /// <summary>
    /// Base para limitar as resposta dos serviços aos padrões definidos.
    /// </summary>
    public abstract class BaseService
    {
        /// <summary>
        /// Resposta de sucesso com o retorno do payload padrão
        /// </summary>
        /// <returns>Resposta de sucesso.</returns>
        public Result Success()
        {
            return new Result(true);
        }

        /// <summary>
        /// Resposta de sucesso com o retorno do payload padrão
        /// </summary>
        /// <returns>Resposta de sucesso.</returns>
        public Result<T> Success<T>(T data)
        {
            return new Result<T>(data);
        }

        /// <summary>
        /// Resposta de erro com payload padrão
        /// </summary>
        /// <param name="metaError">Dados do erro ocorrido.</param>
        /// <returns>Resposta de erro.</returns>
        public Result ErrorResult(Enum metaError)
        {
            return new ErrorResult(metaError);
        }

        /// <summary>
        /// Resposta de erro com payload padrão
        /// </summary>
        /// <param name="metaError">Dados do erro ocorrido.</param>
        /// <returns>Resposta de erro.</returns>
        public Result ErrorResult<T>(List<string> metaError) where T : struct
        {
            return new ErrorResult<T>(metaError);
        }

        /// <summary>
        /// Resposta de erro com payload padrão
        /// </summary>
        /// <param name="metaError">Dados do erro ocorrido.</param>
        /// <returns>Resposta de erro.</returns>
        public Result ErrorResult<TEnum, TRequest>(List<string> metaError) where TEnum : struct where TRequest : class
        {
            return new ErrorResult<TEnum, TRequest>(metaError);
        }

        /// <summary>
        /// Resposta de erro com payload padrão
        /// </summary>
        /// <param name="metaError">Dados do erro ocorrido.</param>
        /// <returns>Resposta de erro.</returns>
        public Result ErrorResult<T>(List<T> metaError) where T : struct
        {
            return new ErrorResult<T>(metaError);
        }

        /// <summary>
        /// Resposta de erro com payload padrão
        /// </summary>
        /// <param name="metaError">Dados do erro ocorrido.</param>
        /// <returns>Resposta de erro.</returns>
        public Result ErrorResult<TEnum, TRequest>(List<TEnum> metaError) where TEnum : struct where TRequest : class
        {
            return new ErrorResult<TEnum, TRequest>(metaError);
        }

        /// <summary>
        /// Resposta de erro com payload padrão
        /// </summary>
        /// <param name="metaError">Dados do erro ocorrido.</param>
        /// <returns>Resposta de erro.</returns>
        public Result ErrorResult<T>(string metaError) where T : struct
        {
            return new ErrorResult<T>(metaError);
        }

        /// <summary>
        /// Resposta de erro com payload padrão
        /// </summary>
        /// <param name="metaError">Dados do erro ocorrido.</param>
        /// <returns>Resposta de erro.</returns>
        public Result ErrorResult<TEnum, TRequest>(string metaError) where TEnum : struct where TRequest : class
        {
            return new ErrorResult<TEnum, TRequest>(metaError);
        }

        /// <summary>
        /// Resposta de erro com payload padrão
        /// </summary>
        /// <param name="metaError">Dados do erro ocorrido.</param>
        /// <returns>Resposta de erro.</returns>
        public Result ErrorResult<T>(T metaError) where T : struct
        {
            return new ErrorResult<T>(metaError);
        }

        /// <summary>
        /// Resposta de erro com payload padrão
        /// </summary>
        /// <param name="metaError">Dados do erro ocorrido.</param>
        /// <returns>Resposta de erro.</returns>
        public Result<T> ErrorResult<T>(Enum metaError)
        {
            return new ResponseErrorResult<T>(metaError);
        }

        /// <summary>
        /// Resposta de erro com payload padrão
        /// </summary>
        /// <param name="metaError">Dados do erro ocorrido.</param>
        /// <returns>Resposta de erro.</returns>
        public Result ErrorResult<TEnum, TRequest>(TEnum metaError) where TEnum : struct where TRequest : class
        {
            return new ErrorResult<TEnum, TRequest>(metaError);
        }

        /// <summary>
        /// Resposta de erro com payload padrão
        /// </summary>
        /// <param name="metaError">Dados do erro ocorrido.</param>
        /// <param name="paramReplace">Valor a ser substituido</param>
        /// <returns>Resposta de erro.</returns>
        public Result ErrorResult<T>(string metaError, object paramReplace) where T : struct
        {
            return new ErrorResult<T>(metaError, paramReplace);
        }

        /// <summary>
        /// Resposta de erro com payload padrão
        /// </summary>
        /// <param name="metaError">Dados do erro ocorrido.</param>
        /// <param name="paramReplace">Valor a ser substituido</param>
        /// <returns>Resposta de erro.</returns>
        public Result ErrorResult<T>(T metaError, params object[] paramReplace) where T : struct
        {
            return new ErrorResult<T>(metaError, paramReplace);
        }

        /// <summary>
        /// Resposta de erro com payload padrão
        /// </summary>
        /// <param name="metaError">Dados do erro ocorrido.</param>
        /// <param name="paramReplace">Valor a ser substituido</param>
        /// <returns>Resposta de erro.</returns>
        public Result<T> ErrorResult<T>(Enum metaError, object paramReplace)
        {
            return new ResponseErrorResult<T>(metaError, paramReplace);
        }

        /// <summary>
        /// Resposta de erro com payload padrão
        /// </summary>
        /// <param name="metaError">Dados do erro ocorrido.</param>
        /// <param name="paramReplace">Valor a ser substituido</param>
        /// <returns>Resposta de erro.</returns>
        public Result ErrorResult<TEnum, TRequest>(string metaError, object paramReplace) where TEnum : struct where TRequest : class
        {
            return new ErrorResult<TEnum, TRequest>(metaError, paramReplace);
        }

        /// <summary>
        /// Resposta de erro com payload padrão
        /// </summary>
        /// <param name="metaError">Dados do erro ocorrido.</param>
        /// <param name="paramReplace">Valor a ser substituido</param>
        /// <returns>Resposta de erro.</returns>
        public Result ErrorResult<TEnum, TRequest>(TEnum metaError, object paramReplace) where TEnum : struct where TRequest : class
        {
            return new ErrorResult<TEnum, TRequest>(metaError, paramReplace);
        }
    }
}