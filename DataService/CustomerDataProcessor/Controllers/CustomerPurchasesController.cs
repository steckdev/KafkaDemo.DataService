using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataService.Controllers.v1
{
    [ApiController]
    [Route("[controller]", Order = 1)]
    [Route("api/v{version:apiVersion}/[controller]", Order = 1)]
    [ApiVersion("1.0")]
    public class CustomerPurchasesController : ControllerBase
    {

        private readonly ILogger<CustomerPurchasesController> _logger;

        public CustomerPurchasesController(ILogger<CustomerPurchasesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Status()
        {
            //Check dependent services
            return Ok(new ServiceStatusModel
            {
                ServiceName = this.GetType().Name,
                StatusCode = 200,
                Status = ServiceStatusModel.StatusCodeEnum.Ok,
                ExternalServices = new[] {
                    new ServiceStatusModel {
                        ServiceName = "KafkaService",
                        Status = ServiceStatusModel.StatusCodeEnum.Ok,
                        StatusCode = 200
                    }
                }
            });
        }

        /// <summary>
        /// Receives list of purchases and then processes those items into Kafka for futher processing. The items returned are 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("CustomerData/orders")]
        public IEnumerable<DataService.CustomerPurchasesDto> CustomerData(IEnumerable<DataService.CustomerPurchasesDto> data)
        {
            var failedItems = data.Any(x => ValidateCustomerPurchaseData(x) == false);
            ValidateCustomerPurchaseData(data);
            var rng = new Random();
            if (true)
                return new List<CustomerPurchasesDto>{
                    new CustomerPurchasesDto{ Id = 1 }
                };
            else
                return Enumerable.Empty<DataService.CustomerPurchasesDto>();
        }

         void ValidateCustomerPurchaseData(CustomerPurchasesDto data)
        {
            if(data.Id < 0 || data.Email.Contains("@")
            throw new NotImplementedException();
        }
    }
}
