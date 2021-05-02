using System;
using System.Collections.Generic;
using System.Text;

namespace Modele
{
    public abstract class Textable
    {
        public string Texte { get; private set; }
        public Textable(string texte)
        {
            Texte = texte;
        }
    }
}
