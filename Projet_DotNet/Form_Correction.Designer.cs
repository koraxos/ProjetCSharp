namespace Projet_DotNet
{
    partial class Form_Correction
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_menu = new System.Windows.Forms.Button();
            this.button_prec = new System.Windows.Forms.Button();
            this.button_suiv = new System.Windows.Forms.Button();
            this.button_play = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label_operation_en_cours = new System.Windows.Forms.Label();
            this.label_operation = new System.Windows.Forms.Label();
            this.label_reponse = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_menu
            // 
            this.button_menu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_menu.Location = new System.Drawing.Point(743, 12);
            this.button_menu.Name = "button_menu";
            this.button_menu.Size = new System.Drawing.Size(225, 100);
            this.button_menu.TabIndex = 0;
            this.button_menu.Text = "Retour au menu";
            this.button_menu.UseVisualStyleBackColor = true;
            this.button_menu.Click += new System.EventHandler(this.button_menu_Click);
            // 
            // button_prec
            // 
            this.button_prec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_prec.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button_prec.Location = new System.Drawing.Point(29, 21);
            this.button_prec.Margin = new System.Windows.Forms.Padding(20);
            this.button_prec.Name = "button_prec";
            this.button_prec.Size = new System.Drawing.Size(300, 100);
            this.button_prec.TabIndex = 1;
            this.button_prec.Text = "Précédent";
            this.button_prec.UseVisualStyleBackColor = true;
            this.button_prec.Click += new System.EventHandler(this.button_prec_Click);
            // 
            // button_suiv
            // 
            this.button_suiv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_suiv.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button_suiv.Location = new System.Drawing.Point(651, 21);
            this.button_suiv.Margin = new System.Windows.Forms.Padding(20);
            this.button_suiv.Name = "button_suiv";
            this.button_suiv.Size = new System.Drawing.Size(300, 100);
            this.button_suiv.TabIndex = 2;
            this.button_suiv.Text = "Suivant";
            this.button_suiv.UseVisualStyleBackColor = true;
            this.button_suiv.Click += new System.EventHandler(this.button_suiv_Click);
            // 
            // button_play
            // 
            this.button_play.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button_play.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button_play.Image = global::Projet_DotNet.Properties.Resources.icone_son;
            this.button_play.Location = new System.Drawing.Point(442, 21);
            this.button_play.Margin = new System.Windows.Forms.Padding(20);
            this.button_play.Name = "button_play";
            this.button_play.Size = new System.Drawing.Size(100, 100);
            this.button_play.TabIndex = 3;
            this.button_play.UseVisualStyleBackColor = true;
            this.button_play.Click += new System.EventHandler(this.button_play_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_prec);
            this.panel1.Controls.Add(this.button_suiv);
            this.panel1.Controls.Add(this.button_play);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 485);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(980, 150);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.label_reponse);
            this.panel2.Controls.Add(this.label_operation);
            this.panel2.Controls.Add(this.label_operation_en_cours);
            this.panel2.Location = new System.Drawing.Point(12, 161);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(956, 260);
            this.panel2.TabIndex = 5;
            // 
            // label_operation_en_cours
            // 
            this.label_operation_en_cours.AutoSize = true;
            this.label_operation_en_cours.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_operation_en_cours.Location = new System.Drawing.Point(0, 0);
            this.label_operation_en_cours.Name = "label_operation_en_cours";
            this.label_operation_en_cours.Size = new System.Drawing.Size(342, 55);
            this.label_operation_en_cours.TabIndex = 0;
            this.label_operation_en_cours.Text = "Opération 1/20";
            // 
            // label_operation
            // 
            this.label_operation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_operation.AutoSize = true;
            this.label_operation.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_operation.Location = new System.Drawing.Point(372, 57);
            this.label_operation.Name = "label_operation";
            this.label_operation.Size = new System.Drawing.Size(223, 55);
            this.label_operation.TabIndex = 1;
            this.label_operation.Text = "5x 2 = 10";
            // 
            // label_reponse
            // 
            this.label_reponse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_reponse.AutoSize = true;
            this.label_reponse.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_reponse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label_reponse.Location = new System.Drawing.Point(407, 112);
            this.label_reponse.Name = "label_reponse";
            this.label_reponse.Size = new System.Drawing.Size(133, 25);
            this.label_reponse.TabIndex = 2;
            this.label_reponse.Text = "Ta réponse :";
            // 
            // Form_Correction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(980, 635);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button_menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Correction";
            this.Text = "Form_Correction";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_menu;
        private System.Windows.Forms.Button button_prec;
        private System.Windows.Forms.Button button_suiv;
        private System.Windows.Forms.Button button_play;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label_operation_en_cours;
        private System.Windows.Forms.Label label_reponse;
        private System.Windows.Forms.Label label_operation;
    }
}