using Transparecendo.Web.DTO;

namespace Transparecendo.Web.Services.Interfaces
{
    public interface ICorporateSpendingService
    {
        Task<List<CorporateSpendingDto>> GetExpenseByData(DateTime dtStart, DateTime dtEnd);

        Task<List<ValuesByTermDto>> GetAllExpenseByTerm();
    }
}
