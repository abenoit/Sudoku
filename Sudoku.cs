using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;

namespace Sudoku
{
    public partial class Sudoku : Form
    {
        public Case[,] Grille;
        public int nb_cases;
        private int temps_sec, temps_min, temps_heure;
        public bool partieCommence;

        public Sudoku()
        {
            InitializeComponent();
            nb_cases = 9;
            this.Grille = new Case[nb_cases, nb_cases];
            initGrille(this.Grille);
            temps_sec = temps_min = temps_heure = 0;
            TimerLabel.Text = "Temps écoulé : \n ";
            timer.Tick += new EventHandler(timer_Tick);
            partieCommence = false;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            // code pour le timer
            if (partieCommence)
            {
                temps_sec++;
                if (temps_sec == 60)
                {
                    //quand les secondes atteignent 60 on incrémente les minutes
                    temps_sec = 0;
                    temps_min++;
                }
                if (temps_min == 60)
                {
                    // quand les minutes atteignent 60 on incrément les heures
                    temps_min = 0;
                    temps_heure++;
                }

                if (temps_heure == 0 && temps_min == 0)
                    //on cache les heures et les minutes quand elles sont égales à 0
                    // on n'affiche alors que les secondes.
                    TimerLabel.Text = "Temps écoulé : \n " + Convert.ToString(temps_sec) + " s ";
                else if (temps_heure == 0)
                    TimerLabel.Text = "Temps écoulé : \n " + Convert.ToString(temps_min) + " min " + Convert.ToString(temps_sec) + " s ";
                else
                    TimerLabel.Text = "Temps écoulé : \n " + Convert.ToString(temps_heure) + " h " + Convert.ToString(temps_min) + " min " + Convert.ToString(temps_sec) + " s ";

            }
        }

        private void quitter_Item_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void initGrille(Case[,] G)
        {
            // Fonction pour initialiser la grille. x et y sont les coordonnées pour commencer
            // à placer les cases à partir de là.
            int x = 40, y = 40;
            for (int k = 0; k < nb_cases; k++)
            {
                for (int l = 0; l < nb_cases; l++)
                {
                    // On créé une nouvelle case 
                    G[k, l] = new Case(k, l, this);
                    G[k, l].Location = new System.Drawing.Point(x, y);
                    G[k, l].Name = "case";

                    this.Controls.Add(G[k, l]);
                    // on incrémente le x pour éloigner chaque case de 35 vers la droite.
                    x += 35;
                }
                x = 40;
                y += 35;
            }
        }

        public bool estValide(int i, int j)
        {
            // Dans cette fonction on teste si un nombre rentré dans une case est valide ou non
            int nb, cpt_ligne, cpt_colonne, cpt_region;
            // on stocke la valeur de la case dont les coordonnées sont passées en paramètre
            nb = (this.Grille[i, j].valeur);
            cpt_ligne = cpt_colonne = cpt_region = 0;

            // test du cas où il y aurait deux fois le même chiffre dans la ligne
            for (int k = 0; k < nb_cases; k++)
            {
                if (this.Grille[i, k].valeur == nb)
                    cpt_ligne++;
            }
            // test du cas où il y aurait deux fois le même chiffre dans la colonne
            for (int l = 0; l < nb_cases; l++)
            {
                if ((this.Grille[l, j].valeur) == nb)
                    cpt_colonne++;
            }
            // test du cas ou il y deux fois le même chiffre dans une région : 
            //on se place sur la premiere case ( en haut à gauche) de la région
            while (i % 3 != 0)
                i--;
            while (j % 3 != 0)
                j--;
            for (int m = i; m < i + 3; m++)
            {
                for (int n = j; n < j + 3; n++)
                {
                    if ((this.Grille[m, n].valeur) == nb)
                        cpt_region++;
                }
            }
            // Si on trouve plus d'une fois le nombre dans la colonne / la ligne / la zone
            // Le nombre de la case ne peut pas etre valide et on retourne donc faux.
            if (cpt_region > 1 || cpt_ligne > 1 || cpt_colonne > 1)
                return false;
            else
                return true;
        }
        private void reinit_grille()
        {
            // Fonction qui permet de remettre la grille a l'état initial.
            for (int i = 0; i < nb_cases; i++)
            {
                for (int j = 0; j < nb_cases; j++)
                {
                    this.Grille[i, j].valeur = 0;
                    this.Grille[i, j].Text = "";
                    this.Grille[i, j].BackColor = System.Drawing.Color.White;
                }
            }
        }

        private bool verifFichier(string nom_fic)
        {
            // On vérifie ici le fichier chargé au cas où il ne serait pas fonctionnel.
            bool fic_ok = true;
            string ligne;
            StreamReader srNB = new StreamReader(nom_fic);
            //On regarde combien il y a de ligne dans le fichier
            int cpt_ligne = 0;
            ligne = srNB.ReadLine();
            while (ligne != null)
            {
                cpt_ligne++;
                ligne = srNB.ReadLine();
            }
            srNB.Close();
            // et on vérifie s'il y a le bon nombre de ligne :
            // Soit 9 lignes de 9 chiffres ( fichier de Mr. Ruby)
            // Soit 9 lignes de 9 chiffres ( nombres dans la grille ) + 3 lignes ( 1 pour les secondes, 1 pour les minutes, 1 pour les heures) 
            // + 9 autres lignes de 9 chiffres pour savoir quelles cases doivent être grisées ou non 
            if (cpt_ligne != nb_cases && cpt_ligne != 2 * nb_cases + 3)
                fic_ok = false;

            StreamReader sr = new StreamReader(nom_fic);
            int i = 0, j = 0, k = 0;
            ligne = sr.ReadLine();
            //Vérification pour la premiere matrice
            while (i < nb_cases && fic_ok && ligne != null)
            {
                //On vérifie la longueur de la ligne
                if (ligne.Length != nb_cases)
                    fic_ok = false;
                //On vérifie qu'elle contient que des chiffres
                try
                {
                    int.Parse(ligne);
                }
                catch (FormatException)
                {
                    fic_ok = false;
                }
                //On passe à la ligne suivante
                ligne = sr.ReadLine();
                i++;
            }
            //Vérification pour les secondes, minutes et heures
            if (ligne != null && fic_ok)
            {
                while (k < 3 && fic_ok)
                {
                    if (ligne.Length > 2)
                        fic_ok = false;
                    try
                    {
                        int.Parse(ligne);
                    }
                    catch (FormatException)
                    {
                        fic_ok = false;
                    }
                    ligne = sr.ReadLine();
                    k++;
                }
                //Vérification pour la seconde matrice
                while (j < nb_cases && fic_ok && ligne != null)
                {
                    if (ligne.Length != nb_cases)
                        fic_ok = false;
                    //On vérifie qu'elle contient que des chiffres
                    try
                    {
                        int.Parse(ligne);
                    }
                    catch (FormatException)
                    {
                        fic_ok = false;
                    }
                    //On passe à la ligne suivante
                    ligne = sr.ReadLine();
                    j++;
                }
            }
            return fic_ok;
        }

        private void chargerGrille(string nom)
        {
            if (!partieCommence)
            {
                if (verifFichier(nom))
                {
                    StreamReader sr = new StreamReader(nom);
                    string ligne;
                    string tmp;

                    for (int i = 0; i < nb_cases; i++)
                    {
                        ligne = sr.ReadLine();

                        for (int j = 0; j < nb_cases; j++)
                        {
                            tmp = ligne.Remove(1, ligne.Length - 1);
                            Grille[i, j].valeur = int.Parse(tmp);
                            if (int.Parse(tmp) == 0)
                            {
                                Grille[i, j].Text = "";
                                Grille[i, j].ReadOnly = false;
                            }
                            else
                            {
                                Grille[i, j].Text = tmp;
                                Grille[i, j].BackColor = System.Drawing.Color.LightGray;
                                Grille[i, j].ReadOnly = true;
                            }
                            ligne = ligne.Remove(0, 1);
                        }
                    }
                    // On vérifie s'il existe une ligne suivante : 
                    // ce sera le cas d'un fichier enregistré : on y a stocké le timer
                    // et des chiffres trouvés ( seconde matrice)
                    string ligne_sec = sr.ReadLine();
                    if (ligne_sec != null)
                        temps_sec = int.Parse(ligne_sec);
                    else
                        temps_sec = 0;

                    string ligne_min = sr.ReadLine();
                    if (ligne_min != null)
                        temps_min = int.Parse(ligne_min);
                    else
                        temps_min = 0;

                    string ligne_heure = sr.ReadLine();
                    if (ligne_heure != null)
                        temps_heure = int.Parse(ligne_heure);
                    else
                        temps_heure = 0;

                    // Pour la couleur des cases
                    string ligne_tmp = sr.ReadLine();
                    if (ligne_tmp != null)
                    {
                        for (int k = 0; k < nb_cases; k++)
                        {
                            if (k == 0)
                                ligne = ligne_tmp;
                            else
                                ligne = sr.ReadLine();
                            for (int l = 0; l < nb_cases; l++)
                            {
                                tmp = ligne.Remove(1, ligne.Length - 1);
                                if (int.Parse(tmp) == 0)
                                {
                                    Grille[k, l].BackColor = System.Drawing.Color.White;
                                    Grille[k, l].ReadOnly = false;
                                }
                                else
                                    Grille[k, l].BackColor = System.Drawing.Color.LightGray;

                                ligne = ligne.Remove(0, 1);
                            }
                        }
                    }
                    sr.Close();
                    partieCommence = true;
                }
                else
                {
                    reinit_grille();
                    MessageBox.Show("Le fichier n'est pas valide !");
                    partieCommence = false;
                }
            }
            else
            {
                reinit_grille();
                partieCommence = false;
                chargerGrille(nom);
            }
        }

        public void ouvrir_Item_Click(object sender, EventArgs e)
        {
            // Quand on clique sur "Ouvrir un fichier" on stocke le nom du fichier en question
            string nomFichier;
            OuvreGrille.Title = "Fichier à charger ";
            DialogResult res = OuvreGrille.ShowDialog();

            if (res == DialogResult.OK)
            {
                nomFichier = System.IO.Path.GetFullPath(OuvreGrille.FileName);
                chargerGrille(nomFichier);
                enregistrer_Item.Enabled = true;
                timer.Enabled = true;
                timer.Start();
                // si le fichier est valide on charge la grille et on enclenche le timer
            }
            else if (res == DialogResult.Cancel)
            {
                if (MessageBox.Show("Vous êtes sûr de vouloir quitter ?", "Certain ?", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    ouvrir_Item_Click(sender, e);
                else
                    Application.Exit();
            }
        }

        private void enregistrer_Item_Click(object sender, EventArgs e)
        {
            // On enregistre le fichier sous un format .txt
            if (partieCommence)
            {
                sauverFichier.Filter = " Text|*.txt";
                sauverFichier.Title = "Sauvegarde Sudoku";

                string nom = "";
                DialogResult res = sauverFichier.ShowDialog();


                if (sauverFichier.FileName != "")
                {
                    nom = sauverFichier.FileName;
                    StreamWriter sw = new StreamWriter(nom);


                    string ligne = "";
                    for (int i = 0; i < nb_cases; i++)
                    {
                        for (int j = 0; j < nb_cases; j++)
                        {
                            ligne += Convert.ToString(Grille[i, j].valeur);
                        }
                        sw.WriteLine(ligne);
                        ligne = "";
                    }
                    // secondes : 
                    sw.WriteLine(Convert.ToString(temps_sec));
                    // minutes :
                    sw.WriteLine(Convert.ToString(temps_min));
                    //heures
                    sw.WriteLine(Convert.ToString(temps_heure));

                    for (int i = 0; i < nb_cases; i++)
                    {
                        for (int j = 0; j < nb_cases; j++)
                        {
                            if (Grille[i, j].BackColor == System.Drawing.Color.White)
                                ligne += "0";
                            else if (Grille[i, j].BackColor == System.Drawing.Color.LightGray)
                                ligne += "1";
                        }
                        sw.WriteLine(ligne);
                        ligne = "";
                    }

                    sw.Close();
                    MessageBox.Show("Votre progression a bien été sauvegardée . \n Son nom est " + nom);
                }

            }
        }

        private void Aide_Click(int nombre, object sender, EventArgs e)
        {
            if (partieCommence)
            {
                // On parcours la matrice
                for (int i = 0; i < nb_cases; i++)
                {
                    for (int j = 0; j < nb_cases; j++)
                    {
                        if (Grille[i, j].valeur == 0)
                        {
                            // On vérifie que la case est vide. Si elle l'est on stocke le nombre dedans
                            Grille[i, j].valeur = nombre;
                            // puis on vérifie s'il est valide ou non.
                            if (estValide(i, j))
                            {
                                // S'il l'est, on colore la case et on écrit le chiffre dedans.
                                Grille[i, j].BackColor = System.Drawing.Color.Red;
                                Grille[i, j].Text = Convert.ToString(nombre);
                            }
                            Grille[i, j].valeur = 0;
                        }
                    }
                }

                if (MessageBox.Show("Valeurs possibles") == DialogResult.OK)
                {
                    // on reparcours la matrice pour qu'une fois que l'utilisateur ait appuyé sur "Ok"
                    // Les cases reprennent la couleur originale et redeviennent vides.
                    for (int i = 0; i < nb_cases; i++)
                    {
                        for (int j = 0; j < nb_cases; j++)
                        {
                            if (Grille[i, j].BackColor == System.Drawing.Color.Red)
                            {
                                Grille[i, j].Text = "";
                                Grille[i, j].BackColor = System.Drawing.Color.White;
                            }
                        }
                    }

                }
            }
            else
                if (MessageBox.Show("Aucune partie n'est commencée ! \n Ouvrez une grille pour jouer?", "Erreur", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    ouvrir_Item_Click(sender, e);

        }

        private void Aide_1_Click(object sender, EventArgs e)
        {
            Aide_Click(1, sender, e);
        }

        private void Aide_2_Click(object sender, EventArgs e)
        {
            Aide_Click(2, sender, e);
        }

        private void Aide_3_Click(object sender, EventArgs e)
        {
            Aide_Click(3, sender, e);
        }

        private void Aide_4_Click(object sender, EventArgs e)
        {
            Aide_Click(4, sender, e);
        }

        private void Aide_5_Click(object sender, EventArgs e)
        {
            Aide_Click(5, sender, e);
        }

        private void Aide_6_Click(object sender, EventArgs e)
        {
            Aide_Click(6, sender, e);
        }

        private void Aide_7_Click(object sender, EventArgs e)
        {
            Aide_Click(7, sender, e);
        }

        private void Aide_8_Click(object sender, EventArgs e)
        {
            Aide_Click(8, sender, e);
        }

        private void Aide_9_Click(object sender, EventArgs e)
        {
            Aide_Click(9, sender, e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics dc = e.Graphics;
            int x, y;
            x = y = 37;
            Pen blackPen = new Pen(Color.Black, 3);
            for (int i = 0; i < nb_cases / 3; i++)
            {
                for (int j = 0; j < nb_cases / 3; j++)
                {
                    dc.DrawRectangle(blackPen, x, y, 105, 105);
                    x += 105;
                }
                x = 37;
                y += 105;
            }


        }

        private void buttonInit_Click(object sender, EventArgs e)
        {
            // Fonction correspondant au boutton "Recommencer au début"
            // on ré initialise la matrice : on ne garde que les case grises
            // et on remet les cases blanches à 0 
            if (partieCommence)
            {
                if (MessageBox.Show("Êtes-vous sûr de vouloir recommencer du début ? ", "?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {

                    for (int i = 0; i < nb_cases; i++)
                    {
                        for (int j = 0; j < nb_cases; j++)
                        {
                            if (Grille[i, j].BackColor == System.Drawing.Color.White)
                            {
                                Grille[i, j].Text = "";
                                Grille[i, j].valeur = 0;
                            }
                        }
                    }
                    temps_sec = temps_min = temps_heure = 0;
                }

            }
        }

        private void buttonSolution_Click(object sender, EventArgs e)
        {
            //Fonction permettant de générer une solution
            int cpt = 0;
            int tmp_val = 0;
            int i = 0, j = 0;
            bool ok = false;
            if (partieCommence)
            {
                // Parcours de la matrice
                // Dès qu'on trouve une valeur possible ( c'est à dire une seule valeur possible
                // à cet endroit ) on sort de la boucle et on affiche la solution .
                
                while (i < nb_cases && !ok)
                {
                    while (j < nb_cases && !ok)
                    {
                        if (Grille[i, j].valeur == 0)
                        {
                            // On vérifie chaque nombre s'il peut correspondre à la case
                            for (int k = 1; k <= nb_cases; k++)
                            {
                                Grille[i, j].valeur = k;
                                if (estValide(i, j))
                                {
                                    cpt++;
                                    tmp_val = k;
                                }

                                Grille[i, j].valeur = 0;
                            }
                            //S'il n'y a qu'une solution possible, sa valeur est stockée dans tmp_val
                            // On l'affiche dans la case correspondante.
                            if (cpt == 1)
                            {
                                Grille[i, j].valeur = tmp_val;
                                Grille[i, j].Text = Convert.ToString(tmp_val);
                                ok = true;
                                Grille[i, j].BackColor = System.Drawing.Color.Pink;
                                MessageBox.Show("Voici la solution trouvée : ");
                                Grille[i, j].BackColor = System.Drawing.Color.White;


                            }
                            else if (cpt == 0)
                                MessageBox.Show(" Aucune solution n'a été trouvée . ");
                            else
                                cpt = 0;
                        }
                        j++;
                    }
                    j = 0;
                    i++;
                }
                
                // Solution a partir de la base de la fonction "Aide"
                // dans le cas ou il existe 1 seul nombre possible dans le zone
                // exemple : quand on fait Aide du nombre 1 et qu'un 1 apparait seul dans une zone
                // c'est qu'il est correct à son endroit.
                i = 0;
                j = 0;
                int tmp_i = 0, tmp_j = 0;
                int val_case = 1;
                bool ok_aide = false;
                int cpt_region = 0;

                //Si aucune solution n'a été trouvée précedemment avec l'autre méthode
                if (!ok)
                {
                    // i et j pour parcourir les région
                    while (i < nb_cases && !ok_aide)
                    {
                        while (j < nb_cases && !ok_aide)
                        {
                            // val case pour tester toutes les valeurs possibles ( de 1 à 9 )
                            while (val_case <= nb_cases && !ok_aide)
                            {
                                // ligne et colonne pour parcourir toutes les cases d'une région
                                // délimitée par i et j.
                                for (int ligne = 0; ligne < nb_cases / 3; ligne++)
                                {
                                    for (int colonne = 0; colonne < nb_cases / 3; colonne++)
                                    {
                                        if (Grille[i + ligne, j + colonne].valeur == 0)
                                        {
                                            // on met la valeur val_case dans la case pour tester si elle est possible
                                            Grille[i + ligne, j + colonne].valeur = val_case;
                                            if (estValide(i + ligne, j + colonne))
                                            {
                                                // si un nombre est valide dans la région on incrémente le compteur
                                                tmp_i = i + ligne;
                                                tmp_j = j + colonne;
                                                cpt_region++;
                                            }
                                            // puis on remet la case a la valeur 0
                                            Grille[i + ligne, j + colonne].valeur = 0;
                                        }
                                    }
                                }
                                // S'il n'existe qu'une solution par région pour un nombre donné
                                // stocké dans tmp_val
                                if (cpt_region == 1)
                                {
                                    // On l'affiche et on le signale a l'utilisateur, on renre sa valeur.
                                    ok_aide = true;
                                    tmp_val = val_case;
                                    Grille[tmp_i, tmp_j].valeur = tmp_val;
                                    Grille[tmp_i, tmp_j].Text = Convert.ToString(tmp_val);
                                    Grille[tmp_i, tmp_j].BackColor = System.Drawing.Color.Pink;
                                    MessageBox.Show("Voici la solution trouvée : ");
                                    Grille[tmp_i, tmp_j].BackColor = System.Drawing.Color.White;
                                }
                                else
                                {
                                    //Sinon on regarde les régions suivantes et on remet le compteur à 0
                                    cpt_region = 0;
                                }
                                val_case++;
                            }
                            // on repasse la valeur a 1 pour toutes les reparcourir dans une autre région
                            val_case = 1;
                            j += 3;
                        }
                        j = 0;
                        i += 3;
                    }
                }
            }
        }
    }
}
