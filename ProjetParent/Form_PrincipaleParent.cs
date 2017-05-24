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
    public partial class Form_PrincipaleParent : Form
    {
        Parent p;
        ControleConnexion cc;
        public Form_PrincipaleParent(Parent p)
        {
            InitializeComponent();
            messageBienvenue.Text = "Bienvenue "+p.Nom;
          
            remplissageDataGrid();

        }
        public Form_PrincipaleParent(String nom)
        {
            InitializeComponent();
            messageBienvenue.Text = "Bienvenue " + nom;

            remplissageDataGrid();

        }
        private void messageBienvenue_Click(object sender, EventArgs e)
        {

        }

        private void quitterLapplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void ajouterUnEnfantToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form_AjoutEnfant fae = new Form_AjoutEnfant();
            fae.Show();

            // Une fois que la fenêtre d'ajout est fermée, on rafraîchit la fenêtre
            // Pour afficher la Base de données qui a été mise à jour

            this.Refresh();
        }

        private void remplissageDataGrid()
        {
            // Avec la connexion à la base de données, on va remplir le datagridview
            // pour que le parent puisse voir la liste des enfants qu'il a inscrit
            // mais aussi pour pouvoir consulter les résultats des enfants.

            //Eleve[] elv = cc.affichageEnfant(p);
            //int tailleBaseEleve = elv.Count();
            //for(int i=0; i<tailleBaseEleve; i++)
            //  {
            //      dataGridView1.Rows[i].Cells["nomEnfant"].Value = elv[i].Nom;
            //      dataGridView1.Rows[i].Cells["prenomEnfant"].Value = elv[i].Prenom;
            //      dataGridView1.Rows[i].Cells["profil"].Value = elv[i].getProfil();
            //      dataGridView1.Rows[i].Cells["consultationResultat"].Value = "consulter";
            //  }

            // taille de nombre d'enfants de la personne
            int tailleBaseEleve = 3;
            // pour le moment je pars sur le principe que e est un élève
            dataGridView1.RowCount = tailleBaseEleve;

            // on remplit le datagridview
            for(int i=0; i<tailleBaseEleve; i++)
            {
                
                dataGridView1.Rows[i].Cells["nomEnfant"].Value = "Boulet";
                dataGridView1.Rows[i].Cells["prenomEnfant"].Value = "bolo";
                dataGridView1.Rows[i].Cells["profil"].Value = 3;
                dataGridView1.Rows[i].Cells["consultationResultat"].Value = "consulter";

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            String nom = (String)dataGridView1.Rows[e.RowIndex].Cells["nomEnfant"].Value;
            Console.WriteLine(nom);
            String prenom = (String)dataGridView1.Rows[e.RowIndex].Cells["prenomEnfant"].Value;
            Console.WriteLine(prenom);
            // A partir du bouton, on doit pouvoir accéder aux résultats de l'enfant
            Form_Resultat fr = new Form_Resultat(nom,prenom);
            fr.Show();
        }
    }
}
