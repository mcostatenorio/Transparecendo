using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transparecendo.Core.DTO;
using Transparecendo.Core.Entities;

namespace Transparecendo.Core.Mapper.Interfaces
{
    public interface IMapperCorporateSpending
    {
        CorporateSpending MapperDtoToEntity(CorporateSpendingDto DTO);

        public CorporateSpendingDto MapperEntityToDto(CorporateSpending Entity);

        IEnumerable<CorporateSpendingDto> MapperListDTOCorporateSpending(IEnumerable<CorporateSpending> Entity);
    }
}
