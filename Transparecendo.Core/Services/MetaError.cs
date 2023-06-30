namespace Transparecendo.Core.Services
{
    /// <summary>
    /// Encapsulando erro com código do protocolo
    /// </summary>
    internal class MetaError
    {
        /// <summary>
        /// Construtor Padrão.
        /// </summary>
        /// <param name="error"></param>
        /// <param name="protocolCode"></param>
        public MetaError(ErrorEntity error)
        {
            Error = error;
        }

        /// <summary>
        /// Erro.
        /// </summary>
        public ErrorEntity Error { get; set; }
    }
}
