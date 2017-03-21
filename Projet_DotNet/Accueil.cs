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

    public partial class Accueil : Form
    {
        
        // Constructeur
        public Accueil()
        {
            InitializeComponent();
        }


        // Action click bouton quitter
        private void button_leave_Click(object sender, EventArgs e)
        {
            // On quitte l'application
            Application.Exit();
        }


        // Action click bouton Se connecter
        private void button_login_Click(object sender, EventArgs e)
        {
            // On crée une form dédiée au login, et on cache l'accueil
            Form_Login log = new Form_Login(this);
            log.Show();
            this.Hide();
        }
    }
}
