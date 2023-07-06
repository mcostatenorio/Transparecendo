namespace Transparecendo.Web.DTO
{
    public class CorporateSpendingDto
    {
        public DateTime DataPagamento { get; set; }

        public string? CpfServidor { get; set; }

        public string? DocumentoFornecedor { get; set; }

        public string? NomeFornecedor { get; set; }

        public Decimal Valor { get; set; }

        public string? Tipo { get; set; }

        public string? SubElementoDespesa { get; set; }

        public string? CDIC { get; set; }
    }
}
