using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerPurchasesController : ControllerBase
    {

        private readonly ILogger<CustomerPurchasesController> _logger;

        public CustomerPurchasesController(ILogger<CustomerPurchasesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<DataService.CustomerPurchasesDto> Get()
        {
            var rng = new Random();
            return new List<CustomerPurchasesDto>{
                new CustomerPurchasesDto{ Id = 1 }
                };
            }
    }
}
