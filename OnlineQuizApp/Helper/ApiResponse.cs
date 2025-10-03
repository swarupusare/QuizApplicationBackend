using System.Net;

namespace OnlineQuizApp.Helper
{
    public class ApiResponse
    {
        public bool status { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        public dynamic? Data { get; set; }

        public List<ExceptionMessage> Errors { get; set; }

        public ApiResponse()
        {
            Errors = new List<ExceptionMessage>();
        }
    }
}
