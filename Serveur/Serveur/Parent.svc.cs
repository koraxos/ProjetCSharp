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

namespace ProjetCsharp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Parent" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Parent.svc or Parent.svc.cs at the Solution Explorer and start debugging.
    public class Parent : IParent
    {

        private DataSource datasource = new DataSource();

        private string getEnfant="Select Enf.nom, Enf.prenom, Gen.niveau"+
" from Enfant as Enf, Parent as Par, Parent_Enfant as ParEnf, Enfant_Hist_generale as EnfGen , Hist_generale as Gen"+
" where Par.nom='sephiroth jacque' and Par.id_parent=ParEnf.id_parent and ParEnf.id_enfant=Enf.id_enfant "+
" and EnfGen.id_enfant=Enf.id_enfant and Gen.id_hist_generale=EnfGen.id_hist_generale";

        private string InsertParent = "INSERT INTO PARENT(Nom,mdp) values(@identifiant,@mdp)" +
                                      " Declare @ID bigint" +
                                      " SELECT CAST(SCOPE_IDENTITY() AS int)";

        private string InsertParentEnfant = " INSERT INTO Parent_Enfant" +
                                            " Values (@idParent,@idEnfant)";
        private string InsertHistGenerale_And_EnfantHistGen =
            " INSERT INTO Hist_generale(niveau,difficulte,score)" +
            " Values(@profil,@difficulte,@score)" +
            " Declare @ID bigint" +
            " Select @ID=SCOPE_IDENTITY()" +
            " INSERT INTO Enfant_Hist_generale(id_enfant,id_hist_generale)"+
            " Values(@identifiant,@ID)";

            private string InsertEnfant = " INSERT INTO ENFANT" +
                                      " Values(@prenom,@nom) SELECT CAST(SCOPE_IDENTITY() AS int)";

        private string checkParentExist=" Select Parent.id_parent"+
                                        " from Parent"+ 
                                        " where Parent.Nom=@identifiant and Parent.mdp=@mdp";

        private string selectEnfants = " Select  Enf.nom ,Enf.prenom , Gen.niveau, Gen.difficulte,Gen.score" +
" from Enfant as Enf, Enfant_Hist_generale as EnfGen, Hist_generale as Gen, " +
" Parent as Par, " +
" Parent_Enfant as ParEnf" +
" WHERE Par.id_parent=@id" +
" and " +
" ParEnf.id_enfant=Enf.id_enfant " +
" and Enf.id_enfant=EnfGen.id_enfant" +
" and EnfGen.id_hist_generale=Gen.id_hist_generale";



        public XmlDocument getEnfants(string nom, string prenom, string mdp)
        {


            SqlCommand cmd = new SqlCommand(checkParentExist);
            SqlDataReader result;
            //return new XmlDocument();
            datasource.openDataSource();
            //recupération de l'id du parent
            string parent = nom + " " + prenom;
            SqlParameter prenomParam = cmd.Parameters.Add("@identifiant", SqlDbType.NVarChar, parent.Length);
            SqlParameter mdpParam = cmd.Parameters.Add("@mdp", SqlDbType.NVarChar, mdp.Length);
            cmd.Connection = datasource.getDataSource();
            cmd.Parameters[0].Value = parent.Trim();
            cmd.Parameters[1].Value = mdp;
            cmd.Prepare();
            int id_parent = 0;
            id_parent = (Int32)cmd.ExecuteScalar();

            cmd = new SqlCommand(selectEnfants);
            SqlParameter id_parent_param = cmd.Parameters.Add("@id", SqlDbType.Int);
            cmd.Connection = datasource.getDataSource();
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
                     XmlElement nom_xml = doc.CreateElement(string.Empty, "nom", string.Empty);
                     XmlText nom_text = doc.CreateTextNode(result.GetString(0));
                     nom_xml.AppendChild(nom_text);

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
                     nb_test_xml.AppendChild(nb_test_text);

                     eleve_node.AppendChild(nom_xml);
                     eleve_node.AppendChild(prenom_xml);
                     eleve_node.AppendChild(profil_xml);
                     eleve_node.AppendChild(diff_xml);
                     eleve_node.AppendChild(nb_test_xml);
                     eleves.AppendChild(eleve_node);
                     i++;
                 }
            }

            datasource.closeDataSource();
            doc.AppendChild(eleves);
            return doc;

        }



        public string addEnfant(string mdp,string parent, string nom, string prenom,string profil,string difficulte)
        {
            SqlCommand cmd = new SqlCommand(checkParentExist);
            SqlDataReader result;
            datasource.openDataSource();
            //recupération de l'id du parent
            SqlParameter prenomParam = cmd.Parameters.Add("@identifiant", SqlDbType.NVarChar, parent.Length);
            SqlParameter mdpParam = cmd.Parameters.Add("@mdp", SqlDbType.NVarChar, mdp.Length);
            cmd.Connection = datasource.getDataSource();
            cmd.Parameters[0].Value = parent;
            cmd.Parameters[1].Value = mdp;
            cmd.Prepare();
            int id_parent = 0;
            id_parent =(Int32) cmd.ExecuteScalar();
            
            cmd = new SqlCommand(InsertEnfant);
            // insertion de l'enfant
            SqlParameter prenom_enfant_Param = cmd.Parameters.Add("@prenom", SqlDbType.NVarChar, prenom.Length);
            SqlParameter nom_enfant_Param = cmd.Parameters.Add("@nom", SqlDbType.NVarChar, nom.Length);
            cmd.Connection = datasource.getDataSource();
            cmd.Parameters[0].Value = prenom;
            cmd.Parameters[1].Value = nom;
            int id_enfant;
            cmd.Prepare();
            id_enfant = (Int32)cmd.ExecuteScalar();

            // insertion dans la table qui fait le lien enfant - et historique générale
            cmd = new SqlCommand(InsertHistGenerale_And_EnfantHistGen);
            SqlParameter profil_gen_param = cmd.Parameters.Add("@profil", SqlDbType.NVarChar, profil.Length);
            SqlParameter difficulte_gen_param = cmd.Parameters.Add("@difficulte", SqlDbType.Int);
            SqlParameter score_gen_param = cmd.Parameters.Add("@score", SqlDbType.Int);
            SqlParameter insert_gen_param = cmd.Parameters.Add("@identifiant", SqlDbType.NVarChar, prenom.Length);
            cmd.Connection = datasource.getDataSource();
            cmd.Parameters[0].Value = profil;
            cmd.Parameters[1].Value = difficulte;
            cmd.Parameters[2].Value = 0;
            cmd.Parameters[3].Value = id_enfant;
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            // insertion dans la table qui fait le lien enfant - parent
            cmd = new SqlCommand(InsertParentEnfant);
            SqlParameter id_enf_par = cmd.Parameters.Add("@idParent", SqlDbType.Int);
            SqlParameter id_par_param = cmd.Parameters.Add("@idEnfant", SqlDbType.Int);
            cmd.Connection = datasource.getDataSource();
            cmd.Parameters[0].Value = id_parent;
            cmd.Parameters[1].Value = id_enfant;
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            
            datasource.closeDataSource();
            return "succes";
        }

        public int addParent(string nom, string prenom, string mdp)
        {   SqlCommand cmd = new SqlCommand(InsertParent);
            int generated_id;

            datasource.openDataSource();
            SqlParameter prenomParam = cmd.Parameters.Add("@identifiant", SqlDbType.NVarChar, prenom.Length + nom.Length + 1);
            SqlParameter mdpParam = cmd.Parameters.Add("@mdp", SqlDbType.NVarChar, mdp.Length);
            cmd.Connection = datasource.getDataSource();
            cmd.Parameters[0].Value = nom + " " + prenom;
            cmd.Parameters[1].Value =mdp;
            cmd.Prepare();
            generated_id = (Int32)cmd.ExecuteScalar();
            
            datasource.closeDataSource();
           
            return generated_id;
        }

        public int logParent(string nom,string prenom,string mdp)
        {
            SqlCommand cmd = new SqlCommand(checkParentExist);
            datasource.openDataSource();
            SqlParameter prenomParam = cmd.Parameters.Add("@identifiant", SqlDbType.NVarChar, prenom.Length + nom.Length + 1);
            SqlParameter mdpParam = cmd.Parameters.Add("@mdp", SqlDbType.NVarChar, mdp.Length);
            cmd.Connection = datasource.getDataSource();
            cmd.Parameters[0].Value = nom+ " " + prenom;
            cmd.Parameters[1].Value =mdp;
            cmd.Prepare();
            int result=(Int32) cmd.ExecuteScalar();
            datasource.closeDataSource();
            if (result>0)
            {   
            return result;
            }
            else {
            return 0;
            }

        }

        public XmlElement getTest(string nom, string prenom)
        {
            XmlElement test = null;
            return test;

        }
    }
}
