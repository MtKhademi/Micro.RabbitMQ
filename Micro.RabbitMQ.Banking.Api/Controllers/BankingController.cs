using Micro.RabbitMQ.Banking.Api.Domain.Models;
using Micro.RabbitMQ.Banking.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Micro.RabbitMQ.Banking.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BankingController : ControllerBase
    {

        private readonly IAccountService _accountService;

        public BankingController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Account>> GetAll()
        {
            return Ok(_accountService.GetAccounts());
        }
    }
}
