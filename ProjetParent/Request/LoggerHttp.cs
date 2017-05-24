using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Xml;

namespace Projet_DotNet.Request
{
 /*   
        [OperationContract]
        [WebGet(UriTemplate = "/add?nom={nom}&?prenom={prenom}", ResponseFormat = WebMessageFormat.Xml)]
        XmlElement addParent(string nom, string prenom);


        [OperationContract]
        [WebGet(UriTemplate = "/log?nom={nom}&?prenom={prenom}", ResponseFormat = WebMessageFormat.Xml)]
        string logParent(string nom, string prenom);


        [OperationContract]
        [WebGet(UriTemplate = "/getTest?nom={nom}&?prenom={prenom}", ResponseFormat = WebMessageFormat.Xml)]
        XmlElement getTest(string nom, string prenom);

        [OperationContract]
        [WebGet(UriTemplate = "/addEnfant?parent={parent}&?nom={nom}&?prenom={prenom}", ResponseFormat = WebMessageFormat.Xml)]
        string addEnfant(string parent,string nom, string prenom);
    */
    class LoggerHttp
    {
        public LoggerHttp() { }


        public int logRequest(string name, string prenom){
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:46652/Parent.svc/log?nom="+name.Trim()+"&?prenom="+prenom.Trim());
            request.ContentType = "text/xml;charset=utf-8";
            request.ContentLength = 0;
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            request.Credentials = CredentialCache.DefaultNetworkCredentials;
            request.Method = WebRequestMethods.Http.Get;
            WebResponse serviceRes = request.GetResponse();
            Stream stream = serviceRes.GetResponseStream();

            XmlDocument result = new XmlDocument();   result.Load(stream);
            XmlNode id = result.SelectSingleNode("//id");
            return Int32.Parse(id.InnerText);
        }


        public int addParent(string name, string prenom)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:46652/Parent.svc/add?nom=" + name.Trim() + "&?prenom=" + prenom.Trim());
            request.ContentType = "text/xml;charset=utf-8";
            request.ContentLength = 0;
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            request.Credentials = CredentialCache.DefaultNetworkCredentials;
            request.Method = WebRequestMethods.Http.Get;
            WebResponse serviceRes = request.GetResponse();
            Stream stream = serviceRes.GetResponseStream();

            XmlDocument result = new XmlDocument(); result.Load(stream);
            XmlNode id = result.SelectSingleNode("//id");
            return Int32.Parse(id.InnerText);
        }

        public int addEnfant(string parent,string nom, string prenom)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:46652/Parent.svc/addEnfant?parent=" + parent +"?nom="+nom+"&?prenom="+prenom);
            request.ContentType = "text/xml;charset=utf-8";
            request.ContentLength = 0;
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            request.Credentials = CredentialCache.DefaultNetworkCredentials;
            request.Method = WebRequestMethods.Http.Get;
            WebResponse serviceRes = request.GetResponse();
            Stream stream = serviceRes.GetResponseStream();

            XmlDocument result = new XmlDocument(); result.Load(stream);
            XmlNode id = result.SelectSingleNode("//id");
            return Int32.Parse(id.InnerText);
        }
    }
}
