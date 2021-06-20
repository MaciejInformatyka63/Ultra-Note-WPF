using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace Modele
{
    [DataContract]
    public class Note : INotifyPropertyChanged
    {
        #region Champs

        // Déclaration des champs de la classe;
        // variable de la propriété Nom;
        private string p_Nom;
        // variable de la propriété DocumentXaml;
        private string p_DocumentXaml;
        [DataMember]
        public DateTime DateCreation { get; set; }
        #endregion

        #region Propriétés

        /// <summary>
        /// Propriété qui est chargée d'envoyer des notifications à la vue pour notifier le changement d'une propriété
        /// </summary>
        void OnPropertyChanged(string nomPropriete) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nomPropriete));
        /// <summary>
        /// Liste des styles utilisateurs
        /// </summary>
        [DataMember]
        public IList<Style> StylesUtilisateur { get; set; } = new List<Style>();
        /// <summary>
        /// Propriété Nom qui représente le nom de la Note (son titre)
        /// </summary>
        [DataMember]
        public string Nom
        {
            get { return p_Nom; }

            set
            {
                p_Nom = value;
                OnPropertyChanged("Nom");
            }
        }
        /// <summary>
        /// Propriété DocumentXaml qui renseigne le contenu de la note
        /// </summary>
        [DataMember]
        public string DocumentXaml
        {
            get { return p_DocumentXaml; }

            set
            {
                p_DocumentXaml = value;
                OnPropertyChanged("DocumentXaml");
            }
        }
        /// <summary>
        /// Retourne le nombre de seconds, minutes, d'heures, de mois, de jours ou d'années qu'un document n'as pas été modifié
        /// </summary>
        /*public int DateDerniereModif
        {
            get
            {
                DateTime dateNow = DateTime.Now;
                if (dateNow.Year != DateCreation.Year) return dateNow.Year - DateCreation.Year + 1;
                else if (dateNow.Month != DateCreation.Month
                    && dateNow.Year == DateCreation.Year) return dateNow.Month - DateCreation.Month + 1;
                else if (dateNow.Day != DateCreation.Day
                    && dateNow.Month == DateCreation.Month
                    && dateNow.Year == DateCreation.Year) return dateNow.Subtract(DateCreation).Days + 1;
                else if (dateNow.Hour != DateCreation.Hour
                    && dateNow.Day == DateCreation.Day
                    && dateNow.Month == DateCreation.Month
                    && dateNow.Year == DateCreation.Year) return dateNow.Subtract(DateCreation).Hours + 1;
                else if (dateNow.Minute != DateCreation.Minute
                    && dateNow.Hour == DateCreation.Hour
                    && dateNow.Day == DateCreation.Day
                    && dateNow.Month == DateCreation.Month
                    && dateNow.Year == DateCreation.Year) return dateNow.Subtract(DateCreation).Minutes + 1;
                return dateNow.Subtract(DateCreation).Seconds;
            }
        }
        /// <summary>
        /// propriété calculée pour formatter sous forme de chaine de caractères la date de dernière modification
        /// </summary>
        public string DateDerniereModifFormat
        {
            get
            {
                DateTime dateNow = DateTime.Now;
                if (dateNow.Year != DateCreation.Year) return $"Modifié il y a {DateDerniereModif} an(s)";
                else if (dateNow.Month != DateCreation.Month
                    && dateNow.Year == DateCreation.Year) return $"Modifié il y a {DateDerniereModif} mois";
                else if (dateNow.Day != DateCreation.Day
                    && dateNow.Month == DateCreation.Month
                    && dateNow.Year == DateCreation.Year) return $"Modifié il y a {DateDerniereModif} jour(s)";
                else if (dateNow.Hour != DateCreation.Hour
                    && dateNow.Day == DateCreation.Day
                    && dateNow.Month == DateCreation.Month
                    && dateNow.Year == DateCreation.Year) return $"Modifié il y a {DateDerniereModif} heure(s)";
                else if (dateNow.Minute != DateCreation.Minute
                    && dateNow.Hour == DateCreation.Hour
                    && dateNow.Day == DateCreation.Day
                    && dateNow.Month == DateCreation.Month
                    && dateNow.Year == DateCreation.Year) return $"Modifié il y a {DateDerniereModif} minute(s)";
                return $"Modifié il y a {DateDerniereModif} seconde(s)";
            }
        }*/
        /// <summary>
        /// Propriété Chemin qui représente un chemin vers le fichier (ou il est enregistré)
        /// </summary>
        public string Chemin { get; set; }
        /// <summary>
        /// Propriété qui défini le type de la note
        /// </summary>
        public TypeDocument Type { get; set; }

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Constructeurs

        /// <summary>
        /// Constructeur de note qui prend tous les paramètres
        /// </summary>
        /// <param name="texte">texte qui apparaitra dans la note</param>
        /// <param name="image">chemin de l'image qui apparaitra dans la note</param>
        /// <param name="chemin">chemin de la note contenue dans un dossier</param>
        /// <param name="nom">nom du fichier</param>
        public Note(string nom,string documentXaml,string image, string chemin)
        {
            Nom = nom;
            DocumentXaml = documentXaml;
            Chemin = chemin;
        }
        /// <summary>
        /// Constructeur de note qui prend seulement le paramètre "texte"
        /// </summary>
        /// <param name="texte"></param>
        public Note(string nom,string texte) : this(nom, texte, null, Path.Combine(Parametres.DossierEPF, nom)) { }

        #endregion

        #region Méthodes publiques

        /// <summary>
        /// Méthode qui permet de renommer un fichier
        /// </summary>
        /// <param name="nomDuFichier">nom actuel</param>
        /// <param name="nouveauNom">nouveau nom</param>
        public void Renommer(string nouveauNom)
        {
            // on renomme la note;
            if (Nom==nouveauNom)
            {
                Nom = Chemin;
            }
            Nom = nouveauNom;
        }
        /// <summary>
        /// Ajout d'un style utilisateur dans ListeStyles
        /// </summary>
        /// <param name="style"></param>
        public void DefinirStyle(Style style)
        {
            if (!StylesUtilisateur.Contains(style))
            {
                StylesUtilisateur.Add(style);
            }
        }

        #endregion

        #region Méthodes redéfinies

        /// <summary>
        /// Redéfinition de la méthode ToString qui permet d'afficher une note
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Nom} : {DocumentXaml} à l'adresse {Chemin}";
        }

        #endregion
    }
}
