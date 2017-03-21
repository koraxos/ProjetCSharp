using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.SqlClient;

namespace ProjetCsharp
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" dans le code
    // , le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc 
    //ou Service1.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class Service1 : IService1
    {

        SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename='\\\\etuln.stockage.univ-lorraine.fr\\mertz12u\\Documents\\Visual Studio 2013\\Projects\\ProjetCsharp\\ProjetCsharp\\App_Data\\MyDatabase.mdf';Integrated Security=True");

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }



        public string test(string test_int)
        {
            if (test_int.Equals("4"))
                return test_int;
            else
                return "valeur différente de 4";
        }

        public List<double> message(int A)
        {
            List<double> res = new List<double>();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT id_parent FROM Parent;", conn);

                conn.Open();
                SqlDataReader rd;
                rd = cmd.ExecuteReader();

                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        res.Add(rd.GetInt32(0));
                    }
                }
                else
                {
                    res.Add(0);
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("SQLException :" + e);
            }
            return res;
        }
    }
}
