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
        [WebGet(UriTemplate = "/Enfants?nom={nom}&?prenom={prenom}&?mdp={mdp}")]
        XmlDocument getEnfants(string nom, string prenom, string mdp);
        

        [OperationContract]
        [WebGet(UriTemplate = "/add?nom={nom}&?prenom={prenom}&?mdp={mdp}", ResponseFormat = WebMessageFormat.Xml)]
        int addParent(string nom, string prenom, string mdp);


        [OperationContract]
        [WebGet(UriTemplate = "/log?nom={nom}&?prenom={prenom}&?mdp={mdp}", ResponseFormat = WebMessageFormat.Xml)]
        int logParent(string nom, string prenom,string mdp);


        [OperationContract]
        [WebGet(UriTemplate = "/getTest?nom={nom}&?prenom={prenom}", ResponseFormat = WebMessageFormat.Xml)]
        XmlElement getTest(string nom, string prenom);

        [OperationContract]
        [WebGet(UriTemplate = "/addEnfant?mdp={mdp}&?parent={parent}&?nom={nom}&?prenom={prenom}&?profil={profil}&?difficulte={difficulte}", ResponseFormat = WebMessageFormat.Xml)]
        string addEnfant(string mdp,string parent,string nom, string prenom,string profil,string difficulte);

    }
}
