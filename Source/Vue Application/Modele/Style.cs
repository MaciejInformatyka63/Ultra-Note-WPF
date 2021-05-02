using System;
using System.Collections.Generic;
using System.Text;

namespace Modele
{
    public enum Police
    {
        Arial,
        TimesNewRoman
    }
    public enum Alignement
    {
        droite,
        gauche,
        centre
    }
    public class Style
    {
        public int TailleDePolice { get; private set; }
        public Police PoliceEcriture { get; private set; }
        public Alignement Alignement { get; private set; }
        public Boolean IsGras { get; private set; }
        public Boolean IsItalique { get; private set; }
        public Boolean IsSouligne { get; private set; }
        public Style(int tailleDePolice, Police policeEcriture, Alignement alignement, bool isGras, bool isItalique, bool isSouligne)
        {
            TailleDePolice = tailleDePolice;
            PoliceEcriture = policeEcriture;
            Alignement = alignement;
            IsGras = isGras;
            IsItalique = isItalique;
            IsSouligne = isSouligne;
        }
    }
}
