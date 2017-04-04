using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace ProjetCsharp
{
    public class DataSource
    {
        
        SqlConnection conn;

        public DataSource()
        {
            
          //conn= new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename='\\\\etuln.stockage.univ-lorraine.fr\\mertz12u\\Documents\\Visual Studio 2013\\Projects\\ProjetCsharp\\ProjetCsharp\\App_Data\\MyDatabase.mdf';Integrated Security=True");
          conn= new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename='C:\\Users\\MERTZ\\Documents\\Visual Studio 2013\\Projects\\Projet_DotNet\\Serveur\\Serveur\\App_Data\\MyDatabase.mdf';Integrated Security=True");

        }

        public SqlConnection getDataSource(){    
            return this.conn;
        }

        public void openDataSource(){
            this.conn.Open();
        }

        public void closeDataSource()
        {
            this.conn.Close();
        }
    }
}