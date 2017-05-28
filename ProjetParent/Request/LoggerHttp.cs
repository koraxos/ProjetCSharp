using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Xml;

namespace ProjetParent.Request
{
    public class LoggerHttp
    {
        public LoggerHttp() { }


        public int logRequest(string name, string prenom,string mdp){
            try{
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:46652/Parent.svc/log?nom="+name.Trim()+"&?prenom="+prenom.Trim()+"&?mdp="+mdp);
            request.ContentType = "text/xml;charset=utf-8";
            request.ContentLength = 0;
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            request.Credentials = CredentialCache.DefaultNetworkCredentials;
            request.Method = WebRequestMethods.Http.Get;
            WebResponse serviceRes = request.GetResponse();
            Stream stream = serviceRes.GetResponseStream();
                
            XmlDocument result = new XmlDocument();   result.Load(stream);
            return Int32.Parse(result.DocumentElement.InnerText);

            }
            catch (WebException webEx) {
                WebResponse errResp = webEx.Response;
                Stream resp = errResp.GetResponseStream();
                StreamReader reader = new StreamReader(resp);
                System.Console.WriteLine(reader.ReadToEnd());
                return 0;            
            }
        }
            

        public int addParent(string name, string prenom,string mdp)
        {
            try{
            int id_parent;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:46652/Parent.svc/add?nom=" + name.Trim() + "&?prenom=" + prenom.Trim()+"&?mdp="+mdp.ToString());
            request.ContentType = "text/xml;charset=utf-8";
            request.ContentLength = 0;
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            request.Credentials = CredentialCache.DefaultNetworkCredentials;
            request.Method = WebRequestMethods.Http.Get;
            WebResponse serviceRes = request.GetResponse();
            Stream stream = serviceRes.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            XmlDocument doc= new XmlDocument();
            doc.LoadXml(reader.ReadToEnd());
            id_parent =Int32.Parse(doc.DocumentElement.InnerText);
             return id_parent;
            
            }
            catch (WebException webEx) {
                WebResponse errResp = webEx.Response;
                Stream resp = errResp.GetResponseStream();
                StreamReader reader = new StreamReader(resp);
                System.Console.WriteLine(reader.ReadToEnd());
                return 0;
            }

        }

        public string addEnfant(string mdp,string parent,string nom, string prenom,string profil,string difficulte)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:46652/Parent.svc/addEnfant?mdp="+mdp+"&?parent=" + parent + "&?nom=" + nom + "&?prenom=" + prenom+"&?profil="+profil+ "&?difficulte="+difficulte);
                request.ContentType = "text/xml;charset=utf-8";
                request.ContentLength = 0;
                request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                request.Credentials = CredentialCache.DefaultNetworkCredentials;
                request.Method = WebRequestMethods.Http.Get;
                WebResponse serviceRes = request.GetResponse();
                Stream stream = serviceRes.GetResponseStream();
                System.Console.WriteLine();
                return new StreamReader(stream).ReadToEnd();
            }
            catch (WebException webEx)
            {
                WebResponse errResp = webEx.Response;
                Stream resp = errResp.GetResponseStream();
                StreamReader reader = new StreamReader(resp);
                System.Console.WriteLine(reader.ReadToEnd());
                return "echec";

            }
        }
    }
}
