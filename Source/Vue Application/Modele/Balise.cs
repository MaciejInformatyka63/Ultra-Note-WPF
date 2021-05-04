using System;
using System.Collections.Generic;
using System.Text;

namespace Modele
{
    /// <summary>
    /// représente une balise
    /// </summary>
    class Balise : Textable
    {
        public string Position { get; private set; }
        public string Image { get; private set; }
        public string PDF { get; private set; }
        public string Web { get; private set; }
        /// <summary>
        /// constructeur
        /// </summary>
        /// <param name="texte">texte de la balise</param>
        /// <param name="position">??</param>
        /// <param name="image">chemin de l'image contenu dans la balise</param>
        /// <param name="pDF">lien hypertexte vers un document en format PDF</param>
        /// <param name="web">lien hypertexte vers une page web</param>
        public Balise(string texte, string position, string image, string pDF, string web) : base(texte)
        {
            Position = position;
            Image = image;
            PDF = pDF;
            Web = web;
        }

    }
}
