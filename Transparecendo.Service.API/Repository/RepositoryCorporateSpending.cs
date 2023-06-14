using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transparecendo.Service.API.Infrastructure.DbContext;
using Transparecendo.Service.API.Interfaces.Repository;
using Transparecendo.Service.API.Repository;
using Transparecendo.Service.Domain.Entities;

namespace Transparecendo.Service.Domain.Repository
{
    public class RepositoryCorporateSpending : RepositoryBase<CorporateSpending>, IRepositoryCorporateSpending
    {
        private readonly TransparecendoDbContext _TransparecendoDbContext;
        public RepositoryCorporateSpending(TransparecendoDbContext transparecendoDbContext) : base(transparecendoDbContext)
        {
            _TransparecendoDbContext = transparecendoDbContext;
        }
    }
}
