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
    public partial class Form7 : Form
    {
        private bool etudiantTrouve = false;
        private Form2 form2Reference;
        public Form7(Form2 form2)
        {
            InitializeComponent();
            this.form2Reference = form2;

            // Desactiver les cases pour ne pas permettre a l'utilisateur de saisir des informations dans les cases
            richTextBox2.ReadOnly = true;
            richTextBox2.Enabled = false;

            richTextBox3.ReadOnly = true;
            richTextBox3.Enabled = false;

            richTextBox4.ReadOnly = true;
            richTextBox4.Enabled = false;

            richTextBox5.ReadOnly = true;
            richTextBox5.Enabled = false;

            richTextBox7.ReadOnly = true;
            richTextBox7.Enabled = false;
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
            string codeEtudiant = richTextBox1.Text;

            if (string.IsNullOrWhiteSpace(codeEtudiant))
            {
                label9.Text = "* Veuillez entrer un code d'étudiant.";
                return;
            }

            if (Program.EtudiantExiste(codeEtudiant))
            {
                etudiantTrouve = true;
                label9.Text = "Étudiant trouvé.";
            }
            else
            {
                etudiantTrouve = false;
                label9.Text = "* Le code de l'étudiant ne se trouve pas dans la liste d'étudiants.";
            }
        }

        // Bouton Supprimer
        private void button2_Click(object sender, EventArgs e)
        {
            if (!etudiantTrouve)
            {
                label9.Text = "* Veuillez d'abord rechercher l'étudiant à supprimer.";
                return;
            }

            string codeEtudiant = richTextBox1.Text;

            if (Program.SupprimerEtudiant(codeEtudiant))
            {
                etudiantTrouve = false;
                label9.Text = "* Étudiant supprimé avec succès.";
                form2Reference.ActualisationLabelNombre();
            }
            else
            {
                label9.Text = "* Une erreur est survenue lors de la suppression de l'étudiant.";
            }
        }

        // Bouton Annuler
        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }
    }
}
