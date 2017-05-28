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

    public class LoggerHttp
    {
        public LoggerHttp() { }


        public int logRequest(string name, string prenom){
            int id_enfant=0;
            try
            {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:46652/Logger.svc/?nom="+name.Trim()+"&?prenom="+prenom.Trim());
            request.ContentType = "text/xml;charset=utf-8";
            request.ContentLength = 0;
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            request.Credentials = CredentialCache.DefaultNetworkCredentials;
            request.Method = WebRequestMethods.Http.Get;
           
            WebResponse serviceRes = request.GetResponse();
            Stream stream = serviceRes.GetResponseStream();

            XmlDocument result = new XmlDocument(); result.Load(stream);
            XmlNode id = result.SelectSingleNode("//id");
            id_enfant = Int32.Parse(id.InnerText);
           }
            catch (WebException webEx) {
                WebResponse errResp = webEx.Response;
                Stream resp = errResp.GetResponseStream();
                StreamReader reader = new StreamReader(resp);
                System.Console.WriteLine(reader.ReadToEnd());
            }
            return id_enfant;
        }

        public int[] getprofilRequest(int id)
        {
            int[] retour = new int[3];
            int profil = 0;
            try { 
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:46652/Logger.svc/getProfil?id=" + id.ToString());
            request.ContentType = "text/xml;charset=utf-8";
            request.ContentLength = 0;
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            request.Credentials = CredentialCache.DefaultNetworkCredentials;
            request.Method = WebRequestMethods.Http.Get;

            WebResponse serviceRes = request.GetResponse();

            Stream stream = serviceRes.GetResponseStream();
            XmlDocument result = new XmlDocument(); result.Load(stream);
            XmlNode lvl = result.SelectSingleNode("//lvl");
            XmlNode score = result.SelectSingleNode("//score");
            XmlNode diff = result.SelectSingleNode("//difficulte");
             profil = Int32.Parse(lvl.InnerText);
            retour[0] = profil;
            retour[1] =  Int32.Parse(score.InnerText);//score
            retour[2] =  Int32.Parse(diff.InnerText);//diff
            }
            catch (WebException e)
            {
                WebResponse errResp = e.Response;
                Stream resp = errResp.GetResponseStream();
                StreamReader reader = new StreamReader(resp);
                System.Console.WriteLine(reader.ReadToEnd());
 

            }
            return retour;        
        
        }
    }
}
