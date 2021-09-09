using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairCutAPI.Errors
{
    public class ApiException
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Detail { get; set; }

        public ApiException(int statusCode, string message = "Error message not set", string detail= "Error detail message not set")
        {
            StatusCode = statusCode;
            Message = message;
            Detail = detail;
        }
    }
}
