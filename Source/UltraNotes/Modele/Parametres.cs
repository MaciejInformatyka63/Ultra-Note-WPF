using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;
using System.Text;

namespace Modele
{
    [DataContract]
    public class Parametres : INotifyPropertyChanged
    {
        #region Persistance

        public IPersistanceBouquin Persistance { get; set; }
        public void ChargerParametres()
        {
            var donnees = Persistance.ChargerParametres();
            this.p_themeApplication = donnees.p_themeApplication;
            this.p_imageMainWindow = donnees.p_imageMainWindow;
        }
        public void SauverParametres()
        {
            Persistance.SauverParametres(this);
        }

        #endregion

        #region Champs

        private string p_themeApplication = "#64BED8";
        private string p_imageMainWindow = "../Assets/mountains.jpg";

        #endregion

        #region Membres INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Constructeurs

        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        public Parametres(IPersistanceBouquin persistance)
        {
            Persistance = persistance;
        }
        /// <summary>
        /// Constructeur de la classe sans parametres
        /// </summary>
        public Parametres() { }

        #endregion

        #region Propriétés

        /// <summary>
        /// Propriété qui est chargée d'envoyer des notifications à la vue pour notifier le changement d'une propriété
        /// </summary>
        void OnPropertyChanged(string nomPropriete) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nomPropriete));
        /// <summary>
        /// Propriété qui précise la couleurs du theme de l'application choisie par l'utilisateur, au format hexadécimal
        /// </summary>
        [DataMember]
        public string ThemeApplication
        {
            get { return p_themeApplication; }
            set
            {
                p_themeApplication = value;
                OnPropertyChanged("ThemeApplication");
            }
        }
        /// <summary>
        /// Propriété qui précise l'image de la page principale
        /// </summary>
        [DataMember]
        public string ImageMainWindow
        {
            get { return p_imageMainWindow; }
            set
            {
                p_imageMainWindow = value;
                OnPropertyChanged("ImageMainWindow");
            }
        }
        /// <summary>
        /// Propriété qui précise les couleurs du theme de l'application
        /// </summary>
        public Dictionary<string, string> ThemeApplicationCouleurs { get; set; } = new Dictionary<string, string>()
        {
            {"Défaut", "#64BED8" },
            {"Vert", "#59F0A2" },
            {"Orange", "#E6A05A" },
            {"Bleu profond", "#3A9981" },
            {"Bleu nuit", "#428B99" },
            {"Violet", "#845399" },
            {"Violet profond", "#995489" },
            {"Marron", "#995F3D" },
            {"Rouge", "#e30053" },
            {"Contraste", "#252C2E" }
        };
        /// <summary>
        /// Propriété qui précise les images de la page principale
        /// </summary>
        public Dictionary<string, string> BanqueImagesMainWindow { get; set; } = new Dictionary<string, string>()
        {
            {"Défaut", "../Assets/mountains.jpg" },
            {"Vert", "../Assets/mountainsGreen.jpg" },
            {"Orange", "../Assets/mountainsOrange.jpg" },
            {"Bleu profond", "../Assets/mountainsDeepBlue.jpg" },
            {"Bleu nuit", "../Assets/mountainsNightBlue.jpg" },
            {"Violet", "../Assets/mountainsPurple.jpg" },
            {"Violet profond", "../Assets/mountainsDeepPurple.jpg" },
            {"Marron", "../Assets/mountainsBrown.jpg" },
            {"Contraste", "../Assets/mountainsContrast.jpg" },
            {"Rouge", "" }
        };
        /// <summary>
        /// Propriété qui précise le dossier d'enregistrement par défaut d'une note
        /// </summary>
        public static string DossierEPF { get; private set; } = Path.Combine(Directory.GetCurrentDirectory(), "..//XML");
    }

    #endregion
}
