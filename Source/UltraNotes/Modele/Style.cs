using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Modele
{
    public class Style
    {
        #region Propriétés

        public string Nom { get; set; }
        public double TailleDePolice { get; set; } = 14D;
        public string PoliceEcriture { get; set; } = "Consolas";
        public Alignement AlignementTexte { get; set; } = Alignement.Gauche;
        public string CouleurTexte { get; set; } = "Black";
        public Boolean IsGras { get; set; } = false;
        public Boolean IsItalique { get; set; } = false;
        public Boolean IsSouligne { get; set; } = false;

        #endregion

        #region Constructeurs

        /// <summary>
        /// contructeur de style
        /// </summary>
        /// <param name="nom"></param>
        public Style(string nom)
        {
            Nom = nom;
        }
        /// <summary>
        /// constructeur enrichi de style
        /// </summary>
        /// <param name="tailleDePolice"></param>
        /// <param name="policeEcriture">de type enum Police (à compléter...)</param>
        /// <param name="alignementTexte">de type enum Alignement</param>
        /// <param name="isGras"></param>
        /// <param name="isItalique"></param>
        /// <param name="isSouligne"></param>
        public Style(string nom, double tailleDePolice, string policeEcriture, Alignement alignementTexte, string couleur, bool isGras, bool isItalique, bool isSouligne) : this(nom)
        {
            TailleDePolice = tailleDePolice;
            PoliceEcriture = policeEcriture;
            AlignementTexte = alignementTexte;
            CouleurTexte = couleur;
            IsGras = isGras;
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
            //return $"Style de police {PoliceEcriture} de taille {TailleDePolice} aligné à {AlignementTexte}";
            return $"{Nom}";
        }

        #endregion
    }
}
