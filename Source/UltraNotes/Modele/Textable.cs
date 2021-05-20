using System;
using System.Collections.Generic;
using System.Text;

namespace Modele
{
    public abstract class Textable
    {
        # region Propriétés

        public string Texte { get; set; }

        #endregion

        #region Constructeurs

        public Textable(string texte)
        {
            Texte = texte;
        }

        #endregion
    }
}
