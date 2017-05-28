using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.IO;
using System.Xml;
using System.Net;
namespace ProjetCsharp
{


    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IHistorique" in both code and config file together.
    [ServiceContract]
    public interface IHistorique
    {
        
        [OperationContract]
        [WebGet(UriTemplate = "/Enfants?nom={nom}&?prenom={prenom}&?mdp={mdp}")]
        XmlDocument getEnfants(string nom, string prenom, string mdp);
        
    }
}
