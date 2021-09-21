using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HairCutAppAPI.Utilities
{
    public class CustomHttpCodeResponse
    {
        public HttpStatusCode StatusCode { get; set; }

        public string Content { get; set; }

        public bool IsSuccess { get; set; }
        
        public CustomHttpCodeResponse(HttpStatusCode statusCode, string content, bool isSuccess)
        {
            StatusCode = statusCode;
            Content = content;
            IsSuccess = isSuccess;
        }

    }
}