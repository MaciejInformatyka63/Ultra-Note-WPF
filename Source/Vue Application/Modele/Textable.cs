using System;
using System.Collections.Generic;
using System.Text;

namespace Modele
{
    public abstract class Textable
    {
        /*
         * Propriétés
        */
        public string Texte { get; private set; }

        /*
         * Constructeurs
        */
        public Textable(string texte)
        {
            Texte = texte;
        }
    }
}
