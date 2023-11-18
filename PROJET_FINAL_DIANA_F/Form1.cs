using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PROJET_FINAL_DIANA_F
{
    public partial class Form1 : Form
    {
        private string utilisateur = "mlazar";
        private string motdePasse = "1234";
        private int tentatives = 3;

        public Form1()
        {
            InitializeComponent();

            // Source point d'intérogation: <a href="https://www.flaticon.com/fr/icones-gratuites/aide" title="aide icônes">Aide icônes créées par I Wayan Wika - Flaticon</a>
            // Source de l'image du nom d'utilisateur: <a href="https://www.flaticon.com/fr/icones-gratuites/utilisateur" title="utilisateur icônes">Utilisateur icônes créées par Freepik - Flaticon</a>
            // Source de l'image du cadenas: <a href="https://www.flaticon.com/fr/icones-gratuites/fermer-a-cle" title="fermer à clé icônes">Fermer à clé icônes créées par Freepik - Flaticon</a>
            // Source de l'image du Logo Perroquet: <a href="https://www.flaticon.com/fr/icones-gratuites/perroquet" title="perroquet icônes">Perroquet icônes créées par Jesus Chavarria - Flaticon</a>
            // Source de l'image du login: https://www.freepik.com/free-vector/sign-page-abstract-concept-illustration_12291223.htm#query=login&position=5&from_view=search&track=sph

        }

        // Bouton Quitter
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult confirmation = MessageBox.Show("Voulez-vous vraiment quitter?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmation == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        // Bouton Connexion
        private void button1_Click_1(object sender, EventArgs e)
        {
            string utilisateurSaisi = textBox1.Text;
            string motdePasseSaisi = textBox2.Text;

            if (utilisateurSaisi == utilisateur && motdePasseSaisi == motdePasse)
            {
                // Si l'utilisateur s'est connecté avec succès, le form du tableau de bord s'affiche
                this.Hide();
                Form2 mainForm = new Form2();
                mainForm.Show();
            }
            else
            {
                tentatives--;
                if (tentatives <= 0)
                {
                    label5.Text = "* Connexion non autorisée.\r\n Le nombre maximal de tentatives a été atteint.\r\n Veuillez réessayer plus tard.";

                    // Le bouton de connexion est désactivé pour que l'utilisateur ne puisse plus essayer de se connecter 
                    button1.Enabled = false;
                }
                else
                {
                    label5.Text = "* Nom d'utilisateur/mot de passe invalide.\r\n Tentatives restantes: " + tentatives;
                }
            }
        }
    }
}
