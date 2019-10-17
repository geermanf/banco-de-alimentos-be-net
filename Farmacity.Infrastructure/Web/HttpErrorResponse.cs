using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Farmacity.Infrastructure.Web
{
    public class HttpErrorResponse
    {
        public HttpErrorResponse()
        {
        }

        public HttpErrorResponse(HttpStatusCode statusCode)
        {
            StatusCode = (int)statusCode;
            StatusDescription = statusCode.ToString();
        }

        public HttpErrorResponse(HttpStatusCode statusCode, string requestId, string message)
            : this(statusCode)
        {
            RequestId = requestId;
            Message = message;
        }

        public string Message { get; set; }
        public int StatusCode { get; set; }
        public string StatusDescription { get; set; }
        public int? ErrorCode { get; set; }
        public object Data { get; set; }
        public string RequestId { get; set; }
        public string DetailsUrl { get; set; }
    }
}
