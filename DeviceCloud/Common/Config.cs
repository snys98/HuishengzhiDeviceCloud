﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeviceCloud
{
    public class Config
    {
        static Config()
        {
            DefaultPageSize = 15;
        }
        public static int DefaultPageSize { get; set; }
    }
}