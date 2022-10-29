using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KlientDNS
{
    public class ApiServic
    {
        public string AddHost ( string nameHost , string dnsIP, string uri )
        {
            var requst = new DNSRequest()
            {
                dns = dnsIP,
                mack = nameHost
            };
            var jcontent = JsonConvert.SerializeObject(requst);
            return  WebRequestPost(uri + "/api/LoclDNS/AddDns", jcontent);

        }

        public bool IsCangeDNS(string nameHost, string dnsIP, string uri)
        {
            var requst = new DNSRequest()
            {
                dns = dnsIP,
                mack = nameHost
            };
            var jcontent = JsonConvert.SerializeObject(requst); 
            var  r =  WebRequestPost(uri +"/api/LoclDNS/IsCangeDNS", jcontent);
           
            if(r == "false")
               return false;
            else
                return true;
        }


        public  bool IsHost(string nameHost, string dnsIP, string uri)
        {
            var requst = new DNSRequest()
            {
                dns = dnsIP,
                mack = nameHost
            };
            var jcontent = JsonConvert.SerializeObject(requst);
            var r = WebRequestPost(uri + "/api/LoclDNS/IsAddDNS", jcontent);
            if (r == "false")
                return false;
            else
                return true;
        }


        public string GetNewDNS(string nameHost, string dnsIP, string uri)
        {
            var requst = new DNSRequest()
            {
                dns = dnsIP,
                mack = nameHost
            };
            var jcontent = JsonConvert.SerializeObject(requst);
            var r = WebRequestPost(uri + "/api/LoclDNS/GetNewDNS", jcontent);
            return r;
        }



        private string WebRequestPost(string uri, string requst)
        {
            try
            {
                var client = new RestClient(uri);
                var request = new RestRequest();
                request.Method = Method.Post;
                request.AddHeader("Content-Type", "application/json");
                var body = requst;

                request.AddParameter("application/json", body, ParameterType.RequestBody);
                RestResponse response = client.Execute(request);
                return  response.Content;
            }
            catch (Exception ex)
            {
                return  ex.Source;
            }



        }
    }
}
