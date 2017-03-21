using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projet_DotNet
{
    public partial class Form_Menu : Form
    {
        // On garde l'accueil qui est toujours en mode hide
        private Accueil accueil;

        // Constructeur
        public Form_Menu(Accueil acc)
        {
            InitializeComponent();
            this.accueil = acc;
        }

        // Action click bouton quitter
        private void button_quit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Action click bouton déconnexion
        private void button_logoff_Click(object sender, EventArgs e)
        {
            accueil.Show();
            this.Close();
        }


        // Action click lancement d'un test
        private void button_test_Click(object sender, EventArgs e)
        {
            Form_Game jeu = new Form_Game(this);
            jeu.Show();
            this.Hide();
        }


        // Action click lancement d'un entrainement
        private void button_training_Click(object sender, EventArgs e)
        {
            Form_Game jeu = new Form_Game(this, true);
            jeu.Show();
            this.Hide();
        }
    }
}
