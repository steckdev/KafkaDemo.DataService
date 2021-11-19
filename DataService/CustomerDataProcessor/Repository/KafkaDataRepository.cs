using Confluent.Kafka;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerDataProcessor.Repository
{
    public class KafkaDataRepository : IDataRepository
    {


        //Inject config
        public override bool SaveCustomerData(CustomerPurchasesDto customerPurchases)
        {
            var config = GetConfig();

            using (var p = new ProducerBuilder<Null, string>(config).Build())
            {
                try
                {
                    var value = JsonConvert.SerializeObject(customerPurchases);
                    p.Produce("new-purchase", new Message<Null, string> { Value = value });

                    return true;
                }
                catch (ProduceException<Null, string> e)
                {
                    Console.WriteLine($"Delivery failed: {e.Error.Reason}");

                    return false;
                }
            }

            //
            throw new NotImplementedException();
        }


        private ProducerConfig GetConfig()
        {
            return new ProducerConfig
            {
                BootstrapServers = "34.196.151.95:9092,3.213.212.236:9092,18.213.93.46:9092",
                SslCaLocation = "/Path-to/cluster-ca-certificate.pem",
                SecurityProtocol = SecurityProtocol.SaslSsl,
                SaslMechanism = SaslMechanism.ScramSha256,
                SaslUsername = "ickafka",
                SaslPassword = "493f586cc469a59987c8a9148669b9ecc570bb031bf3fa639e894be185331dce",

            };
        }
    }
}
