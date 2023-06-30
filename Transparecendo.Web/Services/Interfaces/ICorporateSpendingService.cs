using Transparecendo.Core.DTO;

namespace Transparecendo.Service.Web.Services.Interfaces
{
    public interface ICorporateSpendingService
    {
        Task<List<CorporateSpendingDto>> GetByData(DateTime dtStart, DateTime dtEnd);
    }
}
