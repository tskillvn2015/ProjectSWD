using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoes_Store.Interfaces
{
    public interface IApiResponse
    {
        public OkObjectResult Ok(object value);
        public OkObjectResult Error(string message, string errorCode);
    }
}
