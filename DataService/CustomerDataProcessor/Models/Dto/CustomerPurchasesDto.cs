using System;
using System.ComponentModel.DataAnnotations;

namespace CustomerDataProcessor
{
    public class CustomerPurchasesDto
    {
        [Range(0, int.MaxValue)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [EmailAddressAttribute]
        public string Email { get; set; }
        public AppPurchaseDto Apps { get; set; }
    }
}
