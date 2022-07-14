using System.Net;

namespace ADPtask.Models
{
    public class SubmitResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
    }
}
