using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_DotNet.Modele
{
    // Classe définissant un jeu
    public class Jeu
    {
        // 0 : Entrainement
        // 1 : Jeu
        int type;

        Eleve eleve;

        // Un tableau de reponses
        int[] reponses;

        public Operation[] operations;
        // Et un tableau d'opérations

        // genere le Jeu en fonction de l'eleve, et l'associe à ce dernier
        public Jeu(Eleve e, int t)
        {
            eleve = e;
            type = t;

            reponses = new int[20];
            // Et on genere le test/entrainement
            GenererJeu();
        }

        private void GenererJeu()
        {
            operations = new Operation[20];
            Random r = new Random();
            int operateur1, operateur2=11, inverse;
            for (int i = 0; i < 20; i++)
            {
                
                if (eleve.getDifficulte() == 0)
                {
                    operateur1 = eleve.getProfil();
                }
                else
                {
                    operateur1 = r.Next(1, eleve.getProfil());
                }
                int anc_op2 = operateur2;

                // Histoire quand même de ne pas avoir deux fois la même opération
                while(operateur2==anc_op2)
                    operateur2 = r.Next(1, 11);
                inverse = r.Next(0, 2);
                if (inverse == 0)
                    operations[i] = new Operation(operateur1, operateur2);
                else
                    operations[i] = new Operation(operateur2, operateur1);
            }
        }

        public int getOperateur(int operation, int operateur)
        {
            return operations[operation].getOperateur(operateur);
        }

        public Operation[] getOperations()
        {
            return operations;
        }

        public Eleve getEleve()
        {
            return eleve;
        }
        public void setReponse(int rang, int reponse)
        {
            reponses[rang] = reponse;
        }

        public int getReponse(int rang)
        {
            return reponses[rang];
        }

        public int getLength()
        {
            return 20;
        }

        public int getResultat(int rang)
        {
            return operations[rang].getResultat();
        }
    }
}
