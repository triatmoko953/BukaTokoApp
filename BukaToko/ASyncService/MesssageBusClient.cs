﻿using BukaToko.ASyncService;
using BukaToko.DTOS;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace BukaToko.AsyncService
{
    public class MesssageBusClient : IMessageBusClient
    {
        private readonly IConfiguration _configuration;
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public void PublishNewProduct(ProductPublishDto productPublishDto)
        {

            var message = JsonSerializer.Serialize(productPublishDto);
            if (_connection.IsOpen)
            {
                Console.WriteLine("--> RabbitMQ connection is open, sending message...");
                SendMessage(message);
            }
            else
            {
                Console.WriteLine("--> RabbitMQ connection is closed, not sending...");
            }
        }

        private void SendMessage(string message)
        {
            var body = Encoding.UTF8.GetBytes(message);
            _channel.BasicPublish(exchange: "trigger_product", routingKey: "",
            basicProperties: null, body: body);
            Console.WriteLine($"--> We have sent {message}");
        }
    }
}
