using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ApiHandlers
{
    public class GetRequestHandler
    {
        private HttpWebRequest _request;

        private string _address;

        public Dictionary<string, string> Headers { get; set; }

        public string Response { get; set; }

        public string Accept { get; set; }

        public string Host { get; set; }

        public string Referer { get; set; }

        public string UserAgent { get; set; }

        public string Data { get; set; }

        public string ContentType { get; set; }

        public WebProxy Proxy { get; set; }


        public GetRequestHandler(string address)
        {
            _address = address;
            Headers = new Dictionary<string, string>();
        }

        public void Run(CookieContainer cookieContainer)
        {
            _request = (HttpWebRequest)WebRequest.Create(_address); 
            
            _request.CookieContainer = cookieContainer;

            foreach (var pair in Headers)
            {
                _request.Headers.Add(pair.Key, pair.Value);
            }

            try
            {
                HttpWebResponse response = (HttpWebResponse)_request.GetResponse();
                var stream = response.GetResponseStream();
                if (stream != null)
                {
                    Response = new StreamReader(stream).ReadToEnd();
                }
            }
            catch
            {

            }
        }
    }
}