using Projet_DotNet.Modele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projet_DotNet.Request;
using Projet_DotNet.Modele;
namespace Projet_DotNet.Controleur_Connexion
{
    public class ControleurConnexion
    {

        static LoggerHttp logger=new LoggerHttp();

        public ControleurConnexion(){

        }
        // Retourne l'eleve de la BDD si les logs sont corrects, null sinon
        public static int estValide(String nom, String prenom)
        {
            return logger.logRequest(nom,prenom);
        }

        public static Eleve getEleve(int id, string nom, string prenom)
        {
            int profil = 0, difficulte = 0, nb_test = 0;
            logger.getprofilRequest(id, profil, nb_test);
            return new Eleve(nom, prenom, profil, difficulte, nb_test);
        }
        // Ajoute le Jeu J à la BDD, retourne true si l'opération a réussi, false sinon
        static bool envoie_test(Jeu j)
        {
            return false;
        }

        //Mets à jour l'eleve dans la BDD, retourne vrai ou faux comme d'hab
        static bool MAJEleve(String nom)
        {
            return true;
        }
    }
}
