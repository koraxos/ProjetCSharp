using Projet_DotNet.Modele;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Projet_DotNet.Controleur;
namespace Projet_DotNet
{
    public partial class Form_EndGame : Form
    {
        Form_Menu menu;
        Jeu jeu;


        public Form_EndGame(Form_Menu menu, Jeu j,  bool entrainement)
        {
            InitializeComponent();
            this.jeu = j;
            this.menu = menu;

            // On envoie les résultats du test a la BDD

            if (Controleur.ControleurConnexion.getInstance().envoie_test(jeu))
            {
                // Le test s'est bien envoyé, on met a jour l'eleve + l'eleve dans la BDD
                if (jeu.getScore() > 17 && entrainement == false)
                {
                    // Le test est réussi
                    jeu.getEleve().setNbTest(jeu.getEleve().getNbtest() + 1);
                    // 3 tests réussi ? On passe au niveau suivant !
                    if (jeu.getEleve().getNbtest() == 3)
                    {
                        jeu.getEleve().setNbTest(0);
                        if (jeu.getEleve().getDifficulte() == 0)
                            jeu.getEleve().setDifficulte(1);
                        else
                        {
                            jeu.getEleve().setDifficulte(0);
                            jeu.getEleve().setProfil(jeu.getEleve().getProfil() + 1);
                        }
                    }
                    // L'eleve étant mis a jour, il faut le mettre a jour dans la BDD
                    Controleur.ControleurConnexion.getInstance().MAJEleve(jeu.getEleve());
                }
            }
            else
            {
                // Le test ne s'est pas inseré correctement dans la BDD, on ne fait rien pour le moment ?
            }

            if (entrainement)
                label1.Text = "Bravo ! Tu as fini cet entrainement ! Tu peux maintenant regarder la correction";
        }

        private void button_corr_Click(object sender, EventArgs e)
        {
            Form_Correction corr = new Form_Correction(menu, jeu);
            corr.Show();
            this.Close();
        }

        private void button_menu_Click(object sender, EventArgs e)
        {
            menu.Show();
            this.Close();
        }
    }
}
