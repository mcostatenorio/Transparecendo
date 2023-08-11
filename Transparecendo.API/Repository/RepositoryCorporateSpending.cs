using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Data;
using Transparecendo.API.DTO;
using Transparecendo.API.Entities;
using Transparecendo.Service.API.Infrastructure.DbContext;
using Transparecendo.Service.API.Interfaces.Repository;
using Transparecendo.Service.API.Repository;
using Transparecendo.API.Helpers.Enums;
using System.Reflection;
using Microsoft.OpenApi.Extensions;
using System.Linq;

namespace Transparecendo.Service.Domain.Repository
{
    public class RepositoryCorporateSpending : RepositoryBase<CorporateSpending>, IRepositoryCorporateSpending
    {
        private readonly TransparecendoDbContext _TransparecendoDbContext;
        public RepositoryCorporateSpending(TransparecendoDbContext transparecendoDbContext) : base(transparecendoDbContext)
        {
            _TransparecendoDbContext = transparecendoDbContext;
        }

        public List<CorporateSpending> GetExpense(ExpenseFilterDto expenseFilter)
        {
            var expenses = _TransparecendoDbContext.Set<CorporateSpending>().ToList();

            if (expenseFilter.NomePresidente > 0)
            {
                var presidente = expenseFilter.NomePresidente.GetType()?
                                    .GetMember(expenseFilter.NomePresidente.ToString())
                                    .First()
                                    .GetCustomAttribute<DisplayAttribute>()?
                                    .GetName();
                expenses = expenses.Where(a => a.Presidente != null && a.Presidente.Equals(presidente)).ToList();
            }

            if (expenseFilter.Sort > 0)
            {
                switch ((int)expenseFilter.Sort)
                {
                    case 1:
                        expenses = expenses.OrderBy(x => x.Presidente).ToList();
                        break;
                    case 2:
                        expenses = expenses.OrderByDescending(x => x.Presidente).ToList();
                        break;
                }
            }


            if ((expenseFilter.DateStart != DateTime.MinValue && expenseFilter.DateEnd != DateTime.MinValue) && expenseFilter.DateEnd > expenseFilter.DateStart)
                expenses = expenses.Where(a => a.DataPagamento >= expenseFilter.DateStart && a.DataPagamento <= expenseFilter.DateEnd).ToList();
            else if (expenseFilter.DateStart != DateTime.MinValue)
                expenses = expenses.Where(a => a.DataPagamento >= expenseFilter.DateStart).ToList();
            else if (expenseFilter.DateEnd != DateTime.MinValue)
                expenses = expenses.Where(a => a.DataPagamento <= expenseFilter.DateEnd).ToList();

            int limitPerPage = 20;

            if (expenseFilter.PageSize.HasValue)
                limitPerPage = expenseFilter.PageSize.Value;

            if (expenseFilter.Page.HasValue)
            {
                expenses = expenses.Skip(limitPerPage * (expenseFilter.Page.Value - 1)).Take(limitPerPage).ToList();
            }
            else
                expenses = expenses.Take(limitPerPage).ToList();

            return expenses;
        }

        public List<CorporateSpending> GetExpenseByData(DateTime dtStart, DateTime dtEnd)
        {
            return _TransparecendoDbContext.Set<CorporateSpending>().Where(t => t.DataPagamento > dtStart && t.DataPagamento < dtEnd).ToList();
        }

        public List<ValuesByTermDto> GetAllExpenseByTerm()
        {
            var ValuesByTermDto = new List<ValuesByTermDto>();

            using (var command = _TransparecendoDbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "select sum(valor) as Valor, Presidente as 'NomePresidente', Mandato, UrlImagem, Ordem from CorporateSpending group by Presidente, Mandato, UrlImagem, Ordem  order by Ordem asc ";
                command.CommandType = CommandType.Text;

                if (command.Connection?.State != ConnectionState.Open) { command.Connection?.Open(); }

                using (var result = command.ExecuteReader())
                {
                    while (result.Read())
                    {
                        var obj = new ValuesByTermDto();
                        obj.Valor = (decimal)result[0];
                        obj.NomePresidente = (string)result[1];
                        obj.Mandato = (string)result[2];
                        obj.UrlImagem = (string)result[3];
                        obj.Ordem = (int)result[4];
                        ValuesByTermDto.Add(obj);
                    }
                }
            }
            return ValuesByTermDto;
        }
    }
}
