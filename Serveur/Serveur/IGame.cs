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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IGame" in both code and config file together.
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IGame
    {

        [OperationContract]
        [WebGet(UriTemplate = "/Maj?id={id}&?profil={profil}&?difficulte={difficulte}&?nb_test={nb_test}")]
        string majEleve(string id,string profil, string difficulte, string nb_test);


        [OperationContract]
        [WebGet(UriTemplate="/?jeu={jeu}")]
        string saveTest(string jeu);

        /*
        [OperationContract]
        [WebGet(UriTemplate = "/?maj={jeu}")]
        string saveTest(string jeu);*/
    }
}
