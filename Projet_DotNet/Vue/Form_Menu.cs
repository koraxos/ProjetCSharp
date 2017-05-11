using Projet_DotNet.Modele;
using Projet_DotNet.Vue;
using System;
using System.Windows.Forms;

namespace Projet_DotNet
{
    // Classe Menu
    public partial class Form_Menu : Form
    {
        // On garde l'accueil qui est toujours en mode hide
        private Accueil accueil;
        private Eleve eleve;

        // Constructeur
        public Form_Menu(Accueil acc, Eleve e)
        {
            InitializeComponent();
            this.accueil = acc;
            this.eleve = e;
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
            Form_Game jeu = new Form_Game(this, new Jeu(eleve,1), false);
            jeu.Show();
            this.Hide();
        }


        // Action click lancement d'un entrainement
        private void button_training_Click(object sender, EventArgs e)
        {
            Form_Game jeu = new Form_Game(this, new Jeu(eleve, 0), true);
            jeu.Show();
            this.Hide();
        }

        private void button_tables_Click(object sender, EventArgs e)
        {
            
            Form_Tables tables = new Form_Tables(this);
            tables.Show();
            this.Hide();
        }
    }
}
