using System;
using System.Collections.Generic;

namespace Modele
{
    public class Note : Textable
    {
        // Déclaration des attributs de la classe;
        List<Style> stylesUtilisateur = new List<Style>();
        List<Commentaire> commentaires = new List<Commentaire>();

        /// <summary>
        /// Propriété Image qui représente une image
        /// </summary>
        public string Image { get; private set; }

        /// <summary>
        /// Propriété Chemin qui représente un chemin vers un fichier
        /// </summary>
        public string Chemin { get; private set; }

        /// <summary>
        /// Propriété LienDuFicchier qui représente le chemin vers le fichier courant
        /// </summary>
        public string LienDuFichier { get; private set; }

        /// <summary>
        /// Constructeurs de note qui prend tous les paramètres
        /// </summary>
        /// <param name="texte">texte qui apparaitra dans la note</param>
        /// <param name="image">??</param>
        /// <param name="chemin">chemin de la note contenue dans un dossier</param>
        public Note(string texte,string image, string chemin): base(texte)
        {
            Image = image;
            Chemin = chemin;
        }
        /// <summary>
        /// Constructeurs de note qui prend seulement le paramètre "texte"
        /// </summary>
        /// <param name="texte"></param>
        public Note(string texte) : this(texte,null,null) { }

        /// <summary>
        /// Redéfinition de la méthode ToString qui permet d'afficher une note
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Texte}";
        }
    }
}
