using MassTransit;
using Matching.Consumers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matching
{
    class Program
    {
        static void Main(string[] args)
        {
            IBusControl bus = Bus.Factory.CreateUsingRabbitMq(cfg => {
                var host = cfg.Host(new Uri("rabbitmq://localhost/MassTransit_Demo"), c => {
                    c.Username("root");
                    c.Password("root#123");
                });

                cfg.ReceiveEndpoint(host,"demo", c =>
                { 
                    c.Consumer<SendMessageConsumer>();
                });
                

            });
            bus.Start();

            Console.WriteLine("输入[enter]退出");
            Console.ReadKey();
            bus.Stop();
        }
    }
}
