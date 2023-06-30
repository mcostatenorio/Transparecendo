using Transparecendo.Core.Entities;

namespace Transparecendo.Service.API.Interfaces.Repository
{
    public interface IRepositoryCorporateSpending : IRepositoryBase<CorporateSpending>
    {
        List<CorporateSpending> GetByData(DateTime dtStart, DateTime dtEnd);
    }
}
