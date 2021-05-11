﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Modele
{
    public class Manager
    {
        // Liste des attributs de la classe;
        List<string> listeCheminVersFichier = new List<string>();
        public ReadOnlyDictionary<Note,Utilisateur> Notes { get; private set; }
        Dictionary<Note, Utilisateur> dictionnaireDeNotes = new Dictionary<Note, Utilisateur>();
        Dictionary<string, string> notesUtilisateur = new Dictionary<string, string>();
        // string formatChemin = @"{0}\{1}{2}.rtf";
        /// <summary>
        /// Constructeur de Manager + encapsulation du dictionnaireDeNotes dans Notes (dictionnaire en "read only") 
        /// </summary>
        /// <param name="listeChemin">liste des chemins des fichiers gérés par ce manager</param>
        public Manager(List<string> listeChemin)
        {
            this.listeCheminVersFichier = listeChemin;
            Notes = new ReadOnlyDictionary<Note, Utilisateur>(dictionnaireDeNotes);
        }


        /// <summary>
        /// Constructeur vide
        /// </summary>
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
            // string nouveauFichier = $"{dossierEPF}\\Nouveau Document #{listeCheminVersFichier.Count}.rtf";

            // puis on génère les métadonnées;
            DateTime creationDocument = DateTime.Now;
            TimeSpan tempsPasseSurLeDocument = TimeSpan.FromMinutes(0);

            // on ajoute le chemin du nouveau fichier dans la liste des notes;
            // listeCheminVersFichier.Add(nouveauFichier);
            notesUtilisateur[$"Nouveau Document #{notesUtilisateur.Count}"] = Parametres.DossierEPF;

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


        private void appliquerLesModifications()
        {
            // persistance;
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
            // else return this.Chemin.Equals(objAsFichier.Chemin);
        }
    }
}
