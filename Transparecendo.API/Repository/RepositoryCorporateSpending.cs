using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transparecendo.Service.API.Infrastructure.DbContext;
using Transparecendo.Service.API.Interfaces.Repository;
using Transparecendo.Service.API.Repository;
using Transparecendo.Core.Entities;

namespace Transparecendo.Service.Domain.Repository
{
    public class RepositoryCorporateSpending : RepositoryBase<CorporateSpending>, IRepositoryCorporateSpending
    {
        private readonly TransparecendoDbContext _TransparecendoDbContext;
        public RepositoryCorporateSpending(TransparecendoDbContext transparecendoDbContext) : base(transparecendoDbContext)
        {
            _TransparecendoDbContext = transparecendoDbContext;
        }

        public List<CorporateSpending> GetByData(DateTime dtStart, DateTime dtEnd)
        {
            return _TransparecendoDbContext.Set<CorporateSpending>().Where(t => t.DataPagamento > dtStart && t.DataPagamento < dtEnd).ToList();
        }
    }
}
