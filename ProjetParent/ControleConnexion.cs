using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projet_DotNet.Request;
namespace ProjetParent
{
    class ControleConnexion
    {
        LoggerHttp logger = new LoggerHttp();
        public Parent parentValide(String nom, String prenom)
        {
            Parent p=null;
            int test = logger.logRequest(nom, prenom);

            if (test > 0)
                return new Parent(nom, prenom, "");
            else
            return p;
        }

        public Boolean insertionParent(Parent p)
        {
            Boolean insertionOK=true;
            // On insère le parent p dans la BD
          int test=  logger.addParent(p.Nom, p.Prenom);
          if (test > 0)
              return insertionOK;
          else
              return false;
        }

        public Eleve[] affichageEnfant(Parent p)
        {
            Eleve[] tabE= new Eleve[5];
            // on veut retourner la liste des enfants qui ont été ajoutés par le parent
            return tabE;
        }

        public Boolean insertionEnfant(Parent p,Eleve e)
        {
            // on veut ajouter un nouvel enfant
            int test;
           test= logger.addEnfant(p.Nom.Trim()+" "+p.Prenom.Trim(), e.Nom, e.Prenom);
            return test>0;
        }

        public int nombreNiveau(Eleve e)
        {
            int niveau = 3;
            // il faut récupérer le niveau de l'enfant

            return niveau;
        }
        
        

    }
}
