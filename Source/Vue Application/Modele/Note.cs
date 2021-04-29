using System;
using System.Collections.Generic;

namespace Modele
{
    public class Note
    {
        List<Balise> listeDeBalise = new List<Balise>();
        public string Texte { get; private set; }
        public string Image { get; private set; }

        public Note(string texte,string image)
        {
            Texte = texte;
            Image = image;
        }
    }
}
