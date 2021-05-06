using System;
using System.Collections.Generic;
using System.Text;

namespace Modele
{
    public class Manager
    {
        // Liste des attributs de la classe;
        List<string> listeCheminVersFichier = new List<string>();
        Dictionary<Utilisateur, Note> listeDeFichiers = new Dictionary<Utilisateur, Note>();
        private string dossierEPF;
        // string formatChemin = @"{0}\{1}{2}.rtf";

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="listeChemin">??</param>
        /// <param name="listeDeFichiers">liste de notes contenu dans le dossier</param>
        /// <param name="note">??</param>
        public Manager(List<string> listeChemin, List<Note> listeDeFichiers, string note)
        {
            this.listeCheminVersFichier = listeChemin;
        }
        public Manager() { }
        /// <summary>
        /// Propriété qui représente le chemin vers le dossier d'enregistrement par défaut des notes
        /// </summary>
        public string DossierEPF { get; private set; }


        /// <summary>
        /// Méthode qui ajoute un fichier dans la liste des notes éditables par l'utilisateur
        /// </summary>
        public void AjouterUnFichier()
        {
            // on construit le nom du nouveau fichier;
            // string nouveauFichier = dossierEPF + @"\Nouveau Document #" + listeCheminVersFichier.Count + ".rtf";
            // string nouveauFichier = string.Format(formatChemin, DossierEPF, "Nouveau Document #", listeCheminVersFichier.Count);
            string nouveauFichier = $"{dossierEPF}\\Nouveau Document #{listeCheminVersFichier.Count}.rtf";
            // puis on génère les métadonnées;
            DateTime creationDocument = DateTime.Now;
            TimeSpan tempsPasseSurLeDocument = TimeSpan.FromMinutes(0);

            // on ajoute le chemin du nouveau fichier dans la liste des notes;
            listeCheminVersFichier.Add(nouveauFichier);

            // enfin on enregistre le document dans nouveauFichier..
            // ...
            // et ces métadonnées dans dossierEPF\.meta\Nouveau Document #x.txt;
            // ...

        }


        /// <summary>
        /// Méthode qui supprime un fichier dans la liste des notes éditables par l'utilisateur
        /// </summary>
        /// <param name="path"></param>
        public void SupprimerUnFichier(string path)
        {
            // ...
        }
        /// <summary>
        /// on vérifie que le nouveau nom de fichier n'est pas déjà pris, sinon on
        /// ajoute un nombre sous la forme #x après le nom du document, avec x le
        /// nombre de fichiers portant le même nom actuellement;
        /// </summary>
        /// <param name="nomDuFichier">nom actuel</param>
        /// <param name="nouveauNom">nouveau nom</param>
        public void RenommerUnFichier(string nomDuFichier, string nouveauNom)
        {
            int count = 2;
            foreach (KeyValuePair<Utilisateur,Note> kvp in listeDeFichiers)
            {
                if (kvp.Value.Nom == nouveauNom || kvp.Value.Nom == nouveauNom + $"#{(count==2 ? 2 : count--)}")
                {
                    nouveauNom = nouveauNom + $"#{count}";
                    count++;
                }
            }
            foreach (KeyValuePair<Utilisateur,Note> kvp in listeDeFichiers)
            {

                if (kvp.Value.Nom == nomDuFichier)
                {
                    kvp.Value.Nom = nouveauNom;
                }
            }
        }


        /// <summary>
        /// Méthodes qui permet d'afficher les notes d'un utlisateur particulier
        /// </summary>
        /// <param name="utilisateur"></param>
        public void AfficherNotesTriees(Utilisateur utilisateur)
        {
            //...
        }

        /// <summary>
        /// Re-définition de la méthode Equals qui permet de comparer deux objects
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Note objAsFichier = obj as Note;
            if (objAsFichier == null) return false;
            else return this.Equals(objAsFichier);
            //else return this.Chemin.Equals(objAsFichier.Chemin);
        }
    }
}
