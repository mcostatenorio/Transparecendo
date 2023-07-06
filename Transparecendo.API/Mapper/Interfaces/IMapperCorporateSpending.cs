using Transparecendo.API.DTO;
using Transparecendo.API.Entities;

namespace Transparecendo.Core.Mapper.Interfaces
{
    public interface IMapperCorporateSpending
    {
        CorporateSpending MapperDtoToEntity(CorporateSpendingDto DTO);

        public CorporateSpendingDto MapperEntityToDto(CorporateSpending Entity);

        IEnumerable<CorporateSpendingDto> MapperListDTOCorporateSpending(IEnumerable<CorporateSpending> Entity);
    }
}
