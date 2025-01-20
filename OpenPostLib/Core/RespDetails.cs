using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json.Serialization;

namespace OpenPostLib.Core
{
    public class RespDetails
    {
        public HttpStatusCode StatusCode { get; set; }
        public string ReasonPhrase { get; set; }
        public Dictionary<string, IEnumerable<string>> Headers { get; set; }
        public Dictionary<string, IEnumerable<string>> ContentHeaders { get; set; }
        public string Content { get; set; }

        public RespDetails()
        {
            Headers = new Dictionary<string, IEnumerable<string>>();
            ContentHeaders = new Dictionary<string, IEnumerable<string>>();
        }

        public static RespDetails FromHttpResponseMessage(Resp response)
        {
            return new RespDetails
            {
                StatusCode = response.StatusCode,
                ReasonPhrase = response.ReasonPhrase,
                Headers = response.Headers.Headers,
                ContentHeaders = response.ContentHeaders.Headers,
                Content = response.GetContentAsStringAsync().Result
            };
        }
    }
}