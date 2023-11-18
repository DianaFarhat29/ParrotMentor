using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROJET_FINAL_DIANA_F
{
    public partial class Form2 : Form
    {
        private string utilisateur = "mlazar";
        public Form2()
        {
            InitializeComponent();

            // Mise à jour du nombre d'étudiants et de programmes
            ActualisationLabelNombre();

            label7.Text = "Bienvenue " + utilisateur + " , ";

            // Source pour l'image WELCOME: <a href="https://www.flaticon.com/fr/icones-gratuites/bienvenue" title="bienvenue icônes">Bienvenue icônes créées par Freepik - Flaticon</a>
            // Source pour l'image d'étudiants: <a href="https://www.flaticon.com/fr/icones-gratuites/etudiant" title="étudiant icônes">Étudiant icônes créées par Voysla - Flaticon</a>
            // Source pour l'image du programme: <a href="https://www.flaticon.com/fr/icones-gratuites/universite" title="université icônes">Université icônes créées par Freepik - Flaticon</a>
        }

        private void ajouterProgrammeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 formAjoutProgramme = new Form3(this);
            formAjoutProgramme.Show();
        }

        private void supprimerProgrammeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 formSuppressionProgramme = new Form4(this);
            formSuppressionProgramme.Show();
        }

        private void listerProgrammeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 formListerProgramme = new Form5();
            formListerProgramme.Show();
        }

        private void ajouterÉtudiantToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 formAjoutEtudiant = new Form6(this);
            formAjoutEtudiant.Show();
        }

        private void supprimerEtudiantToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form7 formSuppressionEtudiant = new Form7(this);
            formSuppressionEtudiant.Show();
        }

        private void listerEtudiantToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form8 formListerEtudiant = new Form8();
            formListerEtudiant.Show();
        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult confirmation = MessageBox.Show("Voulez-vous vraiment quitter?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmation == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        // Methode qui permet de mettre à jour donnée stockée pour le nombre d'étudiants et programmes dans leur liste respective
        public void ActualisationLabelNombre()
        {
            int nbrEtudiants = Program.ListeDesEtudiants.Count;
            int nbrProgrammes = Program.ListeDesProgrammes.Count;

            label3.Text = nbrEtudiants.ToString();
            label5.Text = nbrProgrammes.ToString();
        }
    }
}