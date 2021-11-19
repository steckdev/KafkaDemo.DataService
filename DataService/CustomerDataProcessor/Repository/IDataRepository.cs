using CustomerDataProcessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerDataProcessor
{
    public abstract class IDataRepository
    {
        //set this to domain object type instead of shared DTO
        public abstract bool SaveCustomerData(CustomerPurchasesDto customerPurchases);
    }
}
