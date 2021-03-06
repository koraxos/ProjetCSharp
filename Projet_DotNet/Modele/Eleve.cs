﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_DotNet.Modele
{
    public class Eleve
    {
        // Nom de l'eleve
        String nom;
        // Prenom de l'eleve
        String prenom;

        // Son profil, ie la table maximale sur laquelle il peut être interrogé
        int profil;

        // La difficulté su profil actuel, ie :
        // 0 : L'eleve ne peut etre interrogé QUE sur la table profil
        // 1 : L'eleve peut etre interrogé sur les tables allant de 2 à profil
        int difficulte;

        // Le nombre de test consécutifs réussi dans la difficulté actuelle
        int nb_test;

        /* Principe de tout ca :
        Si nb_test == 3 & profil <=10
            nb_test = 0
            Si difficulté==0
                difficulté = 1
            Sinon
                difficulté=0
                profil+=1
            Fsi
        FSi
        */

        public Eleve(String nom, String prenom, int profil, int difficult, int nb_test)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.profil = profil;
            this.difficulte = difficult;
            this.nb_test = nb_test;
        }
 
       // Le reste (getter, setter, fonctions utiles) est a faire

        public string getPrenom()
        {
            return prenom;
        }


        public string getNom()
        {
            return nom;
        }
        
    

        // Le reste (getter, setter, fonctions utiles) est a faire

        public int getDifficulte()
        {
            return difficulte;
        }

        public int getProfil()
        {
            return profil;
        }

        public void setNbTest(int i)
        {
            nb_test = i;
        }

        public int getNbtest()
        {
            return nb_test;
        }

        public void setDifficulte(int i)
        {
            difficulte = i;
        }

        public void setProfil(int i)
        {
            profil = i;
        }
    }
}
