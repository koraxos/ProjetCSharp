using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projet_DotNet.Vue
{
    public partial class Form_Tables : Form
    {

        // La Form parent
        Form_Menu menu;

        public Form_Tables(Form_Menu parent)
        {
            InitializeComponent();
            menu = parent;
            MAJLabels();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            menu.Show();
            this.Close();
        }

        private void boxtable_SelectedIndexChanged(object sender, EventArgs e)
        {
            MAJLabels();
        }

        private void MAJLabels()
        {
            int selected = Convert.ToInt16(boxtable.GetItemText(boxtable.SelectedItem));
            label1.Text = selected + " x 1 = " + selected*1;
            label2.Text = selected + " x 2 = " + selected*2;
            label3.Text = selected + " x 3 = " + selected*3;
            label4.Text = selected + " x 4 = " + selected*4;
            label5.Text = selected + " x 5 = " + selected*5;
            label6.Text = selected + " x 6 = " + selected*6;
            label7.Text = selected + " x 7 = " + selected*7;
            label8.Text = selected + " x 8 = " + selected*8;
            label9.Text = selected + " x 9 = " + selected*9;
            label10.Text = selected + " x 10 = " + selected*10;

        }
    }
}
