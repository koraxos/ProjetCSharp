    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.ServiceModel.Web;
    using System.Data.SqlClient;
    using System.Data;
    using System.Text;


    namespace ProjetCsharp
    {
        // AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
        public class Logger : ILogger
        {
            private DataSource dataSource= new DataSource();
            private string logCommand = "SELECT id_enfant , prenom , nom" +
                                             " FROM ENFANT" +
                                             " WHERE prenom=@prenom AND nom=@nom";

            public List<string> log(string name, string prenom)
            {
                SqlCommand cmd=new SqlCommand(logCommand);
                dataSource.openDataSource();
                cmd.Connection = dataSource.getDataSource();

                SqlDataReader result;
                List<string> answer = new List<string>();

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
                        answer.Add(result.GetInt32(0).ToString()+result.GetString(1) + result.GetString(2));
                    }
                   // answer.Add("quelque chose");
                    dataSource.closeDataSource();
                    return answer;
                    // renvoyer l'id de l'enfant connecté
                    // renvoyer la difficulté du dernier test effectué

                }
                else
                {
                    answer.Add("rien");
                    dataSource.closeDataSource();
                    return answer;
                }
            }
        }
  }
