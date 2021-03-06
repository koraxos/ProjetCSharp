﻿using Projet_DotNet.Modele;
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
    public partial class Form_Login : Form
    {
        // Le parent, histoire de pouvoir revenir en arrière
        protected Accueil parent;
        // Constructeur
        public Form_Login(Accueil parent)
        {
            InitializeComponent();
            this.parent = parent;
        }


        // Action click bouton annuler
        private void button2_Click(object sender, EventArgs e)
        {
            this.parent.Show();
            this.Close();
        }

        // Action click bouton Me connecter
        private void button1_Click(object sender, EventArgs e)
        {
            int valide=0;
            valide = ControleurConnexion.getInstance().estValide(this.textBox1.Text, this.textBox2.Text);
            Eleve eleve =ControleurConnexion.getInstance().getEleve(valide,this.textBox1.Text, this.textBox2.Text);
            
            if (valide !=0) // Actions à faire si valide
            {
                Form_Menu menu = new Form_Menu(parent, eleve);
                menu.Show();
                this.Close();
            }
            else // Actions à faire si non valide
            {
                label_error.Text = "Il semblerait que ton nom ou prénom soit erroné. Es-tu sûr d'avoir bien rempli les cases ?";
            }

        }
    }
}
