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
    public partial class Form_ConnexionParent : Form
    {
        public Form_ConnexionParent()
        {
            InitializeComponent();
        }

        private void quitter_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void connexion_Click(object sender, EventArgs e)
        {
            if (nomParent.Text != "" && motdepasseParent.Text != "")
            {
                // On teste si le parent existe dans la BD et si oui on le récupère
                ControleConnexion cc = new ControleConnexion();
                Parent par = cc.parentValide(nomParent.Text, motdepasseParent.Text);

                //if (par!=null)
             //   {
                    // On ferme la fenêtre et on ouvre la fenêtre principale du parent
                    // on envoit le parent pour la fenêtre principale
                    //Form_PrincipaleParent fpp = new Form_PrincipaleParent(par);
                    Form_PrincipaleParent fpp = new Form_PrincipaleParent(nomParent.Text);
                    fpp.Show();
                    this.Dispose();
             //   }
              //  else
              //      MessageBox.Show("nom ou mot de passe incorrect");
                
            }
            else
                MessageBox.Show("Veuillez remplir tous les champs");
        }
    
    }
}
