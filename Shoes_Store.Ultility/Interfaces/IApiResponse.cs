using Shoes_Store.Ultility.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoes_Store.Interfaces
{
    public interface IApiResponse
    {
        public Response Ok(object value);
        public Response Error(string message, string errorCode);
    }
}
