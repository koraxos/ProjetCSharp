namespace ProjetParent
{
    partial class Form_PrincipaleParent
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
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ajouterUnEnfantToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajouterUnEnfantToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.quitterLapplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.messageBienvenue = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.nomEnfant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prenomEnfant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.profil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.consultationResultat = new System.Windows.Forms.DataGridViewButtonColumn();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ajouterUnEnfantToolStripMenuItem,
            this.quitterToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(168, 48);
            // 
            // ajouterUnEnfantToolStripMenuItem
            // 
            this.ajouterUnEnfantToolStripMenuItem.Name = "ajouterUnEnfantToolStripMenuItem";
            this.ajouterUnEnfantToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.ajouterUnEnfantToolStripMenuItem.Text = "Ajouter un enfant";
            // 
            // quitterToolStripMenuItem
            // 
            this.quitterToolStripMenuItem.Name = "quitterToolStripMenuItem";
            this.quitterToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.quitterToolStripMenuItem.Text = "Quitter";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(444, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ajouterUnEnfantToolStripMenuItem1,
            this.quitterLapplicationToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // ajouterUnEnfantToolStripMenuItem1
            // 
            this.ajouterUnEnfantToolStripMenuItem1.Name = "ajouterUnEnfantToolStripMenuItem1";
            this.ajouterUnEnfantToolStripMenuItem1.Size = new System.Drawing.Size(179, 22);
            this.ajouterUnEnfantToolStripMenuItem1.Text = "Ajouter un enfant";
            this.ajouterUnEnfantToolStripMenuItem1.Click += new System.EventHandler(this.ajouterUnEnfantToolStripMenuItem1_Click);
            // 
            // quitterLapplicationToolStripMenuItem
            // 
            this.quitterLapplicationToolStripMenuItem.Name = "quitterLapplicationToolStripMenuItem";
            this.quitterLapplicationToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.quitterLapplicationToolStripMenuItem.Text = "Quitter l\'application";
            this.quitterLapplicationToolStripMenuItem.Click += new System.EventHandler(this.quitterLapplicationToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.messageBienvenue);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(444, 237);
            this.splitContainer1.SplitterDistance = 43;
            this.splitContainer1.TabIndex = 2;
            // 
            // messageBienvenue
            // 
            this.messageBienvenue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.messageBienvenue.AutoSize = true;
            this.messageBienvenue.Location = new System.Drawing.Point(189, 14);
            this.messageBienvenue.Name = "messageBienvenue";
            this.messageBienvenue.Size = new System.Drawing.Size(58, 13);
            this.messageBienvenue.TabIndex = 0;
            this.messageBienvenue.Text = "Bienvenue";
            this.messageBienvenue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.messageBienvenue.Click += new System.EventHandler(this.messageBienvenue_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nomEnfant,
            this.prenomEnfant,
            this.profil,
            this.consultationResultat});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(444, 190);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // nomEnfant
            // 
            this.nomEnfant.HeaderText = "Nom de l\'enfant";
            this.nomEnfant.Name = "nomEnfant";
            this.nomEnfant.ReadOnly = true;
            // 
            // prenomEnfant
            // 
            this.prenomEnfant.HeaderText = "Prénom de l\'enfant";
            this.prenomEnfant.Name = "prenomEnfant";
            this.prenomEnfant.ReadOnly = true;
            // 
            // profil
            // 
            this.profil.HeaderText = "Table maximale";
            this.profil.Name = "profil";
            this.profil.ReadOnly = true;
            // 
            // consultationResultat
            // 
            this.consultationResultat.HeaderText = "Résultat de l\'enfant";
            this.consultationResultat.Name = "consultationResultat";
            this.consultationResultat.ReadOnly = true;
            this.consultationResultat.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.consultationResultat.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Form_PrincipaleParent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 261);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form_PrincipaleParent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_PrincipaleParent";
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ajouterUnEnfantToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitterToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajouterUnEnfantToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem quitterLapplicationToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label messageBienvenue;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomEnfant;
        private System.Windows.Forms.DataGridViewTextBoxColumn prenomEnfant;
        private System.Windows.Forms.DataGridViewTextBoxColumn profil;
        private System.Windows.Forms.DataGridViewButtonColumn consultationResultat;
    }
}