using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Xml;
using Projet_DotNet.Modele;

namespace Projet_DotNet.Request
{
    class JeuHttp
    {
        Operation[] operations=new Operation[20];
        Eleve eleve;
        public JeuHttp() { }


        public int sendJeu(Jeu j){

            operations = j.getOperations();
            eleve = j.getEleve();

            XmlDocument doc = new XmlDocument();
            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = doc.DocumentElement;
            doc.InsertBefore(xmlDeclaration, root);

            XmlElement eleve_node = doc.CreateElement(string.Empty, "eleve", string.Empty);
            XmlElement nom = doc.CreateElement(string.Empty, "nom", string.Empty);
            XmlText nom_text = doc.CreateTextNode(eleve.getNom());
            nom.AppendChild(nom_text);

            XmlElement prenom = doc.CreateElement(string.Empty, "prenom", string.Empty);
            XmlText prenom_text = doc.CreateTextNode(eleve.getPrenom());
            prenom.AppendChild(prenom_text);

            eleve_node.AppendChild(nom);
            eleve_node.AppendChild(prenom);

            doc.AppendChild(eleve_node);

            XmlElement operations_node = doc.CreateElement(string.Empty, "operations", string.Empty);
            for(int i=0; i<20; i++)
            {
                operations[i] = new Operation(1, 1);
                XmlElement operation =doc.CreateElement(string.Empty, "operation"+i.ToString(), string.Empty);

                XmlElement operande1 = doc.CreateElement(string.Empty, "operande1", string.Empty);
                XmlText operande1_text = doc.CreateTextNode(operations[i].getOperateur(0).ToString());
                operande1.AppendChild(operande1_text);
                
                XmlElement operande2 = doc.CreateElement(string.Empty, "operande2", string.Empty);
                XmlText operande2_text = doc.CreateTextNode(operations[i].getOperateur(1).ToString());
                operande2.AppendChild(operande2_text);
                
                XmlElement resultat = doc.CreateElement(string.Empty, "resultat", string.Empty);
                XmlText resultat_text = doc.CreateTextNode(operations[i].getResultat().ToString());   
                resultat.AppendChild(resultat_text);

                operation.AppendChild(operande1);
                operation.AppendChild(operande2);
                operation.AppendChild(resultat);

                operations_node.AppendChild(operation);

            }

            eleve_node.AppendChild(operations_node);

            byte[] byteArray = Encoding.UTF8.GetBytes(doc.InnerXml);
            //transmettre les operations au serveur avec le test et l'élève
            // 
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:46652/Game.svc/addJeu");
            request.ContentType = "text/xml;charset=utf-8;";
            request.ContentLength = byteArray.Length;
            request.Credentials = CredentialCache.DefaultNetworkCredentials;
            request.Method = WebRequestMethods.Http.Post;
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(byteArray,0,byteArray.Length);
            requestStream.Close();

            HttpWebResponse serviceRes =(HttpWebResponse) request.GetResponse();
            if (serviceRes.StatusCode == HttpStatusCode.OK)
                return 1;
            else
                return 0;
            /*
            Stream stream = serviceRes.GetResponseStream();
            XmlDocument result = new XmlDocument();   result.Load(stream);
            XmlNode id = result.SelectSingleNode("//id");
            return Int32.Parse(id.InnerText);*/
        }

     }
}
