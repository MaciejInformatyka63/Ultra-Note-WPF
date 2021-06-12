using System;
using System.Collections.Generic;
using System.Text;

namespace Modele
{
    public interface IPersistanceBouquin
    {
        /// <summary>
        /// Méthode qui charge une liste de Notes et les renvoie dans un Bouquin
        /// </summary>
        /// <returns></returns>
        IEnumerable<Note> ChargeDonnees();
        /// <summary>
        /// méthode qui sauvegarde une liste de Notes dans un fichier
        /// </summary>
        /// <param name="chemin"></param>
        void SauvegardeDonnees(IEnumerable<Note> notes);

    }
}
