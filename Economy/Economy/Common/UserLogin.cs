﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Economy.Common
{
    [Serializable]
    public class UserLogin
    {
        public long UserID { set; get; }
        public string UserName { set; get; }
        public string UserEmail { set; get; }
        public string UserPhone { set; get; }
        public string UserAddress { set; get; }
        public string Avatar { set; get; }
    }
}