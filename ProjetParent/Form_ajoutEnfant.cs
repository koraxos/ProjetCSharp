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
    public partial class Form_AjoutEnfant : Form
    {
        Parent p;
        public Form_AjoutEnfant(Parent p)
        {
            this.p = p;
            InitializeComponent();
        }

        private void annuler_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void ajouterE_Click(object sender, EventArgs e)
        {
            if (nomEnfant.Text != "" && prenomEnfant.Text != "" && profilEnfant.Text!="" && Int32.Parse(profilEnfant.Text)>=1)
            {
                Eleve eleve = new Eleve(nomEnfant.Text, prenomEnfant.Text, Int32.Parse(profilEnfant.Text),0,0);
                // On insère l'enfant dans la Base de données 
                ControleConnexion cc = new ControleConnexion();
                cc.insertionEnfant(p,eleve);

                // On ferme la fenêtre et on revient la fenêtre principale du parent
                this.Dispose();
            }
            else
                MessageBox.Show("Veuillez remplir tous les champs");
        }
    }
}
