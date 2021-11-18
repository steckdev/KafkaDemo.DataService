using System;
using System.ComponentModel.DataAnnotations;

namespace DataService
{
    public class AppPurchaseDto
    {
        public Guid Id { get; set; }
        public String Name { get; set; }

        [Range(0, double.MaxValue)]
        public Decimal Price { get; set; }
    }
}