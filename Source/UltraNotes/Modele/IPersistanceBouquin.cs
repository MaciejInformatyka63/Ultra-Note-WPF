using System;
using System.Collections.Generic;
using System.Text;

namespace Modele
{
    public interface IPersistanceBouquin
    {
        /// <summary>
        /// Méthode qui charge une liste de Notes depuis plusieurs fichiers vers un Bouquin
        /// </summary>
        /// <returns></returns>
        IEnumerable<Note> ChargeDonnees();
        /// <summary>
        /// Méthode qui sauvegarde une seule note
        /// </summary>
        /// <param name="note"></param>
        void SauvegardeNote(Note note);
        /// <summary>
        /// Méthode qui sauvegarde chaque objet Note d'une liste dans un fichier différent
        /// </summary>
        /// <param name="chemin"></param>
        void SauvegardeDonnees(IEnumerable<Note> notes);

    }
}
