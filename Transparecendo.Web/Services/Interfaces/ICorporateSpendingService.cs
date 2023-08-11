using Transparecendo.Web.DTO;

namespace Transparecendo.Web.Services.Interfaces
{
    public interface ICorporateSpendingService
    {
        Task<List<ValuesByTermDto>> GetAllExpenseByTerm();
    }
}
