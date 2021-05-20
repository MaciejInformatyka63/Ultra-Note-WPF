using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Modele
{
    public class Manager
    {
        # region Propriétés

        public Bouquin Bouquin { get; private set; }
        /// <summary>
        /// Propriété calculée qui permet de connaitre le nombre de notes de l'utilisateur
        /// </summary>
        public int NombreDeNotes => Bouquin.NombreDeNotes;

        #endregion

        #region Constructeurs

        /// <summary>
        /// Constructeur de Manager 
        /// </summary>
        public Manager(Bouquin bouquin)
        {
            this.Bouquin = bouquin;
        }

        #endregion

        #region Méthodes

        /// <summary>
        /// Méthode qui ajoute un fichier au bouquin
        /// </summary>
        /// <param name="note"></param>
        /// <returns></returns>
        public bool AjouterUnFichier(Note note)
        {
            // on fais appel au BouquinDeNotes de la classe Bouquin;
            return Bouquin.AjouterUneNote(note);
        }
        /// <summary>
        /// Méthode qui supprime une note
        /// </summary>
        /// <param name="note"></param>
        /// <returns></returns>
        public bool SupprimerUneNote(Note note)
        {
            // on fais appel au BouquinDeNotes de la classe Bouquin;
            return Bouquin.SupprimerUneNote(note);
        }
        /// <summary>
        /// Méthode qui ajoute une liste de notes dans les notes actuelles
        /// </summary>
        /// <param name="notes"></param>
        /// <returns></returns>
        public int AjouterListeDeNotes(Note[] notes)
        {
            // le résultat de l'opération est 0 si tout s'est bien passé, 1 si erreur critique (tout les fichiers ignorés)
            // et 2 si erreur mineure (certains fichiers ignorés);
            return Bouquin.AjouterUneListeDeNotes(notes);
        }

        #endregion
    }
}
