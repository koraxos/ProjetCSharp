using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetParent.Request;
namespace ProjetParent
{
    public class ControleConnexion
    {
        LoggerHttp logger = new LoggerHttp();
        HistoriqueHttp historique= new HistoriqueHttp();


        public Parent parentValide(String nom, String prenom,string mdp)
        {
            Parent p=null;
            int id_parent = logger.logRequest(nom, prenom,mdp);

            if (id_parent > 0)
                return new Parent(nom, prenom, mdp);
            else
            return p;
        }

        public Boolean insertionParent(Parent p)
        {
            Boolean insertionOK=true;
            // On insère le parent p dans la BD
          int id_parent=  logger.addParent(p.Nom, p.Prenom,p.Motdepasse);
          if (id_parent > 0)
              return insertionOK;
          else
              return false;
        }

        
        public Boolean insertionEnfant(Parent p,Eleve e)
        {
            // on veut ajouter un nouvel enfant
            string test;
           test= logger.addEnfant(p.Motdepasse,p.Nom.Trim()+" "+p.Prenom.Trim(), e.Nom, e.Prenom,e.getProfil().ToString(),e.getDifficulte().ToString());
           return test.Equals("succes");
        }

        public Eleve[] affichageEnfant(Parent p)
        {
            Eleve[] tabE = new Eleve[5];
            tabE = historique.getElevesParent(p);
            // on veut retourner la liste des enfants qui ont été ajoutés par le parent
            return tabE;
        }


        public int nombreNiveau(Eleve e)
        {
            int niveau = 3;
            // il faut récupérer le niveau de l'enfant

            return niveau;
        }
    }
}
