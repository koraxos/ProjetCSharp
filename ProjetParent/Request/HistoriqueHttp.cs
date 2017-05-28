using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Xml;
using ProjetParent;

namespace ProjetParent.Request
{
    class HistoriqueHttp
    {
        Parent p;
        
        public HistoriqueHttp() { }

        //ServicePointManager.SecurityProtocol=SecurityProtocolType.Tls12;

        public class ExtendedWebClient : WebClient
        {
            public int Timeout { get; set; }

            protected override WebRequest GetWebRequest(Uri address)
            {
                HttpWebRequest request = (HttpWebRequest)base.GetWebRequest(address);
                if (request != null)
                    request.Timeout = Timeout;
                request.KeepAlive = false;
                request.ProtocolVersion = HttpVersion.Version10;
                return request;
            }

            public ExtendedWebClient()
            {
                Timeout = 10000000;
            }
        }

        public Eleve[] getElevesParent(Parent P){
            ExtendedWebClient HttpRequest = new ExtendedWebClient();
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:46652/Parent.svc/Enfants?nom=" + P.Nom + "&?prenom=" + P.Prenom + "&?mdp=" + P.Motdepasse);
                System.Console.WriteLine(HttpRequest.ToString());
                request.ContentType = "text/plain;charset=utf-8";
                request.ContentLength = 0;
                request.Accept = "text/html,application/xhtml+xml,application/xml;";
                request.Credentials = CredentialCache.DefaultNetworkCredentials;
                request.Method = WebRequestMethods.Http.Get;
                request.KeepAlive = true;
                request.MaximumResponseHeadersLength=200000000;
             request.Timeout = 100000000;
             request.MaximumResponseHeadersLength = 5000000;
             System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11;
                request.ReadWriteTimeout = 100000000;
                ServicePointManager.Expect100Continue = false;
                WebResponse serviceRes = request.GetResponse();
                Stream stream = serviceRes.GetResponseStream();
                // ici transformer le xml en une liste d'élève
                XmlDocument result = new XmlDocument();
                result.Load(stream);
                return null;
                
            }
            catch (WebException webEx)
            {
                WebResponse errResp = webEx.Response;
                Stream resp = errResp.GetResponseStream();
                StreamReader reader = new StreamReader(resp);
                System.Console.WriteLine(reader.ReadToEnd());
                return null;
            }
        }

    }
}
