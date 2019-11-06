using System;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using MQTTnet.Server;

namespace RebitMQ
{
    public class Broker
    {
        public static IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
        public static IPAddress ipAddress = ipHostInfo.AddressList[0];


        public async void Start()
        {
            await ConfigBrocerAsync();
            await SendMQTT();
        }

        public async Task ConfigBrocerAsync()
        {
            var optionsBuilder = new MqttServerOptionsBuilder()
                                .WithDefaultEndpointPort(1889);

            var mqttServer = new MqttFactory().CreateMqttServer();
            await mqttServer.StartAsync(optionsBuilder.Build());

        }

        public async Task SendMQTT()
        {
            //Create a new MQTT client.
            var factory = new MqttFactory();
            var mqttClient = factory.CreateMqttClient();

            var options = new MqttClientOptionsBuilder()
                .WithTcpServer("localhost", 1889)
                .Build();

            await mqttClient.ConnectAsync(options);

            mqttClient.UseApplicationMessageReceivedHandler(_ =>
            {


            });

            await mqttClient.SubscribeAsync("device/+/#");
        }

    }
}
