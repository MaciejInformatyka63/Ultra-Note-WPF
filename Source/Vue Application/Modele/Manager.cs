using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Modele
{
    public class Manager
    {
        /*
         * Constructeurs
        */
        /// <summary>
        /// Constructeur de Manager 
        /// </summary>
        public Manager()
        {
        }

        /*
         * Méthodes
        */
        public bool AjouterUnFichier(string chemin)
        {
            // on fais appel au BouquinDeNotes de la classe Bouquin;
            // on est censés avoir un main(string args) dans l'application ?
            return false;   
        }

        /*
         * Méthodes redéfinies
        */
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
