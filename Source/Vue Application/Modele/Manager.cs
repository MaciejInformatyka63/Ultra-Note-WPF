using System;
using System.Collections.Generic;
using System.Text;

namespace Modele
{
    public class Manager
    {
        // Liste des attributs de la classe;
        List<string> listeCheminVersFichier = new List<string>();
        Dictionary<Note, Utilisateur> dictionnaireDeNotes = new Dictionary<Note, Utilisateur>();
        Dictionary<string, string> notesUtilisateur = new Dictionary<string, string>();
        // string formatChemin = @"{0}\{1}{2}.rtf";
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="listeChemin">liste des chemins des fichiers gérés par ce manager</param>
        public Manager(List<string> listeChemin)
        {
            this.listeCheminVersFichier = listeChemin;
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
        /// <summary>
        /// on vérifie que le nouveau nom de fichier n'est pas déjà pris, sinon on
        /// ajoute un nombre sous la forme #x après le nom du document, avec x le
        /// nombre de fichiers portant le même nom actuellement;
        /// </summary>
        /// <param name="nomDuFichier">nom actuel</param>
        /// <param name="nouveauNom">nouveau nom</param>
        public void RenommerUnFichier(string nomDuFichier, string nouveauNom)
        {
            // On renomme le fichier si son nom est identique à un autre fichier pour le même utilisateur.
            // Cela donnera par exemple pour trois fichiers aux noms identiques pour le même utilisateur:
            //   - C:\\Users\me\Documents\Mon document #0.rtf
            //   - C:\\Users\me\Documents\Mon document #1.rtf
            //   - C:\\Users\me\Documents\Mon document #2.rtf
            // Si deux noms de fichiers sont identiques dans un même dossier, alors une fenêtre d'avertissement Windows demandera
            // à l'utilisateur s'il souhaite écraser l'ancien document.
            foreach (KeyValuePair<Note, Utilisateur> note in dictionnaireDeNotes)
            {
                if (note.Key.Nom.Equals(nouveauNom))
                {
                    nomDuFichier = $"{nouveauNom} #{dictionnaireDeNotes.Count}";
                    return;
                }
            }

            // sinon on renomme tout simplement le fichier;
            foreach (KeyValuePair<Note, Utilisateur> note in dictionnaireDeNotes)
            {
                if (note.Key.Nom.Equals(nomDuFichier))
                {
                    nomDuFichier = $"{nouveauNom}";
                    return;
                }
            }
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
            //else return this.Chemin.Equals(objAsFichier.Chemin);
        }
    }
}
