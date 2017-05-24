using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.IO;
using System.Xml;

namespace ProjetCsharp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IParent" in both code and config file together.
    [ServiceContract]
    public interface IParent
    {
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

    }
}
