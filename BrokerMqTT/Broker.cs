using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MQTTnet;
using MQTTnet.Client.Options;
using MQTTnet.Client.Receiving;
using MQTTnet.Protocol;
using MQTTnet.Server;

namespace BrokerMqTT
{
    public class Broker
    {
        public async Task StartAsync()
        {
            var mqttServer = new MqttFactory().CreateMqttServer();
            await mqttServer.StartAsync(new MqttServerOptions());
            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
            await mqttServer.StopAsync();
        }

        public async Task ConfigBrocerAsync()
        {
            var optionsBuilder = new MqttServerOptionsBuilder()
                                .WithConnectionBacklog(100)
                                .WithDefaultEndpointPort(1889);

            var mqttServer = new MqttFactory().CreateMqttServer();
            await mqttServer.StartAsync(optionsBuilder.Build());
        }
        /*Validator
        public async Task Validator()
        {
            var optionsBuilder = new MqttServerOptionsBuilder()
                .WithConnectionValidator(c =>
                {
                    if (c.ClientId.Length < 10)
                    {
                        c.ReturnCode = MqttConnectReturnCode.ConnectionRefusedIdentifierRejected;
                        return;
                    }

                    if (c.Username != "root1")
                    {
                        c.ReturnCode = MqttConnectReturnCode.ConnectionRefusedBadUsernameOrPassword;
                        return;
                    }

                    if (c.Password != "123")
                    {
                        c.ReturnCode = MqttConnectReturnCode.ConnectionRefusedBadUsernameOrPassword;
                        return;
                    }

                    c.ReturnCode = MqttConnectReturnCode.ConnectionAccepted;
                });
        }*/
    }
}
