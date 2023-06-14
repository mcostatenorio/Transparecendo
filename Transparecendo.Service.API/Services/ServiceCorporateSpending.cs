using Transparecendo.Service.API.Interfaces.Repository;
using Transparecendo.Service.API.Interfaces.Services;
using Transparecendo.Service.Domain.Entities;

namespace Transparecendo.Service.API.Services
{
    public class ServiceCorporateSpending : ServiceBase<CorporateSpending>, IServiceCorporateSpending
    {
        private readonly IRepositoryCorporateSpending _repositoryCorporateSpending;

        public ServiceCorporateSpending(IRepositoryCorporateSpending repositoryCorporateSpending) : base(repositoryCorporateSpending)
        {
            _repositoryCorporateSpending = repositoryCorporateSpending;
        }

        public bool UploadCSVFile(string url)
        {
            return false;
        }
    }
}
