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
        public string Chemin { get; private set; }
        /// <summary>
        /// 2 constructeurs de note : 1.prend tous les paramètres 2.prend seulement le paramètre "texte"
        /// </summary>
        /// <param name="texte">texte qui apparaitra dans la note</param>
        /// <param name="image">??</param>
        /// <param name="chemin">chemin de la note contenue dans un dossier</param>
        public Note(string texte,string image, string chemin): base(texte)
        {
            Image = image;
            Chemin = chemin;
        }
        public Note(string texte) : this(texte,null,null) { }
        public override string ToString()
        {
            return $"{Texte}";
        }
    }
}
