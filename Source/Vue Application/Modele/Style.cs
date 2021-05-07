using System;
using System.Collections.Generic;
using System.Text;

namespace Modele
{
    public class Style
    {
        Dictionary<Police, string> mappingPolice = new Dictionary<Police, string> {
            [Police.Arial] = "Arial",
            [Police.TimesNewRoman] = "Times New Roman"
        };

        public int TailleDePolice { get;  private set; }
        public string PoliceEcriture { get; private set; }
        public Alignement AlignementTexte { get; private set; }
        public Boolean IsGras { get; private set; }
        public Boolean IsItalique { get; private set; }
        public Boolean IsSouligne { get; private set; }

        /// <summary>
        /// constructeur de style
        /// </summary>
        /// <param name="tailleDePolice"></param>
        /// <param name="policeEcriture">de type enum Police (à compléter...)</param>
        /// <param name="alignementTexte">de type enum Alignement</param>
        /// <param name="isGras"></param>
        /// <param name="isItalique"></param>
        /// <param name="isSouligne"></param>
        public Style(int tailleDePolice, Police policeEcriture, Alignement alignementTexte, bool isGras, bool isItalique, bool isSouligne)
        {
            TailleDePolice = tailleDePolice;
            mappingPolice[policeEcriture] = PoliceEcriture;
            AlignementTexte = alignementTexte;
            IsGras = isGras;
            IsItalique = isItalique;
            IsSouligne = isSouligne;
        }


        /// <summary>
        /// Redéfinition de la méthode d'affichage par défaut
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Style de police {PoliceEcriture} de taille {TailleDePolice} aligné à {AlignementTexte}";
        }
    }
}
