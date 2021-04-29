using System;
using System.Collections.Generic;
using System.Text;

namespace Modele
{
    class Fichier
    {
        private string note;
        public string Chemin { get; private set; }
        public Fichier(string chemin)
        {
            Chemin = chemin;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Fichier objAsFichier = obj as Fichier;
            if (objAsFichier == null) return false;
            else return Equals(objAsFichier);
        }
        public bool Equals(Fichier other)
        {
            if (other == null) return false;
            return (this.Chemin.Equals(other.Chemin));
        }
    }
}
