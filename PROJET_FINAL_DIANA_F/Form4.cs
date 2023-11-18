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
    public partial class Form4 : Form
    {
        private bool programmeTrouve = false;
        private Form2 form2Reference;

        public Form4(Form2 form2)
        {
            InitializeComponent();
            this.form2Reference = form2;


            // Source pour l'image du moins: <a href="https://www.flaticon.com/fr/icones-gratuites/moins" title="moins icônes">Moins icônes créées par inkubators - Flaticon</a>
            richTextBox2.ReadOnly = true;
            richTextBox2.Enabled = false;

            richTextBox3.ReadOnly = true;
            richTextBox3.Enabled = false;

            richTextBox4.ReadOnly = true;
            richTextBox4.Enabled = false;
        }

        // Bouton Retour
        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 formPrincipal = new Form2();
            formPrincipal.Show();
        }

        // Bouton Rechercher
        private void button4_Click(object sender, EventArgs e)
        {
            string codeProgramme = richTextBox1.Text;

            if (string.IsNullOrWhiteSpace(codeProgramme))
            {
                label7.Text = "* Veuillez entrer un code de programme.";
                return;
            }

            if (Program.ProgrammeExiste(codeProgramme))
            {
                programmeTrouve = true;
                label7.Text = "* Programme trouvé.";
            }
            else
            {
                programmeTrouve = false;
                label7.Text = "* Le code du programme ne se trouve pas dans la liste de programmes.";
            }
        }

        // Bouton Supprimer
        private void button2_Click(object sender, EventArgs e) 
        {
            if (!programmeTrouve)
            {
                label7.Text = "* Veuillez d'abord rechercher le programme à supprimer.";
                return;
            }

            string codeProgramme = richTextBox1.Text;

            if (Program.SupprimerProgramme(codeProgramme))
            {
                programmeTrouve = false;
                richTextBox1.Clear();
                label7.Text = "* Programme supprimé avec succès.";
                form2Reference.ActualisationLabelNombre();
            }
            else
            {
                label7.Text = "* Une erreur est survenue lors de la suppression du programme.";
            }
        }

        // Bouton Annuler
        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }
    }
}
