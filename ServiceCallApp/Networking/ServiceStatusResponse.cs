using System;
using System.Net;
using System.Net.Http;

namespace ServiceCallApp.Networking
{
    public class ServiceStatusResponse
    {
        public HttpStatusCode theStatusCode { get; private set; }
        public HttpContent httpContent { get; set; }
        public ServiceStatusResponse(HttpStatusCode mystatusCode = HttpStatusCode.Unused, HttpContent content = null)
        {
            this.theStatusCode = mystatusCode;
            this.httpContent = content;
        }
    }
}
