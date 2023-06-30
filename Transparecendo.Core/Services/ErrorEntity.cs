namespace Transparecendo.Core.Services
{
    /// <summary>
    /// Objeto de erro padrão.
    /// </summary>
    public class ErrorEntity
    {
        /// <summary>
        /// Código do erro.
        /// </summary>
        public string? Key { get; set; }

        /// <summary>
        /// Mensagem descrevendo o erro.
        /// </summary>
        public string? Message { get; set; }

        /// <summary>
        /// Argumentos que podem ser utilizados para fazer replaces na string
        /// </summary>
        public object[]? Args { get; set; }
    }
}