using System;
using System.Collections.Generic;
using System.Text;

namespace Modele
{
    class Dossier : Gestionnaire
    {
        List<string> listeChemin = new List<string>();
        List<Note> listeDeFichiers = new List<Note>();
        private string note;
        public string Chemin { get; private set; }

        public void AjouterUnFichier(string path)
        {
            listeChemin.Add(path);
        }
        public void SupprimerUnFichier(string path)
        {
            // ...
        }

        /** Re-définition de la méthode Equals qui permet de comparer deux objects */
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
