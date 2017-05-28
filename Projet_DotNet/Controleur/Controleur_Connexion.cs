using Projet_DotNet.Modele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projet_DotNet.Request;
using Projet_DotNet.Modele;
namespace Projet_DotNet.Controleur
{
    public class ControleurConnexion
    {

        public static LoggerHttp logger=new LoggerHttp();
        private static JeuHttp jeuHttp = new JeuHttp();
        private static ControleurConnexion instance = null;
        private ControleurConnexion(){
        }

        public static ControleurConnexion getInstance()
        {
            if (instance == null)
                instance = new ControleurConnexion();
            return instance;
        }

        // Retourne l'eleve de la BDD si les logs sont corrects, null sinon
        public int estValide(String nom, String prenom)
        {
            return logger.logRequest(nom,prenom);
        }

        public Eleve getEleve(int id, string nom, string prenom)
        {
            int profil = 0, difficulte = 0, nb_test = 0;
            int[] result;
            result=logger.getprofilRequest(logger.logRequest(nom,prenom));
            profil=result[0];
            nb_test = result[1];
            difficulte = result[2];
            return new Eleve(nom, prenom, profil, difficulte, nb_test);
        }
        // Ajoute le Jeu J à la BDD, retourne true si l'opération a réussi, false sinon
        public bool envoie_test(Jeu j)
        {
            int validation;//si validation ==1 alors tout s'est bien passé
            validation = jeuHttp.sendJeu(j);

            return validation>0;
        }

        //Mets à jour l'eleve dans la BDD, retourne vrai ou faux comme d'hab
        public bool MAJEleve(Eleve e)
        {
            int id_eleve = logger.logRequest(e.getNom(), e.getPrenom());
            jeuHttp.majEleve(id_eleve,e.getProfil(),e.getDifficulte(),e.getNbtest());
            return true;
        }
    }
}
