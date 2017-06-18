using ClientUI.Messages;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matching.Consumers
{
    public class SendMessageConsumer : IConsumer<SendMessage>
    {
        public Task Consume(ConsumeContext<SendMessage> context)
        {
            Console.WriteLine(context.Message.Message);
            Console.WriteLine(context.MessageId);
            return Task.FromResult(true);
        }
    }
}
