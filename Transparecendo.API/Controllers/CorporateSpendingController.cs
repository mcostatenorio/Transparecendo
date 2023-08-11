using Microsoft.AspNetCore.Mvc;
using Transparecendo.API.DTO;
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

        /// <summary>
        /// Import spending data (Upload CSV file)
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("importSpendingData")]
        public ActionResult SendCSV(string path)
        {
            if(_serviceCorporateSpending.UploadCSVFile(path))
                return Ok();
            else 
                return BadRequest();
        }

        /// <summary>
        /// Get expenses by query filter
        /// </summary>
        /// <param name="expenseFilter">Filter</param>
        /// <returns></returns>
        [ProducesResponseType(200, Type= typeof(CorporateSpendingDto))]
        [Route("getSpendingData")]
        [HttpGet]
        public ActionResult GetExpense([FromQuery] ExpenseFilterDto expenseFilter)
             => _serviceCorporateSpending.GetExpense(expenseFilter);

        /// <summary>
        /// Get all expenses by term
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getSpendingDataByTerm")]
        public ActionResult GetAllExpenseByTerm()
            => _serviceCorporateSpending.GetAllExpenseByTerm();
    }
}