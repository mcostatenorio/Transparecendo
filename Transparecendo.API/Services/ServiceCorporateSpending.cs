using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Text;
using Transparecendo.API.Entities;
using Transparecendo.Core.Mapper.Interfaces;
using Transparecendo.Core.Services;
using Transparecendo.Service.API.Helpers;
using Transparecendo.Service.API.Interfaces.Repository;
using Transparecendo.Service.API.Interfaces.Services;

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

                    switch (_corporateSpending.DataPagamento)
                    {
                        case DateTime n when (n >= new DateTime(2003, 1, 1) && n < new DateTime(2007, 1, 1)):
                            _corporateSpending.Presidente = "Lula - 1 Mandato";
                            break;
                        case DateTime n when (n >= new DateTime(2007, 1, 1) && n < new DateTime(2011, 1, 1)):
                            _corporateSpending.Presidente = "Lula - 2 Mandato";
                            break;
                        case DateTime n when (n >= new DateTime(2011, 1, 1) && n < new DateTime(2015, 1, 1)):
                            _corporateSpending.Presidente = "Dilma - 1 Mandato";
                            break;
                        case DateTime n when (n >= new DateTime(2015, 1, 1) && n < new DateTime(2016, 8, 31)):
                            _corporateSpending.Presidente = "Dilma - 2 Mandato";
                            break;
                        case DateTime n when (n >= new DateTime(2016, 8, 31) && n < new DateTime(2019, 1, 1)):
                            _corporateSpending.Presidente = "Michel Temer - 1 Mandato";
                            break;
                        case DateTime n when (n >= new DateTime(2019, 1, 1)):
                            _corporateSpending.Presidente = "Bolsonaro - 1 Mandato";
                            break;
                    }
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

        public Result GetAllValuesByTerm()
        {
            return Success(_repositoryCorporateSpending.GetAllValuesByTerm());
        }

    }
}
