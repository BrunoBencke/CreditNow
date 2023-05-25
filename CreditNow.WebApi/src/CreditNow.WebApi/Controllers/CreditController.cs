using CreditNow.Core.Domain.Interfaces;
using CreditNow.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace CreditNow.WebApi.Controllers
{
    [ApiController]
    [Route("api/credit")]
    public class CreditController : ControllerBase
    {
        private readonly ICreditValidationService _creditValidationService;

        public CreditController(ICreditValidationService creditValidationService)
        {
            _creditValidationService = creditValidationService;
        }

        [HttpPost("validate")]
        public IActionResult ValidateCredit([FromBody] CreditInformation creditInfo)
        {
            CreditValidationResult validationResult = _creditValidationService.ValidateCredit(creditInfo);

            return Ok(validationResult);
        }
    }
}
