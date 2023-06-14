using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transparecendo.Service.Domain.Entities
{
    public class CorporateSpending
    {
        public DateTime DataPagamento { get; set; }

        public string? CpfServidor { get; set; }

        public string? DocumentoFornecedor { get; set; }
        
        public string? NomeFornecedor { get; set; }

        public Double Valor { get; set; }

        public string? Tipo { get; set; }

        public string? SubElementoDespesa { get; set; }

        public string? CDIC { get; set; }
    }
}
