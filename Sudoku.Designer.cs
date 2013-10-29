namespace Sudoku
{
    partial class Sudoku
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.jeu_Item = new System.Windows.Forms.ToolStripMenuItem();
            this.ouvrir_Item = new System.Windows.Forms.ToolStripMenuItem();
            this.enregistrer_Item = new System.Windows.Forms.ToolStripMenuItem();
            this.quitter_Item = new System.Windows.Forms.ToolStripMenuItem();
            this.aideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Aide_1 = new System.Windows.Forms.ToolStripMenuItem();
            this.Aide_2 = new System.Windows.Forms.ToolStripMenuItem();
            this.Aide_3 = new System.Windows.Forms.ToolStripMenuItem();
            this.Aide_4 = new System.Windows.Forms.ToolStripMenuItem();
            this.Aide_5 = new System.Windows.Forms.ToolStripMenuItem();
            this.Aide_6 = new System.Windows.Forms.ToolStripMenuItem();
            this.Aide_7 = new System.Windows.Forms.ToolStripMenuItem();
            this.Aide_8 = new System.Windows.Forms.ToolStripMenuItem();
            this.Aide_9 = new System.Windows.Forms.ToolStripMenuItem();
            this.OuvreGrille = new System.Windows.Forms.OpenFileDialog();
            this.TimerLabel = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.buttonInit = new System.Windows.Forms.Button();
            this.buttonSolution = new System.Windows.Forms.Button();
            this.sauverFichier = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jeu_Item,
            this.aideToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(549, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // jeu_Item
            // 
            this.jeu_Item.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ouvrir_Item,
            this.enregistrer_Item,
            this.quitter_Item});
            this.jeu_Item.Name = "jeu_Item";
            this.jeu_Item.Size = new System.Drawing.Size(36, 20);
            this.jeu_Item.Text = "Jeu";
            // 
            // ouvrir_Item
            // 
            this.ouvrir_Item.Name = "ouvrir_Item";
            this.ouvrir_Item.Size = new System.Drawing.Size(160, 22);
            this.ouvrir_Item.Text = "Ouvrir une Grille";
            this.ouvrir_Item.Click += new System.EventHandler(this.ouvrir_Item_Click);
            // 
            // enregistrer_Item
            // 
            this.enregistrer_Item.Enabled = false;
            this.enregistrer_Item.Name = "enregistrer_Item";
            this.enregistrer_Item.Size = new System.Drawing.Size(160, 22);
            this.enregistrer_Item.Text = "Enregistrer";
            this.enregistrer_Item.Click += new System.EventHandler(this.enregistrer_Item_Click);
            // 
            // quitter_Item
            // 
            this.quitter_Item.Name = "quitter_Item";
            this.quitter_Item.Size = new System.Drawing.Size(160, 22);
            this.quitter_Item.Text = "Quitter";
            this.quitter_Item.Click += new System.EventHandler(this.quitter_Item_Click);
            // 
            // aideToolStripMenuItem
            // 
            this.aideToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Aide_1,
            this.Aide_2,
            this.Aide_3,
            this.Aide_4,
            this.Aide_5,
            this.Aide_6,
            this.Aide_7,
            this.Aide_8,
            this.Aide_9});
            this.aideToolStripMenuItem.Name = "aideToolStripMenuItem";
            this.aideToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.aideToolStripMenuItem.Text = "Aide";
            // 
            // Aide_1
            // 
            this.Aide_1.Name = "Aide_1";
            this.Aide_1.Size = new System.Drawing.Size(80, 22);
            this.Aide_1.Text = "1";
            this.Aide_1.Click += new System.EventHandler(this.Aide_1_Click);
            // 
            // Aide_2
            // 
            this.Aide_2.Name = "Aide_2";
            this.Aide_2.Size = new System.Drawing.Size(80, 22);
            this.Aide_2.Text = "2";
            this.Aide_2.Click += new System.EventHandler(this.Aide_2_Click);
            // 
            // Aide_3
            // 
            this.Aide_3.Name = "Aide_3";
            this.Aide_3.Size = new System.Drawing.Size(80, 22);
            this.Aide_3.Text = "3";
            this.Aide_3.Click += new System.EventHandler(this.Aide_3_Click);
            // 
            // Aide_4
            // 
            this.Aide_4.Name = "Aide_4";
            this.Aide_4.Size = new System.Drawing.Size(80, 22);
            this.Aide_4.Text = "4";
            this.Aide_4.Click += new System.EventHandler(this.Aide_4_Click);
            // 
            // Aide_5
            // 
            this.Aide_5.Name = "Aide_5";
            this.Aide_5.Size = new System.Drawing.Size(80, 22);
            this.Aide_5.Text = "5";
            this.Aide_5.Click += new System.EventHandler(this.Aide_5_Click);
            // 
            // Aide_6
            // 
            this.Aide_6.Name = "Aide_6";
            this.Aide_6.Size = new System.Drawing.Size(80, 22);
            this.Aide_6.Text = "6";
            this.Aide_6.Click += new System.EventHandler(this.Aide_6_Click);
            // 
            // Aide_7
            // 
            this.Aide_7.Name = "Aide_7";
            this.Aide_7.Size = new System.Drawing.Size(80, 22);
            this.Aide_7.Text = "7";
            this.Aide_7.Click += new System.EventHandler(this.Aide_7_Click);
            // 
            // Aide_8
            // 
            this.Aide_8.Name = "Aide_8";
            this.Aide_8.Size = new System.Drawing.Size(80, 22);
            this.Aide_8.Text = "8";
            this.Aide_8.Click += new System.EventHandler(this.Aide_8_Click);
            // 
            // Aide_9
            // 
            this.Aide_9.Name = "Aide_9";
            this.Aide_9.Size = new System.Drawing.Size(80, 22);
            this.Aide_9.Text = "9";
            this.Aide_9.Click += new System.EventHandler(this.Aide_9_Click);
            // 
            // OuvreGrille
            // 
            this.OuvreGrille.FileName = "openFileDialog";
            this.OuvreGrille.Filter = "Fichier txt | *.txt";
            // 
            // TimerLabel
            // 
            this.TimerLabel.AutoSize = true;
            this.TimerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimerLabel.Location = new System.Drawing.Point(382, 46);
            this.TimerLabel.Name = "TimerLabel";
            this.TimerLabel.Size = new System.Drawing.Size(0, 22);
            this.TimerLabel.TabIndex = 1;
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            // 
            // buttonInit
            // 
            this.buttonInit.Location = new System.Drawing.Point(426, 320);
            this.buttonInit.Name = "buttonInit";
            this.buttonInit.Size = new System.Drawing.Size(106, 31);
            this.buttonInit.TabIndex = 2;
            this.buttonInit.Text = "Remettre à zéro !";
            this.buttonInit.UseVisualStyleBackColor = true;
            this.buttonInit.Click += new System.EventHandler(this.buttonInit_Click);
            // 
            // buttonSolution
            // 
            this.buttonSolution.Location = new System.Drawing.Point(426, 283);
            this.buttonSolution.Name = "buttonSolution";
            this.buttonSolution.Size = new System.Drawing.Size(106, 31);
            this.buttonSolution.TabIndex = 3;
            this.buttonSolution.Text = "Solution";
            this.buttonSolution.UseVisualStyleBackColor = true;
            this.buttonSolution.Click += new System.EventHandler(this.buttonSolution_Click);
            // 
            // Sudoku
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(549, 366);
            this.Controls.Add(this.buttonSolution);
            this.Controls.Add(this.buttonInit);
            this.Controls.Add(this.TimerLabel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Sudoku";
            this.Text = "Sudoku";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem jeu_Item;
        private System.Windows.Forms.ToolStripMenuItem ouvrir_Item;
        private System.Windows.Forms.ToolStripMenuItem quitter_Item;
        private System.Windows.Forms.ToolStripMenuItem aideToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog OuvreGrille;
        private System.Windows.Forms.ToolStripMenuItem enregistrer_Item;
        private System.Windows.Forms.ToolStripMenuItem Aide_1;
        private System.Windows.Forms.ToolStripMenuItem Aide_2;
        private System.Windows.Forms.ToolStripMenuItem Aide_3;
        private System.Windows.Forms.ToolStripMenuItem Aide_4;
        private System.Windows.Forms.ToolStripMenuItem Aide_5;
        private System.Windows.Forms.ToolStripMenuItem Aide_6;
        private System.Windows.Forms.ToolStripMenuItem Aide_7;
        private System.Windows.Forms.ToolStripMenuItem Aide_8;
        private System.Windows.Forms.ToolStripMenuItem Aide_9;
        private System.Windows.Forms.Label TimerLabel;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button buttonInit;
        private System.Windows.Forms.Button buttonSolution;
        private System.Windows.Forms.SaveFileDialog sauverFichier;
    }
}

