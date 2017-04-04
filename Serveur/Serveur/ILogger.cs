using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ProjetCsharp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ILogger" in both code and config file together.
    [ServiceContract]
    public interface ILogger
    {
        [OperationContract]
        //[WebInvoke(Method="GET",UriTemplate="/?nom={name}?prenom={prenom}")]
        [WebGet(UriTemplate="/?nom={nom}&?prenom={prenom}")]
        List<string> log(string nom,string prenom);
    }
}
