using Projet_DotNet.Modele;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projet_DotNet
{
    public partial class Form_Correction : Form
    {
        // Le menu
        Form_Menu menu;


        // Le syntheti=seur de sons
        System.Speech.Synthesis.SpeechSynthesizer synthe = new System.Speech.Synthesis.SpeechSynthesizer();

        // Le jeu
        Jeu jeu;

        // Operation en cours de traitement
        int operation_en_cours;

        public Form_Correction(Form_Menu menu, Jeu j)
        {
            this.menu = menu;

            jeu = j;
            // On commence par la premire operation, sans blague ?
            operation_en_cours = 0;


            
            InitializeComponent();

            go_operation();
        }

        private void button_menu_Click(object sender, EventArgs e)
        {
            menu.Show();
            this.Close();
        }

        private void button_play_Click(object sender, EventArgs e)
        {
            Thread lecture = new Thread(new ThreadStart(thread_lecture));
            lecture.Start();
        }

        private void button_prec_Click(object sender, EventArgs e)
        {
            operation_en_cours--;
            go_operation();
        }

        private void button_suiv_Click(object sender, EventArgs e)
        {
            operation_en_cours++;
            go_operation();
        }


        private void go_operation()
        {
            if (operation_en_cours == jeu.getLength() - 1)
            {
                button_suiv.Enabled = false;
            }
            else
                button_suiv.Enabled = true;

            if (operation_en_cours == 0)
            {
                button_prec.Enabled = false;
            }
            else
                button_prec.Enabled = true;

            
            label_reponse.Text = "Ta réponse : " + jeu.getReponse(operation_en_cours);
            if(jeu.getReponse(operation_en_cours) == jeu.getResultat(operation_en_cours))
                label_reponse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            else
                label_reponse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // On actualise le label de l'opération

            label_operation.Text = jeu.getOperateur(operation_en_cours, 0) + " x " + jeu.getOperateur(operation_en_cours, 1) + " = " + jeu.getResultat(operation_en_cours);
            int op = operation_en_cours + 1;
            label_operation_en_cours.Text = "Opération " + op + "/" + jeu.getLength();
        }

        // Thread lecture
        public void thread_lecture()
        {
            synthe.Speak(jeu.getOperateur(operation_en_cours, 0) + " multiplié par " + jeu.getOperateur(operation_en_cours, 1) + ", égal "+ jeu.getResultat(operation_en_cours));
            Thread.CurrentThread.Abort();
        }

    }
}
