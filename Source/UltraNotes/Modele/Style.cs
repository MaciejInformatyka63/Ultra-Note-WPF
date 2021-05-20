using System;
using System.Collections.Generic;
using System.Text;

namespace Modele
{
    public class Style
    {
        #region Champs

        // on fais un mapping de l'énumération pour pouvoir avoir des espaces sur les noms de police composés;
        Dictionary<Police, string> mappingPolice = new Dictionary<Police, string> {
            [Police.Arial] = "Arial",
            [Police.TimesNewRoman] = "Times New Roman"
        };

        #endregion

        #region Propriétés

        public int TailleDePolice { get; set; }
        public Police PoliceEcriture { get; set; }
        public Alignement AlignementTexte { get; set; }
        //public Boolean IsGras { get; set; }
        public EpaisseurPolice Epaisseur { get; set; }
        public Boolean IsItalique { get; set; }
        public Boolean IsSouligne { get; set; }

        #endregion

        #region Constructeurs

        /// <summary>
        /// constructeur de style
        /// </summary>
        /// <param name="tailleDePolice"></param>
        /// <param name="policeEcriture">de type enum Police (à compléter...)</param>
        /// <param name="alignementTexte">de type enum Alignement</param>
        /// <param name="isGras"></param>
        /// <param name="isItalique"></param>
        /// <param name="isSouligne"></param>
        public Style(int tailleDePolice, Police policeEcriture, Alignement alignementTexte, bool isGras, EpaisseurPolice epaisseur, bool isItalique, bool isSouligne)
        {
            TailleDePolice = tailleDePolice;
            PoliceEcriture = policeEcriture;
            AlignementTexte = alignementTexte;
            //IsGras = isGras;
            Epaisseur = epaisseur;
            IsItalique = isItalique;
            IsSouligne = isSouligne;
        }

        #endregion

        #region Méthodes redéfinies

        /// <summary>
        /// Redéfinition de la méthode d'affichage par défaut
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Style de police {mappingPolice[PoliceEcriture]} de taille {TailleDePolice} aligné à {AlignementTexte}";
        }

        #endregion
    }
}
