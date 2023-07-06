using Microsoft.EntityFrameworkCore;
using System.Data;
using Transparecendo.API.DTO;
using Transparecendo.API.Entities;
using Transparecendo.Service.API.Infrastructure.DbContext;
using Transparecendo.Service.API.Interfaces.Repository;
using Transparecendo.Service.API.Repository;

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

        public List<ValuesByTermDto> GetAllValuesByTerm()
        {
            var ValuesByTermDto = new List<ValuesByTermDto>();

            using (var command = _TransparecendoDbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "select sum(valor) as Valor, Presidente as 'NomePresidente' from CorporateSpending group by Presidente";
                command.CommandType = CommandType.Text;

                if (command.Connection?.State != ConnectionState.Open) { command.Connection?.Open(); }

                using (var result = command.ExecuteReader())
                {
                    while (result.Read())
                    {
                        var obj = new ValuesByTermDto();
                        obj.Valor = (decimal)result[0];
                        obj.NomePresidente = (string)result[1];
                        ValuesByTermDto.Add(obj);
                    }
                }
            }
            return ValuesByTermDto;
        }
    }
}
