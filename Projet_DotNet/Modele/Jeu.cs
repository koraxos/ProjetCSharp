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

        Operation[] operations;
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

            for(int i=0; i<20; i++)
            {
                operations[i] = new Operation(1, 1);
            }
        }

        public int getOperateur(int operation, int operateur)
        {
            return operations[operation].getOperateur(operateur);
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
