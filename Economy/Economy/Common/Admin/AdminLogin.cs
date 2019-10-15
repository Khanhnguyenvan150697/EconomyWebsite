using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Economy.Common.Admin
{
    [Serializable]
    public class AdminLogin
    {
        public int IDAdmin { set; get; }
        public string AdminName { set; get; }
    }
}