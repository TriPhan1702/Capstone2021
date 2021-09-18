namespace HairCutAppAPI.Utilities.Errors
{
    public class ApiException
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Detail { get; set; }

        public ApiException(int statusCode, string message = "Error message not set", string detail = "Error detail message not set")
        {
            StatusCode = statusCode;
            Message = message;
            Detail = detail;
        }
    }
}