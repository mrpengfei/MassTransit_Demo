﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeFlight
{
    public static class Bus
    {
        public static IBusFactory Factory = new BusFactory();
    }
}