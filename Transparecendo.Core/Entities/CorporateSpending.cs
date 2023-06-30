using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transparecendo.Service.API.Entities;

namespace Transparecendo.Core.Entities
{
    public class CorporateSpending : Base
    {
        public DateTime DataPagamento { get; set; }

        public string? CpfServidor { get; set; }

        public string? DocumentoFornecedor { get; set; }
        
        public string? NomeFornecedor { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public Decimal Valor { get; set; }

        public string? Tipo { get; set; }

        public string? SubElementoDespesa { get; set; }

        public string? CDIC { get; set; }
    }
}
