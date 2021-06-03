using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace Modele
{
    public class Bouquin : IEnumerable, INotifyPropertyChanged
    {
        #region Membres INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Champs

        private string p_themeApplication = "#FF64BED8";

        #endregion

        #region Propriétés

        /// <summary>
        /// Propriété qui est chargée d'envoyer des notifications à la vue pour notifier le changement d'une propriété
        /// </summary>
        void OnPropertyChanged(string nomPropriete) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nomPropriete));
        /// <summary>
        /// Propriété sur une collection de notes en lecture seule
        /// </summary>
        public ObservableCollection<Note> BouquinDeNotes { get; } = new ObservableCollection<Note>();
        /// <summary>
        /// Propriété calculée qui rends le nombre d'élements de la collection bouquinDeNotes
        /// </summary>
        public int NombreDeNotes => BouquinDeNotes.Count;
        /// <summary>
        /// Propriété qui définit si le mode contrasté de l'application est activé
        /// </summary>
        public Boolean ModeContraste { get; private set; } = false;
        /// <summary>
        /// Propriété qui précise la couleurs du theme de l'application choisie par l'utilisateur, au format hexadécimal
        /// </summary>
        public string ThemeApplication
        {
            get { return p_themeApplication; }
            set
            {
                p_themeApplication = value;
                OnPropertyChanged("ThemeApplication");
            }
        }
        /// <summary>
        /// Propriété qui précise les couleurs du theme de l'application
        /// </summary>
        public Dictionary<string, string> ThemeApplicationCouleurs { get; set; } = new Dictionary<string, string>()
        {
            {"Défaut", "#FF64BED8" },
            {"Vert", "#59F0A2" },
            {"Orange", "#E6A05A" },
            {"Bleu profond", "#3A9981" },
            {"Bleu nuit", "#428B99" },
            {"Violet", "#845399" },
            {"Violet profond", "#995489" },
            {"Marron", "#995F3D" },
            {"Contraste", "#252C2E" }
        };
        /// <summary>
        /// Propriété qui précise le dossier d'enregistrement par défaut d'une note
        /// </summary>
        public static string DossierEPF { get; private set; } = "Documents";

        #endregion

        #region Constructeurs

        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        public Bouquin()
        {
        }

        #endregion

        #region Méthodes

        /// <summary>
        /// Méthode qui ajoute un fichier dans la liste des notes éditables par l'utilisateur
        /// </summary>
        /// <param name="note"></param>
        /// <returns>true si aucune erreur, false sinon</returns>
        public bool AjouterUneNote(Note note)
        {
            // si la note n'existe pas déjà, nous l'ajoutons;
            if (note != null && !BouquinDeNotes.Contains(note))
            {
                // on vérifie que le chemin n'est pas null;
                note.Chemin = note.Chemin ?? DossierEPF;
                // puis on l'ajoute à la collection;
                BouquinDeNotes.Add(note);
                // puis on indique qu'il n'y a pas eu d'erreurs;
                return true;
            }
            // sinon on retourne false car l'opération ne s'est pas bien passé;
            return false;
        }
        /// <summary>
        /// Méthode qui supprime un fichier dans la liste des notes éditables par l'utilisateur en passant en paramètre la note concernée
        /// </summary>
        /// <param name="note">Une note non nulle</param>
        /// <returns>retourne true si tout s'est bien passé, false sinon</returns>
        public bool SupprimerUneNote(Note note)
        {
            return (bool)(BouquinDeNotes?.Remove(note));
        }
        /// <summary>
        /// Méthode qui ajoute à la collection BouquinDeNotes une liste de notes
        /// </summary>
        /// <param name="notes">Liste de notes</param>
        /// <returns>0 si tout s'est bien passé, 1 si erreur critique (tout les fichiers ignorés) et 2 si erreur mineure (certains fichiers ignorés)</returns>
        public int AjouterUneListeDeNotes(Note[] notes)
        {
            int code_err = 0; // 0 = pas d'erreur;
            bool gravite_err = true; // true = erreur critique; false = erreur mineure;
            bool temoin; // récupère le code retour de AjouterUnFichier();
            // on ajoute les notes une par une;
            foreach (var elm in notes)
            {
                // si une note existe déja, elle sera ignorée;
                temoin = AjouterUneNote(elm);
                // si temoin = true, un fichier à été ignoré;
                if (temoin) code_err = 2; else gravite_err = false;
            }
            // si gravite_err est passé à true, alors cela signifie que toutes les opérations ont été refusées, alors on passe code_err
            // à 1 (erreur critique);
            code_err = gravite_err is true ? 1 : code_err;
            // on retourne le résultat de l'opération (0 si tout s'est bien passé, 1 si erreur critique (tout les fichiers ignorés)
            // et 2 si erreur mineure (certains fichiers ignorés));
            return code_err;
        }
        /// <summary>
        /// Méthode qui rentoune chaque élements de BouquinDeNotes pour l'itération
        /// </summary>
        /// <returns>Retourne un énumérable</returns>
        public IEnumerator GetEnumerator()
        {
            // pour chaque note dans BouquinDeNotes, on la retourne;
            foreach (Note note in BouquinDeNotes)
            {
                yield return note;
            }
        }

        #endregion

        # region Indexeurs

        /// <summary>
        /// Indexeur sur la collection de notes bouquinDeNotes
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Note this[int index]
        {
            get
            {
                // cet indexeur n'est pas obligatoire mais il permet une meilleur lisibilité du code
                if (index < BouquinDeNotes.Count) return BouquinDeNotes[index];
                // si l'index est supérieur au nombre d'éléments de Bouquin, on ne retourne rien;
                else return null;
                
            }
        }
        /// <summary>
        /// Indexeur qui reçoie le titre de la note et renvoie la première occurence de la note dans la collection BouquinDeNotes
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Note this[string titre]
        {
            get
            {
                // si une note à le nom titre, on renvoie cette note..
                foreach (Note note in BouquinDeNotes)
                {
                    if (note.Nom.Equals(titre))
                    {
                        return note;
                    }
                }
                // ..sinon on revoie rien;
                return null;
            }
        }

        #endregion
    }
}
