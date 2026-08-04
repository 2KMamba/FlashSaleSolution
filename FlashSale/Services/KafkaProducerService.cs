using Confluent.Kafka;
using Newtonsoft.Json;
using FlashSale.Models;

namespace FlashSale.Services
{
    public class KafkaProducerService
    {
        private readonly IProducer<Null, string> _producer;

        public KafkaProducerService()
        {
            var config = new ProducerConfig
            {
                BootstrapServers = "localhost:9092"
            };

            _producer = new ProducerBuilder<Null, string>(config).Build();
        }

        public async Task EnviarEvento(EventoCompra evento)
        {
            string json = JsonConvert.SerializeObject(evento);

            await _producer.ProduceAsync("compras",
                new Message<Null, string>
                {
                    Value = json
                });
        }
    }
}
