﻿using Transparecendo.Core.DTO;
using Transparecendo.Service.Web.Services.Interfaces;
using Transparecendo.Service.Web.WebRequest.Interfaces;

namespace Transparecendo.Service.Web.Services
{
    public class CorporateSpendingService : ICorporateSpendingService
    {
        public IGetWebRequest _getWebRequest { get; set; }
        public IConfiguration _configuration { get; set; }

        public CorporateSpendingService(IGetWebRequest getWebRequest, IConfiguration configuration)
        {
            _getWebRequest = getWebRequest;
            _configuration = configuration;
        }

        public async Task<List<CorporateSpendingDto>> GetByData(DateTime dtStart, DateTime dtEnd)
        {
            var result = await _getWebRequest.GetAsync<List<CorporateSpendingDto>>(string.Format($"{_configuration["Urls:TransparecendoBaseCorporateSpending"]}?dataInicio=02-01-2003&dataFinal=03-01-2003"));

            if (result != null && result.Obj != null)
                return result.Obj;
            else
                return new List<CorporateSpendingDto>();
        } 
    }
}
