using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.IO;
using System.Xml;
using System.Text.RegularExpressions;
using System.Net;

namespace ProjetCsharp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Historique" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Historique.svc or Historique.svc.cs at the Solution Explorer and start debugging.
    public class Historique : IHistorique
    {
        
        private DataSource dataSource = new DataSource();

        private string selectEnfants=" Select  Enf.id_enfant ,Enf.prenom , Gen.niveau, Gen.difficulte,Gen.score" +
        " from Enfant as Enf, Enfant_Hist_generale as EnfGen, Hist_generale as Gen, " +
        " Parent as Par, " +
        " Parent_Enfant as ParEnf" +
        " WHERE Par.id_parent=@id" +
        " and " +
        " ParEnf.id_enfant=Enf.id_enfant " +
        " and Enf.id_enfant=EnfGen.id_enfant" +
        " and EnfGen.id_hist_generale=Gen.id_hist_generale" ;

/*
        private string selectEnfants = " Select  Enf.id ,Enf.prenom , Gen.niveau, Gen.difficulte,Gen.score" +
        " from Enfant as Enf, Enfant_Hist_generale as EnfGen, Hist_generale as Gen, " +
        " Parent as Par, " +
        " Parent_Enfant as ParEnf" +
        " WHERE Par.id_parent=@id" +
        " and " +
        " ParEnf.id_enfant=Enf.id_enfant " +
        " and Enf.id_enfant=EnfGen.id_enfant" +
        " and EnfGen.id_hist_generale=Gen.id_hist_generale";
        */
        private string checkParentExist = " Select Parent.id_parent" +
                                        " from Parent" +
                                        " where Parent.Nom=@identifiant and Parent.mdp=@mdp";


        public XmlDocument getEnfants(string nom, string prenom,string mdp)
        {

            ServicePointManager.Expect100Continue = false;

            SqlCommand cmd = new SqlCommand(checkParentExist);
            SqlDataReader result;
            //return new XmlDocument();
            dataSource.openDataSource();
            //recupération de l'id du parent
            string parent=nom+" "+ prenom;
            SqlParameter prenomParam = cmd.Parameters.Add("@identifiant", SqlDbType.NVarChar,parent.Length);
            SqlParameter mdpParam = cmd.Parameters.Add("@mdp", SqlDbType.NVarChar, mdp.Length);
            cmd.Connection = dataSource.getDataSource();
            cmd.Parameters[0].Value = parent.Trim();
            cmd.Parameters[1].Value = mdp;
            cmd.Prepare();
            int id_parent = 0;
            id_parent = (Int32)cmd.ExecuteScalar();

            cmd =  new SqlCommand(selectEnfants);
            SqlParameter id_parent_param = cmd.Parameters.Add("@id", SqlDbType.Int);
            cmd.Connection = dataSource.getDataSource();
            cmd.Parameters[0].Value = id_parent;
            cmd.Prepare();    

            XmlDocument doc = new XmlDocument();
            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = doc.DocumentElement;
            doc.InsertBefore(xmlDeclaration, root);
            XmlElement eleves = doc.CreateElement(string.Empty, "eleves", string.Empty);

            result = cmd.ExecuteReader();

            if (result.HasRows)
            {
                int i = 0;
                while (result.Read())
                {
                    XmlElement eleve_node = doc.CreateElement(string.Empty, "eleve" + i.ToString(), string.Empty);
                    XmlElement nom_xml = doc.CreateElement(string.Empty, "id", string.Empty);
                    XmlText nom_text = doc.CreateTextNode(result.GetInt32(0).ToString());
                    nom_xml.AppendChild(nom_text);
                    /*
                    XmlElement prenom_xml = doc.CreateElement(string.Empty, "prenom", string.Empty);
                    XmlText prenom_text = doc.CreateTextNode(result.GetString(1));
                    prenom_xml.AppendChild(prenom_text);

                    XmlElement profil_xml = doc.CreateElement(string.Empty, "profil", string.Empty);
                    XmlText profil_text = doc.CreateTextNode(result.GetString(2).ToString());
                    profil_xml.AppendChild(profil_text);

                    XmlElement diff_xml = doc.CreateElement(string.Empty, "difficulte", string.Empty);
                    XmlText diff_text = doc.CreateTextNode(result.GetInt32(3).ToString());
                    diff_xml.AppendChild(diff_text);

                    XmlElement nb_test_xml = doc.CreateElement(string.Empty, "difficulte", string.Empty);
                    XmlText nb_test_text = doc.CreateTextNode(result.GetInt32(4).ToString());
                    nb_test_xml.AppendChild(nb_test_text);*/

                   /* eleve_node.AppendChild(nom_xml);
                    eleve_node.AppendChild(prenom_xml);
                    eleve_node.AppendChild(profil_xml);
                    eleve_node.AppendChild(diff_xml);
                    eleve_node.AppendChild(nb_test_xml);*/
                    eleves.AppendChild(eleve_node);
                    i++;
                }
            }

            dataSource.closeDataSource();
            doc.AppendChild(eleves);
            return doc;
        
        }
    }
}