using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROJET_FINAL_DIANA_F
{
    internal static class Program
    {
        /// <summary>
        /// Programme qui permet la gestion de programmes et étudiants inscrits dans un collège à partir d'une application appellées "ParrotTutor"
        /// par Diana Farhat, 2023
        /// </summary>

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }


        //////////////////////////////////////////////////////////////////////////////////////////////////////


        // Creation de la structure Programme
        public struct Programme
        {
            private string _codeProgramme;
            private string _domaine;
            private string _nomProgramme;
            private double _nbrHeures;

            // Encapsulation des attributs de struct Programme
            public string CodeProgramme { get => _codeProgramme; set => _codeProgramme = value; }
            public string Domaine { get => _domaine; set => _domaine = value; }
            public string NomProgramme { get => _nomProgramme; set => _nomProgramme = value; }
            public double NbrHeures { get => _nbrHeures; set => _nbrHeures = value; }

            // Constructeur de struct Programme
            public Programme(string codeProgramme, string domaine, string nomProgramme, double nbrHeures)
            {
                _codeProgramme = codeProgramme;
                _domaine = domaine;
                _nomProgramme = nomProgramme;
                _nbrHeures = nbrHeures;
            }
        }

        // Création de la structure Etudiant
        public struct Etudiant
        {
            private string _codeEtudiant;
            private string _nomEtudiant;
            private string _prenomEtudiant;
            private DateTime _dateNaissance;
            private string _courriel;
            private string _codeProgrammeInscrit;

            // Encapsulation des attributs de struct Etudiant
            public string CodeEtudiant { get => _codeEtudiant; set => _codeEtudiant = value; }
            public string NomEtudiant { get => _nomEtudiant; set => _nomEtudiant = value; }
            public string PrenomEtudiant { get => _prenomEtudiant; set => _prenomEtudiant = value; }
            public DateTime DateNaissance { get => _dateNaissance; set => _dateNaissance = value; }
            public string Courriel { get => _courriel; set => _courriel = value; }
            public string CodeProgrammeInscrit { get => _codeProgrammeInscrit; set => _codeProgrammeInscrit = value; }

            // Constructeur de struct Etudiant
            public Etudiant(string codeEtudiant, string nomEtudiant, string prenomEtudiant, DateTime dateNaissance, string courriel, string codeProgrammeInscrit)
            {
                _codeEtudiant = codeEtudiant;
                _nomEtudiant = nomEtudiant;
                _prenomEtudiant = prenomEtudiant;
                _dateNaissance = dateNaissance;
                _courriel = courriel;
                _codeProgrammeInscrit = codeProgrammeInscrit;
            }
        }

        // Creation du ArrayList qui va stocker les programmes inscrits du college
        public static ArrayList ListeDesProgrammes = new ArrayList();

        // Creation du ArrayList qui va stocker les etudiants inscrits du college
        public static ArrayList ListeDesEtudiants = new ArrayList();

        // Methode pour ajouter un programme
        public static bool AjouterProgramme(Programme programme)
        {
            // Vérification de l'existence du programme avant l'ajout
            if (ProgrammeExiste(programme.CodeProgramme))
            {
                return false;  
            }

            // Validation du programme avant l'ajout
            if (ValiderEntreeProgramme(programme))
            {
                ListeDesProgrammes.Add(programme);
                return true;
            }
            return false;
        }

        // Methode pour supprimer un programme
        public static bool SupprimerProgramme(string codeProgramme)
        {
            // Verification qu'aucun etudiant n'est inscrit au programme en question
            foreach (Etudiant etudiant in ListeDesEtudiants)
            {
                if (etudiant.CodeProgrammeInscrit == codeProgramme)
                {
                    // Dans le cas ou un étudiant est inscrit à ce programme, la suppression n'est pas permise
                    return false;
                }
            }

            // Dans le cas ou aucun étudiant est inscrit à ce programme, la suppression peut se faire
            foreach (Programme programme in ListeDesProgrammes)
            {
                if (programme.CodeProgramme == codeProgramme)
                {
                    ListeDesProgrammes.Remove(programme);
                    return true;
                }
            }
            return false;
        }

        // Methode pour lister les programme inscrits du college
        public static List<Programme> ListerProgrammesInscrits()
        {
            List<Programme> programmes = new List<Programme>();

            for (int i = 0; i < ListeDesProgrammes.Count; i++)
            {
                if (ListeDesProgrammes[i] is Programme programme)
                {
                    programmes.Add(programme);
                }
            }

            return programmes;
        }

        // Methode qui valide l'entree de l'utilisateur pour le domaine et le nom du programme qui doivent etre seulement composes de lettres.
        // Pour le nombre d'heures du programme, celui-ci doit etre seulement compose de chiffres (double) et etre dans l'intervalle [350,8000]
        public static bool ValiderEntreeProgramme(Programme programme)
        {
            bool validationDomaine;
            bool validationNomProgramme;
            bool validationNbrHeures;
            bool validationCodeProgramme;

            // Le code doit peut etre compose de lettres et de chiffres
            validationCodeProgramme = System.Text.RegularExpressions.Regex.IsMatch(programme.CodeProgramme, @"^[a-zA-Z0-9]+$");

            // Le domaine doit seulement etre compose de lettres
            validationDomaine = System.Text.RegularExpressions.Regex.IsMatch(programme.Domaine, @"^[a-zA-Z\s]+$");

            // Le nom doit seulement etre compose de lettres
            validationNomProgramme = System.Text.RegularExpressions.Regex.IsMatch(programme.NomProgramme, @"^[a-zA-Z\s]+$");

            // Le nbrHeures doit etre dans l'intervalle [350,8000]
            validationNbrHeures = programme.NbrHeures >= 350 && programme.NbrHeures <= 8000;

            return (validationCodeProgramme && validationDomaine && validationNomProgramme && validationNbrHeures);
        }

        // Méthode pour vérifier l'existence d'un programme
        public static bool ProgrammeExiste(string codeProgramme)
        {
            for (int i = 0; i < ListeDesProgrammes.Count; i++)
            {
                if (((Programme)ListeDesProgrammes[i]).CodeProgramme == codeProgramme)
                {
                    return true;
                }
            }
            return false;
        }

        // Methode pour ajouter un etudiant
        public static bool AjouterEtudiant(Etudiant etudiant)
        {
            // Validation de l'etudiant avant l'ajout
            if (ValiderEntreeEtudiant(etudiant))
            {
                ListeDesEtudiants.Add(etudiant);
                return true;
            }
            return false;
        }

        // Methode pour supprimer un etudiant
        public static bool SupprimerEtudiant(string CodeEtudiant)
        {
            foreach (Etudiant etudiant in ListeDesEtudiants)
            {
                if (etudiant.CodeEtudiant == CodeEtudiant)
                {
                    ListeDesEtudiants.Remove(etudiant);
                    return true;
                }
            }
            return false;
        }

        // Methode pour lister les etudiants inscrits du college
        public static List<Etudiant> ListerEtudiantsInscrits()
        {
            List<Etudiant> etudiants = new List<Etudiant>();

            for (int i = 0; i < ListeDesProgrammes.Count; i++)
            {
                if (ListeDesEtudiants[i] is Etudiant etudiant)
                {
                    etudiants.Add(etudiant);
                }
            }

            return etudiants;
        }

        // Methode qui valide l'entree de l'utilisateur pour ajouter un etudiant
        public static bool ValiderEntreeEtudiant(Etudiant etudiant)
        {
            bool validationNomEtudiant;
            bool validationPrenomEtudiant;
            bool validationCourriel;
            bool validationDateNaissance;

            // Le nom doit seulement etre compose de lettres
            validationNomEtudiant = System.Text.RegularExpressions.Regex.IsMatch(etudiant.NomEtudiant, @"^[a-zA-Z\s]+$");

            // Le prenom doit seulement etre compose de lettres
            validationPrenomEtudiant = System.Text.RegularExpressions.Regex.IsMatch(etudiant.PrenomEtudiant, @"^[a-zA-Z\s]+$");

            // Le courriel doit contenir un '@' et un '.'
            validationCourriel = System.Text.RegularExpressions.Regex.IsMatch(etudiant.Courriel, @"^[\w\.-]+@[\w\.-]+\.\w+$");

            // Valider la date de naissance de l'étudiant
            validationDateNaissance = ValiderDateNaissance(etudiant.DateNaissance); 

            return (validationNomEtudiant && validationPrenomEtudiant && validationCourriel && validationDateNaissance);
        }

        // Methode qui permet de faire la verification de l'age
        public static bool ValiderDateNaissance(DateTime dateNaissance)
        {
            DateTime anneeActuelle = DateTime.Today;

            // Calculer l'âge en se basant uniquement sur les années.
            int age = anneeActuelle.Year - dateNaissance.Year;

            // Dans le cas ou la date de naissance n'est pas encore passee l'annee actuelle, soustraire de 1 l'age.
            if (dateNaissance.Date > anneeActuelle.AddYears(-age))
            {
                age--;
            }

            return (age >= 16 && age <= 75);
        }

        // Méthode pour vérifier l'existence d'un étudiant
        public static bool EtudiantExiste(string codeEtudiant)
        {
            for (int i = 0; i < ListeDesEtudiants.Count; i++)
            {
                if (((Etudiant)ListeDesEtudiants[i]).CodeEtudiant == codeEtudiant)
                {
                    return true;
                }
            }
            return false;
        }




    }
}
