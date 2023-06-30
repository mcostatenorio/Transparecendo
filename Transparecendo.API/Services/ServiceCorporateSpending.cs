using CsvHelper;
using CsvHelper.Configuration;
using System.Formats.Asn1;
using System.Globalization;
using System.Text;
using Transparecendo.Core.Services;
using Transparecendo.Service.API.Helpers;
using Transparecendo.Service.API.Interfaces.Repository;
using Transparecendo.Service.API.Interfaces.Services;
using Transparecendo.Core.Entities;
using Transparecendo.Core.Mapper.Interfaces;

namespace Transparecendo.Service.API.Services
{
    public class ServiceCorporateSpending : ServiceBase<CorporateSpending>, IServiceCorporateSpending
    {
        private readonly IRepositoryCorporateSpending _repositoryCorporateSpending;
        private readonly IMapperCorporateSpending _mapperCorporateSpending;

        public ServiceCorporateSpending(IRepositoryCorporateSpending repositoryCorporateSpending, IMapperCorporateSpending mapperCorporateSpending) : base(repositoryCorporateSpending)
        {
            _repositoryCorporateSpending = repositoryCorporateSpending;
            _mapperCorporateSpending = mapperCorporateSpending;
        }

        public bool UploadCSVFile(string path)
        {
            List<CorporateSpending> list = new List<CorporateSpending>();

            using (var reader = new StreamReader(path, Encoding.UTF8))
            using (var csv = new CsvReader(reader, new CsvConfiguration(System.Globalization.CultureInfo.InvariantCulture) { Delimiter = ";" }))
            {
                csv.Read();
                csv.ReadHeader();

                while (csv.Read())
                {
                    if (csv.Context.Parser.Row > 113341)
                        continue;
                    
                    CorporateSpending _corporateSpending = new CorporateSpending();
                    _corporateSpending.DataPagamento = DateTime.ParseExact(csv.GetField(0), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    _corporateSpending.CpfServidor = csv.GetField(1);
                    _corporateSpending.DocumentoFornecedor = csv.GetField(2);
                    _corporateSpending.NomeFornecedor = csv.GetField(3);
                    _corporateSpending.Valor = Helper.OnlyNumbers(csv.GetField(4)) != string.Empty ? decimal.Parse(Helper.OnlyNumbers(csv.GetField(4))) : 0;
                    _corporateSpending.Tipo = csv.GetField(5);
                    _corporateSpending.SubElementoDespesa = csv.GetField(6);
                    _corporateSpending.CDIC = csv.GetField(7);

                    list.Add(_corporateSpending);
                }
            }
            _repositoryCorporateSpending.AddList(list);

            return true;
        }

        public Result GetByData(DateTime dtStart, DateTime dtEnd)
        {
            return Success(_mapperCorporateSpending.MapperListDTOCorporateSpending(_repositoryCorporateSpending.GetByData(dtStart, dtEnd)));
        }

    }
}
