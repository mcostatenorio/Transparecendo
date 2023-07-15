using Transparecendo.Web.DTO;

namespace Transparecendo.Web.Services.Interfaces
{
    public interface ICorporateSpendingService
    {
        Task<List<CorporateSpendingDto>> GetByData(DateTime dtStart, DateTime dtEnd);

        Task<List<ValuesByTermDto>> GetAllValuesByTerm();
    }
}
