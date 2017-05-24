using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ProjetParent
{
    public partial class Form_Resultat : Form
    {
        String nom, prenom;
        Eleve eleve;
        ControleConnexion cc;
        public Form_Resultat(String nom, String prenom)
        {
            InitializeComponent();
            this.nom = nom;
            this.prenom = prenom;
            comboBox1.SelectedValue=0;
            // il faut interroger la bd pour récupérer l'enfant à partir du nom et du prénom
            //eleve = cc.cetEleve(nom, prenom);
            remplissageNiveau();
            chart1.CreateGraphics();
            chart1.Series.Add("Series2");

           // creationGraphique(nom, prenom,3);

        }

        private void remplissageNiveau()
        {
            // On remplit la combobox avec les niveaux faits par l'enfant
            for(int i=0;i<cc.nombreNiveau(eleve);i++)
                comboBox1.Items.Add("Niveau "+(i+1));
            
        }
        
        private void creationGraphique(String nom,String prenom,int niveau)
        {
            if (chart1.Titles.Count>0)
                chart1.Titles.RemoveAt(0);
            chart1.Titles.Add("Résultats de " + nom + " " + prenom + " au niveau " + (niveau + 1));
            chart1.Series["Series2"].ChartType = SeriesChartType.Column;

            // On va rentrer les données dans le graphique
            insertionGraphique();

            // Création du chartArea
            chart1.Series["Series2"].ChartArea = "ChartArea1";
            // titre abscisse
            chart1.ChartAreas["ChartArea1"].AxisX.Title = "Dates des résultats";
            chart1.ChartAreas["ChartArea1"].AxisX.TitleAlignment = StringAlignment.Center;
            chart1.ChartAreas["ChartArea1"].AxisX.TextOrientation = TextOrientation.Horizontal;
            // titre ordonnée
            chart1.ChartAreas["ChartArea1"].AxisY.Title = "Notes";
            chart1.ChartAreas["ChartArea1"].AxisY.TitleAlignment = StringAlignment.Center;
            chart1.ChartAreas["ChartArea1"].AxisY.TextOrientation = TextOrientation.Horizontal;

        }

        private void insertionGraphique()
        {
            // il faut que l'on ait les données des tests (ex : tableau)

            int[] tabTest = new int[4];
            tabTest[0]=3;
            tabTest[1] = 5;
            tabTest[2] = 13;
            tabTest[3] = 8;

            for(int i=0;i<tabTest.Length;i++)
            {
                //  AddXY(numeroDeTest,note)
                chart1.Series["Series2"].Points.AddXY(i+1, tabTest[i]);
            }
            
        }


        private void Form_Resultat_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            int niveau = comboBox1.SelectedIndex;
            Console.WriteLine(niveau + " zudfhzefbzeycfg");
            creationGraphique(nom, prenom, niveau);
        }
        
    }
}
