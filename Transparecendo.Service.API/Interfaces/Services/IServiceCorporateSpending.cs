using Transparecendo.Service.Domain.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Transparecendo.Service.API.Interfaces.Services
{
    public interface IServiceCorporateSpending : IServiceBase<CorporateSpending>
    {
        public bool UploadCSVFile(string url);
    }
}
