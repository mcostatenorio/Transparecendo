using System.ComponentModel.DataAnnotations.Schema;

namespace Transparecendo.API.DTO
{
    public class ValuesByTermDto
    {
        public decimal Valor { get; set; }

        public string? NomePresidente { get; set; }
    }
}
