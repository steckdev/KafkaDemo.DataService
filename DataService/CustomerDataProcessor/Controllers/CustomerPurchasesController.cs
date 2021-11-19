using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CustomerDataProcessor.Controllers.v1
{
    [ApiController]
    [Route("[controller]", Order = 1)]
    [Route("api/v{version:apiVersion}/[controller]", Order = 1)]
    [ApiVersion("1.0")]
    public class CustomerPurchasesController : ControllerBase
    {

        private readonly ILogger<CustomerPurchasesController> _logger;

        //Inject Kafka Service/Repositry  here
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
        public IActionResult CustomerData(IEnumerable<CustomerDataProcessor.CustomerPurchasesDto> data)
        {
            var failedItems = data.Any(x => ValidateCustomerPurchaseData(x) == false);

            //Maybe return the items that failed...
            if(failedItems)
                return new BadRequestResult();

            
            return new OkResult();
        }

        private bool ValidateCustomerPurchaseData(CustomerPurchasesDto data)
        {
            //Validation has been started in the DTO using DataAnnotation
            if (String.IsNullOrEmpty(data.FirstName) || String.IsNullOrEmpty(data.LastName))
                return false;
            else
                return true;
        }
    }
}
