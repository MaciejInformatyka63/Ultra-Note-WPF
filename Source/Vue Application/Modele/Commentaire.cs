using System;
using System.Collections.Generic;
using System.Text;

namespace Modele
{
    public class Commentaire : Textable
    {
        public Commentaire(string texte) : base(texte)
        {
        }
        public override string ToString()
        {
            return $"{Texte}";
        }
    }
}
