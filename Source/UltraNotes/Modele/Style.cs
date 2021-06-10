using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace Modele
{
    public class Style : INotifyPropertyChanged
    {
        #region Champs privés

        private string p_Nom;

        #endregion

        #region Propriétés

        /// <summary>
        /// Propriété qui est chargée d'envoyer des notifications à la vue pour notifier le changement d'une propriété
        /// </summary>
        void OnPropertyChanged(string nomPropriete) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nomPropriete));

        public string Nom
        {
            get
            {
                return p_Nom;
            }
            set
            {
                p_Nom = value;
                OnPropertyChanged(Nom);
            }
        }
        public double TailleDePolice { get; set; } = 14D;
        public string PoliceEcriture { get; set; } = "Consolas";
        public Alignement AlignementTexte { get; set; } = Alignement.Gauche;
        public string CouleurTexte { get; set; } = "Black";
        public Boolean IsGras { get; set; } = false;
        public Boolean IsItalique { get; set; } = false;
        public Boolean IsSouligne { get; set; } = false;

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

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

        public Style(string nom, bool isGras, bool isItalique, bool isSouligne) : this(nom)
        {
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
