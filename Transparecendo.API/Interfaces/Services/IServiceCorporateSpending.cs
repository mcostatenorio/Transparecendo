using Transparecendo.Core.Services;
using Transparecendo.Core.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Transparecendo.Service.API.Interfaces.Services
{
    public interface IServiceCorporateSpending : IServiceBase<CorporateSpending>
    {
        bool UploadCSVFile(string path);

        Result GetByData(DateTime dtStart, DateTime dtEnd);
    }
}
