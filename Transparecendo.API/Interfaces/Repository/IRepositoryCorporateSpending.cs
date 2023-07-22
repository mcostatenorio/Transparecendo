using Transparecendo.API.DTO;
using Transparecendo.API.Entities;

namespace Transparecendo.Service.API.Interfaces.Repository
{
    public interface IRepositoryCorporateSpending : IRepositoryBase<CorporateSpending>
    {
        List<CorporateSpending> GetExpense(ExpenseFilterDto expenseFilter);

        List<CorporateSpending> GetExpenseByData(DateTime dtStart, DateTime dtEnd);

        List<ValuesByTermDto> GetAllExpenseByTerm();
    }
}
