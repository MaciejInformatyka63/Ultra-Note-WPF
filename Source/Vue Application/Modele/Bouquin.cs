using System;
using System.Collections.Generic;
using System.Text;

namespace Modele
{
    public class Bouquin
    {
        /*
         * Propriétés
        */
        /// <summary>
        /// Propriété sur une collection de notes en lecture seule
        /// </summary>
        public IList<Note> BouquinDeNotes { get; } = new List<Note>();
        /// <summary>
        /// Propriété calculée qui rends le nombre d'élements de la collection bouquinDeNotes
        /// </summary>
        public int NombreDeNotes => BouquinDeNotes.Count;

        /*
         * Constructeurs
        */
        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        public Bouquin()
        {
        }

        /*
         * Méthodes
        */
        /// <summary>
        /// Méthode qui supprime un fichier dans la liste des notes éditables par l'utilisateur
        /// </summary>
        /// <param name="path"></param>
        public void SupprimerUnFichier(Note note)
        {
            BouquinDeNotes?.Remove(note);
        }
        /// <summary>
        /// Méthode qui ajoute un fichier dans la liste des notes éditables par l'utilisateur
        /// </summary>
        public void AjouterUnFichier(Note note)
        {
            // on vérifie que la note n'existe pas déjà;
            // nous n'avons pas besoin d'un chemin car ce dernier est déjà précisé dans la classe Note;
            if (!BouquinDeNotes.Contains(note))
            {
                BouquinDeNotes.Add(note);
            }
        }

        /*
         * Indexeurs
        */
        /// <summary>
        /// Indexeur sur la collection de notes bouquinDeNotes
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Note this[int index]
        {
            get
            {
                return BouquinDeNotes[index];
            }
        }
    }
}
