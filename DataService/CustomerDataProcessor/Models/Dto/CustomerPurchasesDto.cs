using System;
using System.ComponentModel.DataAnnotations;

namespace DataService
{
    public class CustomerPurchasesDto
    {
        [Range(0, int.MaxValue)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public EmailAddressAttribute Email { get; set; }
        public AppPurchaseDto Apps { get; set; }
    }
}
