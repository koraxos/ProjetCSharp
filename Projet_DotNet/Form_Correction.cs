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

        // Les opérations
        // Un tableau contenant les operations à faire
        int[,] operations = new int[6, 2];

        // Et les resultat de l'util
        int[] resultats = new int[6];

        // Operation en cours de traitement
        int operation_en_cours;

        public Form_Correction(Form_Menu menu, int[] res)
        {
            this.menu = menu;

            // On commence par la premire operation, sans blague ?
            operation_en_cours = 0;

            // Pour le test, on va remplir le tableau avec des valeurs au pif
            operations[0, 0] = 2;
            operations[0, 1] = 2;
            operations[1, 0] = 9;
            operations[1, 1] = 7;
            operations[2, 0] = 1;
            operations[2, 1] = 2;
            operations[3, 0] = 6;
            operations[3, 1] = 2;
            operations[4, 0] = 4;
            operations[4, 1] = 6;
            operations[5, 0] = 5;
            operations[5, 1] = 2;

            // Possible ?
            resultats = res;


            
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
            if (operation_en_cours == operations.GetLength(0) - 1)
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

            // On actualise la réponse
            int res = operations[operation_en_cours, 0] * operations[operation_en_cours, 1];

            label_reponse.Text = "Ta réponse : " + resultats[operation_en_cours];
            if(resultats[operation_en_cours]==res)
                label_reponse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            else
                label_reponse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // On actualise le label de l'opération

            label_operation.Text = operations[operation_en_cours, 0] + " x " + operations[operation_en_cours, 1] + " = " + res;
            int op = operation_en_cours + 1;
            label_operation_en_cours.Text = "Opération " + op + "/" + operations.GetLength(0);
        }

        // Thread lecture
        public void thread_lecture()
        {
            int res = operations[operation_en_cours, 0] * operations[operation_en_cours, 1];
            synthe.Speak(operations[operation_en_cours, 0] + " multiplié par " + operations[operation_en_cours, 1] + ", égal "+res);
            Thread.CurrentThread.Abort();
        }

    }
}
