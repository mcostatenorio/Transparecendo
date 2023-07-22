using Transparecendo.API.DTO;
using Transparecendo.API.Entities;
using Transparecendo.Core.Services;

namespace Transparecendo.Service.API.Interfaces.Services
{
    public interface IServiceCorporateSpending : IServiceBase<CorporateSpending>
    {
        bool UploadCSVFile(string path);

        Result GetExpense(ExpenseFilterDto expenseFilter);

        Result GetExpenseByData(DateTime dtStart, DateTime dtEnd);

        Result GetAllExpenseByTerm();
    }
}
