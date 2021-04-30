using System;
using System.Collections.Generic;
using System.Text;

namespace Modele
{
    class Balise : Textable
    {
        public string Position { get; private set; }
        public string Image { get; private set; }
        public string PDF { get; private set; }
        public string Web { get; private set; }
        public Balise(string texte, string position, string image, string pDF, string web) : base(texte)
        {
            Position = position;
            Image = image;
            PDF = pDF;
            Web = web;
        }

    }
}
