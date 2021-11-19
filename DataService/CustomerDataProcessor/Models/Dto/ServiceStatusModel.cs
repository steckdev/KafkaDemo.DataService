using System;

namespace CustomerDataProcessor
{
    public class ServiceStatusModel
    {
        public String ServiceName;
        public enum StatusCodeEnum { Ok, InternalError, DependencyError}
        public int StatusCode { get; set; }
        public StatusCodeEnum Status { get; set; }
        public Decimal Price { get; set; }
        public ServiceStatusModel[] ExternalServices { get; set; }
    }
}