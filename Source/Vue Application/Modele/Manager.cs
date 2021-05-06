using System;
using System.Collections.Generic;
using System.Text;

namespace Modele
{
    class Manager
    {
        // Liste des attributs de la classe;
        List<string> listeCheminVersFichier = new List<string>();
        Dictionary<Utilisateur, Note> listeDeFichiers = new Dictionary<Utilisateur, Note>();
        private string dossierEPF;
        private string note;
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="listeChemin">??</param>
        /// <param name="listeDeFichiers">liste de notes contenu dans le dossier</param>
        /// <param name="note">??</param>
        /// <param name="dossierEPF">chemin du dossier</param>
        public Manager(List<string> listeChemin, List<Note> listeDeFichiers, string note)
        {
            this.listeCheminVersFichier = listeChemin;
            // this.listeDeFichiers = listeDeFichiers;
            this.note = note;
        }

        /// <summary>
        /// Méthode qui ajoute un fichier dans la liste des notes éditables par l'utilisateur
        /// </summary>
        /// <param name="path"></param>
        public void AjouterUnFichier(string path)
        {
            listeCheminVersFichier.Add(path);
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
