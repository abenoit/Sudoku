using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Sudoku
{

    public class Case : TextBox
    {
        Sudoku Jeu;
        public int i, j;
        public int valeur;

        public Case(int a, int b, Sudoku s)
        {
            i = a;
            j = b;
            Jeu = s;
            this.Text = "";
            this.valeur = 0;
           // Pour un fond de couleur rouge
            this.BackColor = System.Drawing.Color.White;
            this.Size = new System.Drawing.Size(30,30);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabIndex = i*j;
            this.ReadOnly = true;
            this.TextChanged += new EventHandler(Case_TextChanged);
            this.DoubleClick += new EventHandler(Case_DoubleClick);
            this.TextAlign = HorizontalAlignment.Center;
        }

        public void Case_DoubleClick(object sender, EventArgs e)
        {
            if (this.Jeu.partieCommence)
            {
                //On colore en bleu la case selectionnée
                this.BackColor = System.Drawing.Color.Blue;
                // Si la case n'est pas vide on le signale
                if (this.valeur != 0)
                    MessageBox.Show("La case n'est pas vide ! ");
                // Si la case est vide, on recherche les valeurs possibles avec la fonction estValide
                else
                {
                    string possibilites = "Valeur(s) possible(s) ici : \n";

                    for (int k = 1; k <= this.Jeu.nb_cases; k++)
                    {
                        this.valeur = k;
                        if (this.Jeu.estValide(this.i, this.j))
                            possibilites += Convert.ToString(k) + "  ";
                        this.valeur = 0;
                    }
                    MessageBox.Show(possibilites);
                }

                this.BackColor = System.Drawing.Color.White;
            }
        }

        bool FiniGrille()
        {
            for (int i = 0; i < this.Jeu.nb_cases; i++)
            {
                for (int j = 0; j < this.Jeu.nb_cases; j++)
                {
                    if (this.Jeu.Grille[i, j].valeur == 0)
                        return false;
                }
            }
            return true;
        }

        void Case_TextChanged(object sender, EventArgs e)
        {
            if (this.BackColor == System.Drawing.Color.White)
            {
                try
                {
                    int nb_entre = int.Parse(this.Text);

                    if (nb_entre < 1 || nb_entre > this.Jeu.nb_cases+1)
                        throw new ArgumentOutOfRangeException();

                    this.Text = Convert.ToString(nb_entre);
                    this.valeur = nb_entre;

                    if (!this.Jeu.estValide(this.i, this.j))
                    {
                        this.BackColor = System.Drawing.Color.OrangeRed;
                        MessageBox.Show(this.Text + " impossible à cet endroit");
                        this.BackColor = System.Drawing.Color.White;
                        this.Text = "";
                        this.valeur = 0;
                    }
                    if (FiniGrille())
                    {
                        if (MessageBox.Show("Vous avez terminé le jeu \nVoulez vous recharger une grille", "Félicitation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            this.Jeu.ouvrir_Item_Click(sender, e);
                    }
                }
                catch (FormatException)
                {
                    if (this.Text != "")
                    {
                        MessageBox.Show("Vous n'avez pas entré un saisie numérique");
                        this.Text = "";
                    }
                    else
                        this.valeur = 0;
                    
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("Nombre non compris dans les bornes");
                    this.Text = "";
                }
            }
        }
    }

}
