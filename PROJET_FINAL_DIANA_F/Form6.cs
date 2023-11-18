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

namespace PROJET_FINAL_DIANA_F
{
    public partial class Form6 : Form
    {

        private Form2 form2Reference;
        public Form6(Form2 form2)
        {
            InitializeComponent();
            form2Reference = new Form2();

            // Source de l'image de l'étudiant: <a href="https://www.flaticon.com/fr/icones-gratuites/tolerance" title="tolérance icônes">Tolérance icônes créées par Freepik - Flaticon</a>

            // Desactiver la saisie
            richTextBox1.ReadOnly = true;
            richTextBox1.Enabled = false;

            // Remplissage du ComboBox1 avec les codes des programmes
            foreach (Programme programme in Program.ListeDesProgrammes)
            {
                comboBox1.Items.Add(programme.CodeProgramme);
            }

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
            comboBox1.Text = "";
            dateTimePicker1.Value = DateTime.Now;
        }

        // Bouton Ajouter
        private void button2_Click(object sender, EventArgs e)
        {
            string nom = richTextBox3.Text;
            string prenom = richTextBox4.Text;
            DateTime dateNaissance = dateTimePicker1.Value;
            string courriel = richTextBox2.Text;
            string codeProgramme = comboBox1.SelectedItem.ToString();

            // Vérifier s'il y a au moins 1 programme inscrit dans la liste de programmes
            if (Program.ListeDesProgrammes.Count < 0)
            {
                label9.Text = "* Veuillez sélectionner/créer un porgramme avant d'inscrire un étuidant.";
                return;
            }

            // Vérifier si tous les champs sont remplis
            if (string.IsNullOrWhiteSpace(richTextBox2.Text) ||
                string.IsNullOrWhiteSpace(richTextBox3.Text) ||
                string.IsNullOrWhiteSpace(richTextBox4.Text) ||
                string.IsNullOrEmpty(comboBox1.SelectedItem?.ToString()))
            {
                label9.Text = "* Veuillez remplir tous les champs ci-dessus.";
                return;
            }

            // Validation du courriel
            if (!System.Text.RegularExpressions.Regex.IsMatch(richTextBox2.Text, @"^[\w\.-]+@[\w\.-]+\.\w+$"))
            {
                label9.Text = "* Le courriel est invalide.";
                return; 
            }

            // Validation de la date de naissance
            if (!Program.ValiderDateNaissance(dateNaissance))
            {
                label9.Text = "* L'âge doit être compris entre 16 et 75 ans.";
                return;
            }

            // Validation du nom et prénom
            if (System.Text.RegularExpressions.Regex.IsMatch(richTextBox3.Text, @"\d") ||
                System.Text.RegularExpressions.Regex.IsMatch(richTextBox4.Text, @"\d"))
            {
                label9.Text = "* Le nom et le prénom ne doivent pas contenir de chiffres.";
                return;
            }

            // Construction du code de l'étudiant
            string codeEtudiant;
            if (nom.Length >= 3)
                codeEtudiant = nom.Substring(0, 3).ToUpper();
            else
                codeEtudiant = nom.ToUpper();

            codeEtudiant += prenom[0].ToString().ToUpper();

            richTextBox1.Text = codeEtudiant;

            // Vérifier si l'étudiant existe deja dans la liste des etudiants 
            if (Program.EtudiantExiste(codeEtudiant))
            {
                label9.Text = "* L'étudiant est déjà inscrit dans un autre programme.";
                return;
            }

            Etudiant nouvelEtudiant = new Etudiant(codeEtudiant, nom, prenom, dateNaissance, courriel, codeProgramme);

            // Si l'ajout est possible apres toutes les verifications
            if (Program.AjouterEtudiant(nouvelEtudiant))
            {
                // Effacer le contenu des champs pour permettre a l'utilisateur d'ajouter un autre etudiant
                richTextBox1.Clear();
                richTextBox2.Clear();
                richTextBox3.Clear();
                richTextBox4.Clear();
                comboBox1.Text = "";
                dateTimePicker1.Value = DateTime.Now;
                label9.Text = "* Étudiant ajouté avec succès.";
                form2Reference.ActualisationLabelNombre();
            }
        }
    }
}
