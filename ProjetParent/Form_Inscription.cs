using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetParent
{
    public partial class Form_Inscription : Form
    {
        public Form_Inscription()
        {
            InitializeComponent();
        }

        private void quitter_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void inscrire_Click(object sender, EventArgs e)
        {
            if (prenomParent.Text != "" && nomParent.Text != "" && motdepasse.Text!= "")
            {
                // on crée un nouveau parent
                Parent p = new ProjetParent.Parent(nomParent.Text, prenomParent.Text, motdepasse.Text);
                // On insère le nouveau parent la BD avec une requête
                ControleConnexion cc = new ControleConnexion();
                Boolean insertOK = cc.insertionParent(p);
                // On ferme la fenêtre et on revient à la fenêtre de départ
                this.Dispose();
            }
            else
                MessageBox.Show("Veuillez remplir tous les champs");
        }
    }
}
