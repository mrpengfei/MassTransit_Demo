using ClientUI.Messages;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientUI
{
    class Program
    {
        static void Main(string[] args)
        {
            IBusControl bus = Bus.Factory.CreateUsingRabbitMq(cfg => {
                cfg.Host(new Uri("rabbitmq://localhost/MassTransit_Demo"),c=> {
                    c.Username("root");
                    c.Password("root#123");
                });
            });

            bus.Start();
            Console.WriteLine("输入q退出，其他 发送消息");
            while (true)
            {
                var read = Console.ReadLine();
                if (read.ToLower().Equals("q"))
                {
                    break;
                }

                bus.Send(new SendMessage
                {
                    Message = read
                }).ContinueWith(task =>
                {
                    Console.WriteLine($"发送消息：{read}");
                });

                bus.Send<ISyncMessage>(new
                {
                    Message = read
                }).ContinueWith(task =>
                {
                    Console.WriteLine($"发送消息：{read}");
                });
            }

            bus.Stop();
        }
    }
}
