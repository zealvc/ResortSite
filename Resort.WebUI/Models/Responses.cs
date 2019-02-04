using System.Collections.Generic;
using System.Net;

namespace Resort.WebUI.Models
{
    public class Responses
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public IEnumerable<Responses> Errors { get; set; }

        public Responses(HttpStatusCode code)
        {
            Code = (int)code;
            Errors = new List<Responses>();
        }
    }
}