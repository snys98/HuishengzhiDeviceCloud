﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeviceCloud.Models.Admin
{
    public class SysUserModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public string DisplayName { get; set; }
    }
}