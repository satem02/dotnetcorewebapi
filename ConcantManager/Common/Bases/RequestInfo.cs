using System;

namespace Common.Bases
{
    public class RequestInfo
    {
        public RequestInfo() { }
        public Guid AuthorizationToken { get; set; }
        public string RequestId { get; set; }
        public string RequestType { get; set; }
        public int UserId { get; set; }
        public string UserIP { get; set; }
        public int LangId { get; set; }
        public string LangCode { get; set; }
    
    }
}