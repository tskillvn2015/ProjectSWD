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
        public OkObjectResult Ok(object value)
        {
            var response = new Response
            {
                Code = "200",
                Message = null,
                Content = value
            };
            var rs = new OkObjectResult(response);
            return rs;
        }
        public OkObjectResult Error(string message,string errorCode)
        {
            var response = new Response
            {
                Message = message,
                Content = errorCode
            };
            var rs = new OkObjectResult(response);
            return rs;
        }
    }
}
