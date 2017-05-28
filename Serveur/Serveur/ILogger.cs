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
    [ServiceContract]
    public interface ILogger
    {
        [OperationContract]
        [WebGet(UriTemplate="/?nom={nom}&?prenom={prenom}",ResponseFormat=WebMessageFormat.Xml)]
        XmlElement log(string nom,string prenom);


        [OperationContract]
        [WebGet(UriTemplate = "/getProfil?id={id}", ResponseFormat = WebMessageFormat.Xml)]
        XmlElement getProfil(string id);
    }

}
