﻿using System;
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
        [WebInvoke(Method="POST",
            UriTemplate = "/addJeu", RequestFormat = WebMessageFormat.Xml)]
        Stream saveTest(XmlElement xml);
    }
}