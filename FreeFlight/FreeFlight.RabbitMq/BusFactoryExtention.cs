using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeFlight.RabbitMq
{
    public static class BusFactoryExtention
    {
        public static IBus CreateUseRabbitMq(this IBusFactory factory) {
            return RabbitMqBusFactory.Create();
        }
    }
}
