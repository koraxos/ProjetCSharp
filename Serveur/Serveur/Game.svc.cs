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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Game" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Game.svc or Game.svc.cs at the Solution Explorer and start debugging.
    public class Game : IGame
    {
        private DataSource datasource = new DataSource();
        private Logger logger = new Logger();

        private string InsertTest=
            " INSERT INTO Hist_Detail(niveau,score,"+
            "Op1,Op2,Op3,Op4,Op5,Op6,Op7,Op8,Op9,Op10,Op11,Op12,Op13,Op14,Op15,Op16,Op17,Op18,Op19,Op20,"+
            "Sol1,Sol2,Sol3,Sol4,Sol5,Sol6,Sol7,Sol8,Sol9,Sol10,Sol11,Sol12,Sol13,Sol14,Sol15,Sol16,Sol17,Sol18,Sol19,Sol20)"+
            " VALUES(@niveau,@score,"+
            "@Op1,@Op2,@Op3,@Op4,@Op5,@Op6,@Op7,@Op8,@Op9,@Op10,@Op11,@Op12,@Op13,@Op14,@Op15,@Op16,@Op17,@Op18,@Op19,@Op20,"+
            "@Sol1,@Sol2,@Sol3,@Sol4,@Sol5,@Sol6,@Sol7,@Sol8,@Sol9,@Sol10,@Sol11,@Sol12,@Sol13,@Sol14,@Sol15,@Sol16,@Sol17,@Sol18,@Sol19,@Sol20)"+
            " SELECT CAST(SCOPE_IDENTITY() AS int)";
  
        private string InsertEnfHist=
        "INSERT INTO Enfant_Hist_Detail(id_enfant,id_hist) VALUES(@idEnf,@idDet)";

        private int score;
        
        private string getNiveau="Select niveau "+
    " from Hist_generale as Gen ,  Enfant_Hist_generale as EnfGen, Enfant as Enf"+
    " where Enf.prenom=@prenom and Enf.nom=@nom"+
    " and Enf.id_enfant=EnfGen.id_enfant and EnfGen.id_hist_generale=Gen.id_hist_generale";


        private string MAJ = "Select Count(*)"+
" from Hist_Detail as Det ,Enfant_Hist_Detail as EnfDet, Enfant as Enf"+
" where Det.id_hist_detail=EnfDet.id_hist"+
" and ENf.id_enfant=EnfDet.id_enfant and Enf.nom=@nom and Enf.prenom=@prenom";

        private string getIdHist = "Select Gen.id_hist_generale" +
" from  Enfant_Hist_generale as EnfGen, Hist_generale as Gen" +
" where EnfGen.id_enfant=@id and EnfGen.id_hist_generale=Gen.id_hist_generale";

        private string updateHistGen="UPDATE Hist_generale"+
" set difficulte =@difficulte, niveau=@profil,score=@nb_test"+
" where id_hist_generale=@id";
        public string majEleve(string id,string profil,string difficulte,string nb_test)
        {   
            datasource.openDataSource();

            SqlCommand cmd = new SqlCommand(getIdHist);
            int result;
            SqlParameter nomParam = cmd.Parameters.Add("@id", SqlDbType.Int);
            cmd.Connection = datasource.getDataSource();
            cmd.Parameters[0].Value = Int32.Parse(id);
            cmd.Prepare();
            result = (Int32)cmd.ExecuteScalar();
            


            cmd = new SqlCommand(updateHistGen);
            SqlParameter diffParam = cmd.Parameters.Add("@difficulte", SqlDbType.Int);
            SqlParameter profilParam = cmd.Parameters.Add("@profil", SqlDbType.Int);
            SqlParameter nb_testParam = cmd.Parameters.Add("@nb_test", SqlDbType.Int);
            SqlParameter idparam = cmd.Parameters.Add("@id", SqlDbType.Int);
            cmd.Parameters[0].Value = Int32.Parse(difficulte);
            cmd.Parameters[1].Value = Int32.Parse(profil);
            cmd.Parameters[2].Value = Int32.Parse(nb_test);
            cmd.Parameters[3].Value = (result);
            cmd.Connection = datasource.getDataSource();
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            datasource.closeDataSource();
            return "grosse fete";
        }


        //Extrait les opérandes, 1 et 2 de chaque opération 
        public string[] extractOperande(XmlDocument xml){
            string[] operandes = new string[20];
            XmlNode operation=null;
            string operande=null;
            for (int j = 0; j < 20; j++) { 

                    operande = xml.SelectSingleNode("//operations/operation" + j.ToString() + "/operande1").InnerText
                        + "*"
                        + xml.SelectSingleNode("//operations/operation"+ j.ToString() + "/operande2").InnerText;
                    operandes[j] = operande;
            }
            return operandes;
         }
        // calcul la réussite d'un test
        public int calculScore(string[] operandes, string[] resultats){
            string[] tokens= new string[20];
            for (int i = 0; i < 20; i++)
            {
                tokens = operandes[i].Split('*');
                if ((Int32.Parse(tokens[0]) * Int32.Parse(tokens[1])) == Int32.Parse(resultats[i]))
                    this.score = this.score + 1;           
            }
            return score;
        }
        // Extrait les résultat d'un test dans un tableau de string
        public string[] extractResultat(XmlDocument xml)
        {   string resultat;
            string[] resultats = new string[20];
            XmlNode operation = null;
            for (int j = 0; j < 20; j++)
            {
                resultat = xml.SelectSingleNode("//operations/operation" + j.ToString()+"/resultat").InnerText;
                resultats[j] = resultat;
            }
            return resultats;
        }

        //Fonction qui insère un test dans la base
        public string saveTest(string jeu)
        {
            string document = jeu;// on corrige les possibles erreurs d'encodage
            document = Regex.Replace(document, @"&3C", "<");
            document = Regex.Replace(document, @"&3E", ">");

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(document);
            string[] operandes;
            string[] resultats;
            int id_enfant,niveau;
            string prenom = null;
            string nom = null;


            XmlNode prenom_node =doc.SelectSingleNode("/eleve/prenom");
            XmlNode nom_node = doc.SelectSingleNode("/eleve/nom");
            XmlNode profil_node = doc.SelectSingleNode("/eleve/profil");

            prenom = prenom_node.InnerText;
           nom=nom_node.InnerText;
           niveau = Int32.Parse(profil_node.InnerText);
            // on va chercher l'id de l'enfant
            XmlNode id_node = logger.log(nom,prenom);
           id_enfant=Int32.Parse(id_node.SelectSingleNode("//id").InnerText);

            // on extrait les opérandes et les résultats du xml
            operandes = this.extractOperande(doc);
            resultats = this.extractResultat(doc);
            SqlCommand cmd = new SqlCommand(InsertTest);
            // on paramètre la requète
           SqlParameter niveau_param = cmd.Parameters.Add("@niveau", SqlDbType.Int);
           SqlParameter scoe_param = cmd.Parameters.Add("@score", SqlDbType.Int); 
           SqlParameter[] operandes_param=new SqlParameter[20];
           SqlParameter[] resultat_params = new SqlParameter[20];
            // paramètrage des opérateurs
           for (int i = 0; i < 20; i++)
           {
               operandes_param[i]=cmd.Parameters.Add("@Op"+(i+1).ToString(),SqlDbType.VarChar,operandes[i].Length);
           
           }
            // paramétrage des résultats
           for (int i = 0; i < 20; i++)
           {
               resultat_params[i] = cmd.Parameters.Add("@Sol"+(i+1).ToString(), SqlDbType.Int);
           }
            // on insère les valeurs dans les paramètres

            //niveau
            cmd.Parameters[0].Value= niveau;
            //score, on le calcul
            cmd.Parameters[1].Value= calculScore(operandes,resultats);
            //insertion des valeurs d'opérandes et de résultat
            for(int i=2;i<42;i++){
                if (i < 22){
                    cmd.Parameters[i].Value= operandes[i - 2];
                }
                 else
                    cmd.Parameters[i].Value = resultats[i - 22];
            }
            datasource.openDataSource();
            cmd.Connection = datasource.getDataSource();
            cmd.Prepare();

            // on conserve l'id généré par l'insertion du test
            int genererated_id;
            genererated_id= (Int32)cmd.ExecuteScalar();

            // on insère une ligne dans Enf_Hist_Detail pour conserver le lien entre les tables
            cmd = new SqlCommand(InsertEnfHist);

            cmd.Connection = datasource.getDataSource();
            SqlParameter id_enf = cmd.Parameters.Add("@idEnf", SqlDbType.NVarChar, prenom.Length);
            SqlParameter id_det = cmd.Parameters.Add("@idDet", SqlDbType.NVarChar, nom.Length);
            cmd.Parameters[0].Value = id_enfant;
            cmd.Parameters[1].Value = genererated_id;
            cmd.Prepare();
            cmd.ExecuteScalar();

            datasource.closeDataSource();
           
            WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";
            string response = "<exploit/>";

            return response;
           }
    }
}
