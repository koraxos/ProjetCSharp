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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form_Inscription fi = new Form_Inscription();
            fi.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form_ConnexionParent fcp = new Form_ConnexionParent();
            fcp.Show();
        }

        private void quitter_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
