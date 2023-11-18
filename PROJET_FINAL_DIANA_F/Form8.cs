using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PROJET_FINAL_DIANA_F.Program;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PROJET_FINAL_DIANA_F
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();

            // Source de l'image des étudiants: <a href="https://www.flaticon.com/fr/icones-gratuites/la-diversite" title="la diversité icônes">La diversité icônes créées par Freepik - Flaticon</a>
            
            // Desactiver les cases pour ne pas permettre a l'utilisateur de saisir des informations dans les cases
            richTextBox1.ReadOnly = true;
            richTextBox1.Enabled = false;

            richTextBox2.ReadOnly = true;
            richTextBox2.Enabled = false;

            richTextBox3.ReadOnly = true;
            richTextBox3.Enabled = false;

            richTextBox4.ReadOnly = true;
            richTextBox4.Enabled = false;

            richTextBox5.ReadOnly = true;
            richTextBox5.Enabled = false;

            richTextBox6.ReadOnly = true;
            richTextBox6.Enabled = false;
        }

        // Bouton Retour
        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 formPrincipal = new Form2();
            formPrincipal.Show();
        }

        // Bouton Annuler
        private void button1_Click(object sender, EventArgs e)
        {
            // Effacer le contenu des champs pour permettre de reessayer d'entrer les données du programme
            richTextBox1.Clear();
            richTextBox2.Clear();
            richTextBox3.Clear();
            richTextBox4.Clear();
            richTextBox5.Clear();
            richTextBox6.Clear();
        }

        // Index actuel de l'étudiant affiché
        private int indexActuel = 0;

        // Methode qui permet de trouver les informations d'un étudiant selon l'index fourni
        private void chargerEtudiantSelonIndex(int index)
        {
            if (Program.ListeDesEtudiants.Count > 0 && index >= 0 && index < Program.ListeDesEtudiants.Count)
            {
                Etudiant etudiant = (Etudiant)Program.ListeDesEtudiants[index];
                richTextBox2.Text = etudiant.CodeEtudiant;
                richTextBox1.Text = etudiant.NomEtudiant;
                richTextBox3.Text = etudiant.PrenomEtudiant;
                richTextBox4.Text = etudiant.DateNaissance.ToString();
                richTextBox5.Text = etudiant.Courriel;
                richTextBox6.Text = etudiant.CodeProgrammeInscrit;

                indexActuel = index;
            }
        }

        // Bouton Premier
        private void button2_Click(object sender, EventArgs e)
        {
            if (Program.ListeDesEtudiants.Count == 0)
            {
                MessageBox.Show("Il n'y a pas d'étudiants dans la liste.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            chargerEtudiantSelonIndex(0);
        }

        // Bouton Précédent
        private void button4_Click(object sender, EventArgs e)
        {
            if (Program.ListeDesEtudiants.Count == 0)
            {
                MessageBox.Show("Il n'y a pas d'étudiants dans la liste.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (indexActuel > 0)
            {
                chargerEtudiantSelonIndex(indexActuel - 1);
            }
        }

        // Bouton Suivant
        private void button5_Click(object sender, EventArgs e)
        {
            if (Program.ListeDesEtudiants.Count == 0)
            {
                MessageBox.Show("Il n'y a pas d'étudiants dans la liste.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (indexActuel < Program.ListeDesEtudiants.Count - 1)
            {
                chargerEtudiantSelonIndex(indexActuel + 1);
            }
        }

        // Bouton Dernier
        private void button6_Click(object sender, EventArgs e)
        {
            if (Program.ListeDesEtudiants.Count == 0)
            {
                MessageBox.Show("Il n'y a pas d'étudiants dans la liste.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            chargerEtudiantSelonIndex(Program.ListeDesEtudiants.Count - 1);
        }
    }
}
