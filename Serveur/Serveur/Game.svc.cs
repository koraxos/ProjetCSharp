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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Game" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Game.svc or Game.svc.cs at the Solution Explorer and start debugging.
    public class Game : IGame
    {      
            
        public Stream saveTest(XmlElement xml)
        {
           // XmlSerializableServices.ReadNodes(new StringReader(xml));
            XmlDocument doc = new XmlDocument();
            //XmlReader reader;
            doc.LoadXml(xml.OuterXml);

            WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";
            string response = "<exploit/>";
            return new MemoryStream(Encoding.UTF8.GetBytes(response));

           }
    }
}
