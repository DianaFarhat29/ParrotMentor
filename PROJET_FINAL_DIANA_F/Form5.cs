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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        // Bouton Retour
        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 formPrincipal = new Form2();
            formPrincipal.Show();
        }

        // Methode qui permet de mettre a jour les donnees de la grille
        private void mettreAJourGrille()
        {
            dataGridView1.DataSource = null; 
            dataGridView1.DataSource = Program.ListerProgrammesInscrits();
        }

        // Grille
        private void Form5_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;

            // Colonne pour le code du programme
            DataGridViewTextBoxColumn colCodeProgramme = new DataGridViewTextBoxColumn();
            colCodeProgramme.HeaderText = "Code Programme";
            colCodeProgramme.DataPropertyName = "CodeProgramme"; 
            dataGridView1.Columns.Add(colCodeProgramme);

            // Colonne pour le domaine
            DataGridViewTextBoxColumn colDomaine = new DataGridViewTextBoxColumn();
            colDomaine.HeaderText = "Domaine";
            colDomaine.DataPropertyName = "Domaine"; 
            dataGridView1.Columns.Add(colDomaine);

            // Colonne pour le nom du programme
            DataGridViewTextBoxColumn colNomProgramme = new DataGridViewTextBoxColumn();
            colNomProgramme.HeaderText = "Nom du Programme";
            colNomProgramme.DataPropertyName = "NomProgramme"; 
            dataGridView1.Columns.Add(colNomProgramme);

            // Colonne pour le nombre d'heures
            DataGridViewTextBoxColumn colNbrHeures = new DataGridViewTextBoxColumn();
            colNbrHeures.HeaderText = "Nombre d'Heures";
            colNbrHeures.DataPropertyName = "NbrHeures"; 
            dataGridView1.Columns.Add(colNbrHeures);

            mettreAJourGrille();
        }
    }
}
