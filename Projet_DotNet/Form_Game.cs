using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projet_DotNet
{
    public partial class Form_Game : Form
    {
        // Le temps du compteur (maximum)
        int temps_max = 10;

        // Le temps actuel du compteur (secondes)
        int temps;

        // La Form parent
        Form_Menu menu;

        // Booleen pour savoir si on est en entrainement
        bool entrainement;

        // Booleen pour activer ou non le son. Utile ? Depend si on lis le son des l'acquisition de l'opération
        bool son;
        

        // Le syntheti=seur de sons
        System.Speech.Synthesis.SpeechSynthesizer synthe = new System.Speech.Synthesis.SpeechSynthesizer();

        // Un tableau contenant les operations à faire
        int[,] operations = new int[6, 2];

        // Et on va stocker les resultats de l'util
        int[] resultats = new int[6];

        // Operation en cours de traitement
        int operation_en_cours;

        // Constructeur
        public Form_Game(Form_Menu menu, bool entrainement=false)
        {
            InitializeComponent();
            this.menu = menu;
            this.entrainement = entrainement;

            // Active/Désactive le son (Est-ce réellement utile ? Ca dépend de notre modélisation, je l'ai mis au cas ou pour le moment pour m'entrainer
            this.son = true;
            
            

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


            // Champs dépendant de si on est en entrainement, ou en test "réel"
            if (entrainement)
            {
                // Pas de temps en entrainement
                label_time.Text = "";
            }
            else
            {
                // Initialise le timer
                // Ajoute le délégué gérant les ticks
                timer.Tick += new EventHandler(TimerEventProcessor);
                // Intervalle de 1 seconde entre chaque Tick du timer
                timer.Interval = 1000;
            }

            // On actualise la vue en fonction de l'operation en cours
            go_operation();
        }

        // Action click sur un bouton chiffre du PN
        private void button_digit_click(object sender, EventArgs e)
        {
            int chiffre = Convert.ToInt32(((Button)sender).Text);
            if(textBox1.Text.Length<4) textBox1.Text += chiffre;
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
                textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
        }


        // Action click sur le bouton valider
        private void button_validate_Click(object sender, EventArgs e)
        {
            // Traitement pour aller à l'opération suivante
            incremente_operation_en_cours();
        }


        // Action click sur le bouton vocalisation
        private void button_play_Click(object sender, EventArgs e)
        {
            if (son)
            {
                Thread lecture = new Thread(new ThreadStart(thread_lecture));
                lecture.Start();
            }
        }

        // Délégué du thread de lecture du son
        public void thread_lecture()
        {
            synthe.Speak(operations[operation_en_cours, 0] + " multiplié par " + operations[operation_en_cours, 1] + ", égal");
            Thread.CurrentThread.Abort();
        }

        // Action click sur le bouton activer/désactiver vocalisation
        private void button_sound_Click(object sender, EventArgs e)
        {
            son = !son;

            if (son)
            {
                button_play.Enabled = true;
                button_sound.Image = global::Projet_DotNet.Properties.Resources.icone_no_son;
            }
            else
            {
                button_play.Enabled = false;
                button_sound.Image = global::Projet_DotNet.Properties.Resources.icone_son;
            }
        }


        // Délégué gérant les Ticks du timer
        private void TimerEventProcessor(Object myObject,
                                            EventArgs myEventArgs)
        {
            // On arrete le timer
            timer.Stop();

            // On actualise le temps restant
            temps--;
            label_time.Text = "Temps restant : " + temps;

            // On regarde s'il reste du temps
            if(temps==0)
            {
                // Temps écoulé
                incremente_operation_en_cours();
            }
            else
            {
                // Temps non écoulé, on réactive le timer
                timer.Enabled = true;
            }


        }


        // Incrémentation, si possible, le l'opération en cours
        private void incremente_operation_en_cours()
        {
            // On stocke le résultat

            if (textBox1.Text != "")
                resultats[operation_en_cours] = Convert.ToInt32(textBox1.Text);
            else
                resultats[operation_en_cours] = 0;

            if (operation_en_cours < operations.GetLength(0)-1)
            {
                operation_en_cours++;
                go_operation();
            }
            else
            {
                // On ne peut plus incrémenter operation_en_cours : FIN du test/entrainement
                // A gerer plus précisement
                Form_EndGame form = new Form_EndGame(menu, resultats, entrainement);
                
                form.Show();
                this.Close();
            }
        }


        // Actualisation de la vue 
        private void go_operation()
        {

            // On actualise le label de l'opération
            label_operation.Text = operations[operation_en_cours, 0] + " x " + operations[operation_en_cours, 1] + " = ";
            int op = operation_en_cours + 1;
            labeloperationencours.Text = "Opération " + op + "/" + operations.GetLength(0);
            // On vide la textbox
            textBox1.Text = "";
            if (!entrainement)
            {
                // Si on est pas en entrainement, on init. le timer
                temps = temps_max;
                label_time.Text = "Temps restant : " + temps;
                timer.Enabled = true;
                timer.Start();
            }
        }

        // Active/Désactive le clavier le temps de la vocalisation par exemple
        private void activer_clavier(bool b)
        {
            button1.Enabled = b;
            button2.Enabled = b;
            button3.Enabled = b;
            button4.Enabled = b;
            button5.Enabled = b;
            button6.Enabled = b;
            button7.Enabled = b;
            button8.Enabled = b;
            button9.Enabled = b;
            button10.Enabled = b;
            button_cancel.Enabled = b;
            button_validate.Enabled = b;
            button_play.Enabled = b;
        }
    }
}
