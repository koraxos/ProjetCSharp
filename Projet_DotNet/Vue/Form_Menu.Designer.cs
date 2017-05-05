namespace Projet_DotNet
{
    partial class Form_Menu
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
            this.button_quit = new System.Windows.Forms.Button();
            this.button_logoff = new System.Windows.Forms.Button();
            this.button_test = new System.Windows.Forms.Button();
            this.button_training = new System.Windows.Forms.Button();
            this.button_tables = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_quit
            // 
            this.button_quit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_quit.AutoSize = true;
            this.button_quit.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_quit.Location = new System.Drawing.Point(29, 531);
            this.button_quit.Margin = new System.Windows.Forms.Padding(20, 3, 3, 20);
            this.button_quit.Name = "button_quit";
            this.button_quit.Size = new System.Drawing.Size(300, 75);
            this.button_quit.TabIndex = 0;
            this.button_quit.Text = "Quitter";
            this.button_quit.UseVisualStyleBackColor = true;
            this.button_quit.Click += new System.EventHandler(this.button_quit_Click);
            // 
            // button_logoff
            // 
            this.button_logoff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_logoff.AutoSize = true;
            this.button_logoff.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_logoff.Location = new System.Drawing.Point(29, 433);
            this.button_logoff.Margin = new System.Windows.Forms.Padding(20, 3, 3, 20);
            this.button_logoff.Name = "button_logoff";
            this.button_logoff.Size = new System.Drawing.Size(300, 75);
            this.button_logoff.TabIndex = 1;
            this.button_logoff.Text = "Me déconnecter";
            this.button_logoff.UseVisualStyleBackColor = true;
            this.button_logoff.Click += new System.EventHandler(this.button_logoff_Click);
            // 
            // button_test
            // 
            this.button_test.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_test.AutoSize = true;
            this.button_test.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_test.Location = new System.Drawing.Point(451, 29);
            this.button_test.Margin = new System.Windows.Forms.Padding(20);
            this.button_test.Name = "button_test";
            this.button_test.Size = new System.Drawing.Size(500, 100);
            this.button_test.TabIndex = 2;
            this.button_test.Text = "Me tester !";
            this.button_test.UseVisualStyleBackColor = true;
            this.button_test.Click += new System.EventHandler(this.button_test_Click);
            // 
            // button_training
            // 
            this.button_training.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_training.AutoSize = true;
            this.button_training.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_training.Location = new System.Drawing.Point(451, 152);
            this.button_training.Margin = new System.Windows.Forms.Padding(20, 3, 20, 20);
            this.button_training.Name = "button_training";
            this.button_training.Size = new System.Drawing.Size(500, 100);
            this.button_training.TabIndex = 3;
            this.button_training.Text = "M\'entrainer";
            this.button_training.UseVisualStyleBackColor = true;
            this.button_training.Click += new System.EventHandler(this.button_training_Click);
            // 
            // button_tables
            // 
            this.button_tables.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_tables.AutoSize = true;
            this.button_tables.Enabled = false;
            this.button_tables.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_tables.Location = new System.Drawing.Point(29, 335);
            this.button_tables.Margin = new System.Windows.Forms.Padding(20, 3, 3, 20);
            this.button_tables.Name = "button_tables";
            this.button_tables.Size = new System.Drawing.Size(300, 75);
            this.button_tables.TabIndex = 4;
            this.button_tables.Text = "Voir mes tables";
            this.button_tables.UseVisualStyleBackColor = true;
            // 
            // Form_Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(980, 635);
            this.Controls.Add(this.button_tables);
            this.Controls.Add(this.button_training);
            this.Controls.Add(this.button_test);
            this.Controls.Add(this.button_logoff);
            this.Controls.Add(this.button_quit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Menu";
            this.Text = "Form_Menu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_quit;
        private System.Windows.Forms.Button button_logoff;
        private System.Windows.Forms.Button button_test;
        private System.Windows.Forms.Button button_training;
        private System.Windows.Forms.Button button_tables;
    }
}