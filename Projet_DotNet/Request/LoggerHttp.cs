using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace Projet_DotNet.Request
{

    class LoggerHttp
    {
        public string logRequest(string name, string prenom){
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:46652/Logger.svc/");
            request.ContentType = "text/xml;charset=utf-8";
            request.ContentLength = 0;
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            request.Credentials = CredentialCache.DefaultNetworkCredentials;
            request.Method = WebRequestMethods.Http.Post;
            WebResponse serviceRes = request.GetResponse();
            StreamReader reader = new StreamReader(serviceRes.GetResponseStream());
            var result = reader.ReadToEnd();

            return result;
        }

    }
}
