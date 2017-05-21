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
            Controleur_Jeu.sendJeu(this.jeu);

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
