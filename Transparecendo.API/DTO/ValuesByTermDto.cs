﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Transparecendo.API.DTO
{
    public class ValuesByTermDto
    {
        public decimal Valor { get; set; }

        public string? NomePresidente { get; set; }

        public string? Mandato { get; set; }

        public string? UrlImagem { get; set; }

        public int Ordem { get; set; }
    }
}
