using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HairCutAppAPI.Utilities
{
    public class CustomHttpCodeResponse
    {
        public int StatusCode { get; set; }
        
        public bool IsSuccess { get; set; }

        public object Data { get; set; }
        
        public string Message { get; set; }
        
        public CustomHttpCodeResponse(int statusCode, string message = null, object data = null)
        {
            StatusCode = statusCode;
            IsSuccess = statusCode == 200;
            Data = data;
            Message = message;
        }

    }
}