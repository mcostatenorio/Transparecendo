using Transparecendo.API.Entities;
using Transparecendo.Core.Services;

namespace Transparecendo.Service.API.Interfaces.Services
{
    public interface IServiceCorporateSpending : IServiceBase<CorporateSpending>
    {
        bool UploadCSVFile(string path);

        Result GetByData(DateTime dtStart, DateTime dtEnd);

        Result GetAllValuesByTerm();
    }
}
