    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.ServiceModel.Web;
    using System.Data.SqlClient;
    using System.Data;
    using System.Text;
    using System.Xml;
using System.IO;

    namespace ProjetCsharp
    {
        // AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
        public class Logger : ILogger
        {
            private DataSource dataSource= new DataSource();
            private string logCommand = "SELECT id_enfant" +
                                             " FROM ENFANT" +
                                             " WHERE prenom=@prenom AND nom=@nom";

            private string profilCommand = "Select Gen.niveau as lvl,  Gen.score " +
" from Hist_generale as Gen, Enfant_Hist_generale as EnfGen, Enfant as Enf" +
" where @id_enf=EnfGen.id_enfant and EnfGen.id_hist_generale=Gen.id_hist_generale";

            private XmlElement erreur(string message)
            {
                XmlDocument answer = new XmlDocument();
                XmlElement erreur = answer.CreateElement(string.Empty, "Erreur", string.Empty);
                XmlText erreur_text = answer.CreateTextNode(message);
                erreur.AppendChild(erreur_text);
                return answer.DocumentElement;

            }

            private XmlDocument genericXml()
            {
                XmlDocument answer = new XmlDocument();
                XmlDeclaration xmlDeclaration = answer.CreateXmlDeclaration("1.0", "UTF-8", null);
                XmlElement root = answer.DocumentElement;
                answer.InsertBefore(xmlDeclaration, root);
                return answer;
            }

            public XmlElement getProfil(string id)
            {
                SqlDataReader result;
                List<string> temp = new List<string>();

                XmlDocument answer = genericXml();
                SqlCommand cmd = new SqlCommand(profilCommand);
                dataSource.openDataSource();
                cmd.Connection = dataSource.getDataSource();

                SqlParameter prenomParam = cmd.Parameters.Add("@id_enf", SqlDbType.NVarChar, id.Length);
                cmd.Parameters[0].Value = id;
                cmd.Prepare();
                result = cmd.ExecuteReader();
                   
                if (result.HasRows)
                   {
                       while (result.Read())
                       {
                           temp.Add(result.GetString(0));//lvl
                           temp.Add(result.GetInt32(1).ToString());//score
                       }

                        string[] _temp = temp.ToArray();
                        dataSource.closeDataSource();
                        XmlElement profil = answer.CreateElement(string.Empty, "profil", string.Empty);
                        answer.AppendChild(profil);

                        XmlElement lvl = answer.CreateElement(string.Empty, "lvl", string.Empty);
                        XmlText lvl_text = answer.CreateTextNode(_temp[0]);
                        lvl.AppendChild(lvl_text);


                        XmlElement score = answer.CreateElement(string.Empty, "score", string.Empty);
                        XmlText score_text = answer.CreateTextNode(_temp[1]);
                        score.AppendChild(score_text);


                        profil.AppendChild(lvl);
                        profil.AppendChild(score);

                        return answer.DocumentElement;
                    }
                else
                {
                    dataSource.closeDataSource();
                    return erreur("aucun résultat");
                }
            }
            public XmlElement log(string name, string prenom)
            {               
                SqlDataReader result;
                List<string> temp=new List<string>();

                XmlDocument answer = genericXml();
                SqlCommand cmd = new SqlCommand(logCommand);
                dataSource.openDataSource();
                cmd.Connection = dataSource.getDataSource();

                SqlParameter prenomParam = cmd.Parameters.Add("@prenom", SqlDbType.NVarChar,prenom.Length);
                SqlParameter nomParam = cmd.Parameters.Add("@nom", SqlDbType.NVarChar,name.Length);

                cmd.Parameters[0].Value = prenom;
                cmd.Parameters[1].Value = name;
                cmd.Prepare();
                    
                result=cmd.ExecuteReader();

                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        temp.Add(result.GetInt32(0).ToString());//id
                    }

                    string[] _temp=temp.ToArray();
                    dataSource.closeDataSource();
                    XmlElement profil= answer.CreateElement(string.Empty,"profil",string.Empty);
                    answer.AppendChild(profil);

                    XmlElement idEnfant=answer.CreateElement(string.Empty,"id",string.Empty);
                    XmlText id_text = answer.CreateTextNode(_temp[0]);
                    idEnfant.AppendChild(id_text);

                    profil.AppendChild(idEnfant);
                  
                    return answer.DocumentElement;   
                }
                else
                {

                    dataSource.closeDataSource();
                    return erreur("0");
                }
            }
        }
  }
