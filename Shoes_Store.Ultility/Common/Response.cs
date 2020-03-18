using System;
using System.Collections.Generic;
using System.Text;

namespace Shoes_Store.Ultility.Common
{
    public class Response
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public object Content { get; set; }
    }
}
