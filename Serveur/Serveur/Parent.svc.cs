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

        private string InsertParent = "INSERT INTO PARENT(Nom) values(@identifiant)" +
                                      " Declare @ID bigint" +
                                      " SELECT CAST(SCOPE_IDENTITY() AS int)";

        private string InsertParentEnfant = " INSERT INTO Parent_Enfant" +
                                            " Values (@idParent,@idEnfant)";
        private string InsertHistGenerale_And_EnfantHistGen =
            " INSERT INTO Hist_generale(niveau,score)" +
            " Values(2,0)" +
            " Declare @ID bigint" +
            " Select @ID=SCOPE_IDENTITY()" +
            " INSERT INTO Enfant_Hist_generale(id_enfant,id_hist_generale)"+
            " Values(@identifiant,@ID)";

            private string InsertEnfant = " INSERT INTO ENFANT" +
                                      " Values(@prenom,@nom) SELECT CAST(SCOPE_IDENTITY() AS int)";

        private string checkParentExist=" Select Parent.id_parent"+
                                        " from Parent"+ 
                                        " where Parent.Nom=@identifiant";


        public string addEnfant(string parent, string nom, string prenom)
        {
            SqlCommand cmd = new SqlCommand(checkParentExist);

            SqlDataReader result;
            datasource.openDataSource();
            //recupération de l'id du parent
            SqlParameter prenomParam = cmd.Parameters.Add("@identifiant", SqlDbType.NVarChar, prenom.Length + nom.Length);
            cmd.Connection = datasource.getDataSource();
            cmd.Parameters[0].Value = nom + " " + prenom;
            cmd.Prepare();
            int id_parent = 0;
            result = cmd.ExecuteReader();
            if (result.HasRows)
            {
                while (result.Read())
                {
                    id_parent = result.GetInt32(0);
                }
            }
            result.Close();
            cmd = new SqlCommand(InsertEnfant);
            // insertion de l'enfant
            SqlParameter prenom_enfant_Param = cmd.Parameters.Add("@prenom", SqlDbType.NVarChar, prenom.Length);
            SqlParameter nom_enfant_Param = cmd.Parameters.Add("@nom", SqlDbType.NVarChar, nom.Length);
            cmd.Connection = datasource.getDataSource();
            cmd.Parameters[0].Value = prenom;
            cmd.Parameters[1].Value = nom;
            int id_enfant;
            id_enfant = (Int32)cmd.ExecuteScalar();

            cmd = new SqlCommand(InsertHistGenerale_And_EnfantHistGen);
            SqlParameter insert_gen_param = cmd.Parameters.Add("@identifiant", SqlDbType.NVarChar, prenom.Length);
            cmd.Connection = datasource.getDataSource();
            cmd.Parameters[0].Value = id_enfant;
            cmd.ExecuteScalar();
            
            cmd = new SqlCommand(InsertParentEnfant);
            SqlParameter id_enf_par = cmd.Parameters.Add("@idParent", SqlDbType.Int);
            SqlParameter id_par_param = cmd.Parameters.Add("@idEnfant", SqlDbType.Int);
            cmd.Connection = datasource.getDataSource();
            cmd.Parameters[0].Value = id_enfant;
            cmd.Parameters[1].Value = id_parent;
            cmd.ExecuteScalar();
            
            datasource.closeDataSource();
            return "succes";
        }

        public XmlElement addParent(string nom, string prenom)
        {   SqlCommand cmd = new SqlCommand(InsertParent);
            int generated_id;

            datasource.openDataSource();
            SqlParameter prenomParam = cmd.Parameters.Add("@identifiant", SqlDbType.NVarChar, prenom.Length + nom.Length+1);
            cmd.Connection = datasource.getDataSource();
            cmd.Parameters[0].Value = nom +" "+ prenom;
            cmd.Prepare();
            generated_id = (Int32)cmd.ExecuteScalar();
            
            datasource.closeDataSource();
           
            XmlElement test= null;
            return test;
        }

        public string logParent(string nom, string prenom)
        {
            SqlCommand cmd = new SqlCommand(checkParentExist);
            SqlDataReader result;
            datasource.openDataSource();
            SqlParameter prenomParam = cmd.Parameters.Add("@identifiant", SqlDbType.NVarChar, prenom.Length + nom.Length+1);
            cmd.Connection = datasource.getDataSource();
            cmd.Parameters[0].Value = nom.Trim() + " " + prenom.Trim();
            cmd.Prepare();
            result = cmd.ExecuteReader();
            if (result.HasRows)
            {   datasource.closeDataSource();
                return "succes";
            }
            else {
                datasource.closeDataSource();
                return "erreur";
            }

        }

        public XmlElement getTest(string nom, string prenom)
        {
            XmlElement test = null;
            return test;

        }
    }
}
