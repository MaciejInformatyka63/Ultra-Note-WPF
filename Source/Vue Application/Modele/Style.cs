using System;
using System.Collections.Generic;
using System.Text;

namespace Modele
{
    public class Style
    {
        public int TailleDePolice { get; private set; }
        public Police PoliceEcriture { get; private set; }
        public Alignement AlignementTexte { get; private set; }
        public Boolean IsGras { get; private set; }
        public Boolean IsItalique { get; private set; }
        public Boolean IsSouligne { get; private set; }

        /// <summary>
        /// constructeur de style
        /// </summary>
        /// <param name="tailleDePolice"></param>
        /// <param name="policeEcriture">de type enum Police (à compléter...)</param>
        /// <param name="alignement">de type enum Alignement</param>
        /// <param name="isGras"></param>
        /// <param name="isItalique"></param>
        /// <param name="isSouligne"></param>
        public Style(int tailleDePolice, Police policeEcriture, Alignement alignement, bool isGras, bool isItalique, bool isSouligne)
        {
            TailleDePolice = tailleDePolice;
            Police = policeEcriture;
            Alignement = alignement;
            IsGras = isGras;
            IsItalique = isItalique;
            IsSouligne = isSouligne;
        }
    }
}
