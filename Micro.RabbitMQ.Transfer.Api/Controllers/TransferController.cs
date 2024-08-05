using Micro.RabbitMQ.Transfer.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Micro.RabbitMQ.Transfer.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransferController(
        ITransferService transferService) : ControllerBase
    {

        [HttpGet]
        public IActionResult Gets()
        {
            return Ok(transferService.Gets());
        }
    }
}
