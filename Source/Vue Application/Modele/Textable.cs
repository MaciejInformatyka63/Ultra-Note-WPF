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
        public string Texte { get; set; }

        /*
         * Constructeurs
        */
        public Textable(string texte)
        {
            Texte = texte;
        }
    }
}
