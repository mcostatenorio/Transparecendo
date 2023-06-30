using Microsoft.AspNetCore.Mvc;
using Transparecendo.Service.API.Interfaces.Services;

namespace Transparecendo.Service.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CorporateSpendingController : ControllerBase
    {
        private readonly ILogger<CorporateSpendingController> _logger;
        private readonly IServiceCorporateSpending _serviceCorporateSpending;

        public CorporateSpendingController(ILogger<CorporateSpendingController> logger,
                                           IServiceCorporateSpending serviceCorporateSpending)
        {
            _logger = logger;
            _serviceCorporateSpending = serviceCorporateSpending;
        }

        [HttpPost]
        public ActionResult SendCSV(string path)
        {
            if(_serviceCorporateSpending.UploadCSVFile(path))
                return Ok();
            else 
                return BadRequest();
        }

        [HttpGet]
        public ActionResult GetByData(DateTime dataInicio, DateTime dataFinal)
        {
            return _serviceCorporateSpending.GetByData(dataInicio, dataFinal);
        }
    }
}