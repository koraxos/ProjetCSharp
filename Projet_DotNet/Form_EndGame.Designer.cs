namespace Projet_DotNet
{
    partial class Form_EndGame
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
            this.button_corr = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_menu
            // 
            this.button_menu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_menu.Location = new System.Drawing.Point(651, 531);
            this.button_menu.Margin = new System.Windows.Forms.Padding(20);
            this.button_menu.Name = "button_menu";
            this.button_menu.Size = new System.Drawing.Size(300, 75);
            this.button_menu.TabIndex = 0;
            this.button_menu.Text = "Retour au menu";
            this.button_menu.UseVisualStyleBackColor = true;
            this.button_menu.Click += new System.EventHandler(this.button_menu_Click);
            // 
            // button_corr
            // 
            this.button_corr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_corr.Location = new System.Drawing.Point(29, 531);
            this.button_corr.Margin = new System.Windows.Forms.Padding(20);
            this.button_corr.Name = "button_corr";
            this.button_corr.Size = new System.Drawing.Size(300, 75);
            this.button_corr.TabIndex = 1;
            this.button_corr.Text = "Voir la correction";
            this.button_corr.UseVisualStyleBackColor = true;
            this.button_corr.Click += new System.EventHandler(this.button_corr_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(210, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(325, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Bravo ! Tu as fini ce test. Tu peux maintenant regarder la correction";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form_EndGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(980, 635);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_corr);
            this.Controls.Add(this.button_menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_EndGame";
            this.Text = "Form_EndGame";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_menu;
        private System.Windows.Forms.Button button_corr;
        private System.Windows.Forms.Label label1;
    }
}