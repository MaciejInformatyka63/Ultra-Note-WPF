using System;
using System.Collections.Generic;

namespace Modele
{
    public class Note : Textable
    {
        List<Balise> listeDeBalise = new List<Balise>();
        List<Style> stylesUtilisateur = new List<Style>();
        List<Commentaire> commentaires = new List<Commentaire>();
        public string Image { get; private set; }

        public Note(string texte,string image): base(texte)
        {
            Image = image;
        }
    }
}
