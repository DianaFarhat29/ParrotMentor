using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PROJET_FINAL_DIANA_F.Program;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PROJET_FINAL_DIANA_F
{
    public partial class Form3 : Form
    {
        private Form2 form2Reference;

        public Form3(Form2 form2)
        {
            InitializeComponent();

            this.form2Reference = form2;

            // Source pour l'image du plus: <a href="https://www.flaticon.com/fr/icones-gratuites/ajouter" title="ajouter icônes">Ajouter icônes créées par inkubators - Flaticon</a>
        }   // Image du programme: <a href="https://www.flaticon.com/fr/icones-gratuites/ecole" title="ecole icônes">Ecole icônes créées par Freepik - Flaticon</a>

        // Bouton Retour
        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide(); 
            Form2 formPrincipal = new Form2();
            formPrincipal.Show(); 
        }

        // Bouton Ajouter
        private void button2_Click(object sender, EventArgs e)
        {
            string code = richTextBox1.Text;
            string domaine = richTextBox2.Text;
            string nom = richTextBox3.Text;
            double nbrHeures;

            // Vérifier si tous les champs sont remplis
            if (string.IsNullOrWhiteSpace(richTextBox1.Text) ||
                string.IsNullOrWhiteSpace(richTextBox2.Text) ||
                string.IsNullOrWhiteSpace(richTextBox3.Text) ||
                string.IsNullOrWhiteSpace(richTextBox4.Text))
            {
                label8.Text = "* Veuillez remplir tous les champs ci-dessus.";
                return;
            }

            // Validation du domaine et du nom
            if (System.Text.RegularExpressions.Regex.IsMatch(richTextBox2.Text, @"\d") ||
                System.Text.RegularExpressions.Regex.IsMatch(richTextBox3.Text, @"\d"))
            {
                label8.Text = "* Le domaine et/ou le nom du programme ne doivent pas contenir de chiffres.";
                return;
            }

            // Validation du nombre d'heures
            if (!double.TryParse(richTextBox4.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out nbrHeures) ||
                nbrHeures < 350 || nbrHeures > 8000)
            {
                label8.Text = "* Le nombre d'heures doit être un nombre valide entre 350 et 8000.";
                return;
            }

            // Vérifier si le programme existe déjà dans la liste des programmes
            if (Program.ProgrammeExiste(code))
            {
                label8.Text = "* Ce programme existe déjà dans la liste.";
                return;
            }

            Programme nouveauProgramme = new Programme(code, domaine, nom, nbrHeures);

            if (Program.AjouterProgramme(nouveauProgramme))
            {
                // Effacer le contenu des champs pour permettre l'ajout d'un autre programme si désiré
                richTextBox1.Clear();
                richTextBox2.Clear();
                richTextBox3.Clear();
                richTextBox4.Clear();

                // Mise à jour du nombre d'étudiants et de programmes
                form2Reference.ActualisationLabelNombre();

                label8.Text = "* Programme ajouté avec succès.";
            }
            else
            {
                label8.Text = "* Erreur lors de l'ajout du programme.";
            }
        }

        // Bouton Annuler
        private void button1_Click(object sender, EventArgs e)
        {
            // Effacer le contenu des champs pour permettre de reessayer d'entrer les données du programme
            richTextBox1.Clear();
            richTextBox2.Clear();
            richTextBox3.Clear();
            richTextBox4.Clear();
        }
    }
}
