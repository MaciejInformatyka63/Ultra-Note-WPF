using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace Modele
{
    public class Bouquin : IEnumerable
    {

        #region Persistance

        public IPersistanceBouquin Persistance { get; set; }
        /// <summary>
        /// Méthode qui charge une liste de Notes depuis plusieurs fichiers vers un Bouquin
        /// </summary>
        /// <returns></returns>
        public void ChargeDonnees()
        {
            var données = Persistance.ChargeDonnees();
            foreach(var n in données)
            {
                this.AjouterUneNote(n);
            }
        }
        /// <summary>
        /// Méthode qui sauvegarde une seule note
        /// </summary>
        /// <param name="note"></param>
        public void SauvegardeNote(Note note)
        {
            Persistance.SauvegardeNote(note);
        }
        /// <summary>
        /// Méthode qui sauvegarde chaque objet Note d'une liste dans un fichier différent
        /// </summary>
        /// <param name="chemin"></param>
        public void SauvegardeDonnees()
        {
            Persistance.SauvegardeDonnees(BouquinDeNotes);
        }

        #endregion

        #region Propriétés

        /// <summary>
        /// Propriété sur une collection de notes en lecture seule
        /// </summary>
        public ObservableCollection<Note> BouquinDeNotes { get; } = new ObservableCollection<Note>();
        /// <summary>
        /// Propriété calculée qui rends le nombre d'élements de la collection bouquinDeNotes
        /// </summary>
        public int NombreDeNotes => BouquinDeNotes.Count;

        #endregion

        #region Constructeurs

        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        public Bouquin(IPersistanceBouquin persistance)
        {
            Persistance = persistance;
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
                note.Chemin = note.Chemin ?? Parametres.DossierEPF;
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
                if (index < BouquinDeNotes.Count && index >= 0) return BouquinDeNotes[index];
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
