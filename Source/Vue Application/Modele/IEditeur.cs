using System;
using System.Collections.Generic;
using System.Text;

namespace Modele
{
    interface IEditeur
    {
        /// <summary>
        /// Méthode qui se charge d'afficher les notes triées dans l'ordre alphabétique
        /// </summary>
        /// <param name="notes"></param>
        public void AfficherNotesTriees()
        {
            // ...
        }

        /// <summary>
        /// Méthode qui se charge d'afficher les notes triées dans l'ordre chronologique (du plus récent au plus ancien)
        /// </summary>
        /// <param name="notes"></param>
        public void AfficherNotesTriees(Note notes)
        {
            // ...
        }

        /// <summary>
        /// Méthodes qui permet d'afficher les notes d'un utlisateur particulier
        /// </summary>
        /// <param name="utilisateur"></param>
        public void AfficherNotesTriees(Utilisateur utilisateur)
        {
            // ...
        }
    }
}
