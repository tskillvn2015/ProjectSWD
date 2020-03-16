using Microsoft.AspNetCore.Mvc;
using Shoes_Store.Interfaces;
using Shoes_Store.Ultility.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoes_Store.Common
{
    public class ApiResponse : ControllerBase,IApiResponse
    {
        public Response Ok(object value)
        {
            var rs = new Response
            {
                Code = "200",
                Message = null,
                Content = value
            };
            return rs;
        }
        public Response Error(string message,string errorCode)
        {
            var rs = new Response
            {
                Message = message,
                Code = errorCode
            };
            return rs;
        }
    }
}
