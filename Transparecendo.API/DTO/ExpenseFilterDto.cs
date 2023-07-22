using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using Transparecendo.API.Helpers.Enums;

namespace Transparecendo.API.DTO
{
    public class ExpenseFilterDto
    {
        [FromQuery(Name = "nomePresidente")]
        [JsonProperty("nomePresidente")]
        public Presidente NomePresidente { get; set; }

        [FromQuery(Name = "_page")]
        [JsonProperty("_page")]
        public int? Page { get; set; }


        [FromQuery(Name = "_pageSize")]
        [JsonProperty("_pageSize")]
        [Range(1, 50, ErrorMessage = "Value must be between 1 to 50")]
        public int? PageSize { get; set; }

        [FromQuery(Name = "_sort")]
        [JsonProperty("_sort")]
        public Order Sort { get; set; }


        [FromQuery(Name = "dateStart")]
        [JsonProperty("dateStart")]
        public DateTime DateStart { get; set; }

        [FromQuery(Name = "dateEnd")]
        [JsonProperty("dateEnd")]
        public DateTime DateEnd { get; set; }
    }
}
