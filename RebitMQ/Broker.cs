using System;
using System.Threading.Tasks;
using MQTTnet;
using MQTTnet.Server;

namespace RebitMQ
{
    public class Broker
    {
        public static async void Start()
        {
            await ConfigBrocerAsync();
        }

        public static async Task ConfigBrocerAsync()
        {
            var optionsBuilder = new MqttServerOptionsBuilder()
                                .WithDefaultEndpointPort(1889);

            var mqttServer = new MqttFactory().CreateMqttServer();
            await mqttServer.StartAsync(optionsBuilder.Build());
        }
    }
}
