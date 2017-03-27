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
        public class Logger : ILogger
        {
            private DataSource dataSource;
            private SqlConnection conn;
            private SqlCommand cmd=new SqlCommand();
            private string logCommand="SELECT id , prenom , nom"+
                                          "FROM ENFANT"  +
                                          "WHERE prenom=@prenom and nom=@nom";


            public void log(string name, string prenom)
            {
                SqlDataReader result;
                List<string> answer= new List<string>();

                try { 

                dataSource = new DataSource();
                conn= dataSource.getDataSource();
                cmd.Connection = conn;

                SqlParameter nomParam = new SqlParameter("@nom", SqlDbType.NVarChar);
                SqlParameter prenomParam = new SqlParameter("@prenom", SqlDbType.NVarChar);

                nomParam.Value = name;
                prenomParam.Value = prenom;

                cmd.Parameters.Add(nomParam);
                cmd.Parameters.Add(prenomParam);
                    
                cmd.Prepare();
                result=cmd.ExecuteReader();

                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        answer.Add(result.GetString(0) + result.GetString(1));
                    }
                }
                else
                {
                   answer = null;
                }

                Console.WriteLine(answer);
                }
                catch(Exception e)
                {
                    Console.WriteLine("Exception dans logger:" + e);
                }
            }
        }
  }
