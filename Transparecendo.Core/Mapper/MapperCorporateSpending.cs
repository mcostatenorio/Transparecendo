using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transparecendo.Core.DTO;
using Transparecendo.Core.Entities;
using Transparecendo.Core.Mapper.Interfaces;

namespace Transparecendo.Core.Mapper
{
    public class MapperCorporateSpending : IMapperCorporateSpending
    {
        public CorporateSpending MapperDtoToEntity(CorporateSpendingDto DTO)
        {
            var CorporateSpending = new CorporateSpending()
            {
                DataPagamento = DTO.DataPagamento,
                CpfServidor = DTO.CpfServidor,
                DocumentoFornecedor = DTO.DocumentoFornecedor,
                NomeFornecedor = DTO.NomeFornecedor,
                Valor = DTO.Valor,
                Tipo = DTO.Tipo,
                SubElementoDespesa = DTO.SubElementoDespesa,
                CDIC = DTO.CDIC,
            };
            return CorporateSpending;
        }

        public CorporateSpendingDto MapperEntityToDto(CorporateSpending Entity)
        {
            var CorporateSpendingDto = new CorporateSpendingDto()
            {
                DataPagamento = Entity.DataPagamento,
                CpfServidor = Entity.CpfServidor,
                DocumentoFornecedor = Entity.DocumentoFornecedor,
                NomeFornecedor = Entity.NomeFornecedor,
                Valor = Entity.Valor,
                Tipo = Entity.Tipo,
                SubElementoDespesa = Entity.SubElementoDespesa,
                CDIC = Entity.CDIC,
            };
            return CorporateSpendingDto;
        }

        public IEnumerable<CorporateSpendingDto> MapperListDTOCorporateSpending(IEnumerable<CorporateSpending> Entity)
        {
            var ListDTOCorporateSpending = Entity.Select(c =>
                           new CorporateSpendingDto
                           {
                               DataPagamento = c.DataPagamento,
                               CpfServidor = c.CpfServidor,
                               DocumentoFornecedor = c.DocumentoFornecedor,
                               NomeFornecedor = c.NomeFornecedor,
                               Valor = c.Valor,
                               Tipo = c.Tipo,
                               SubElementoDespesa = c.SubElementoDespesa,
                               CDIC = c.CDIC,
                           });
            return ListDTOCorporateSpending;
        }
    }
}
