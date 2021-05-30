using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Modele
{
    public class Note : VueModeleBase
    {
        #region Champs

        // Déclaration des champs de la classe;
        // variable de la propriété Nom;
        private string p_Nom;
        // variable de la propriété DocumentXaml;
        private string p_DocumentXaml;

        #endregion

        #region Propriétés

        /// <summary>
        /// Liste des styles utilisateurs
        /// </summary>
        public IList<Style> StylesUtilisateur { get; } = new List<Style>();
        /// <summary>
        /// Propriété Nom qui représente le nom de la Note (son titre)
        /// </summary>
        public string Nom
        {
            get { return p_Nom; }

            set
            {
                p_Nom = value;
                base.RaisePropertyChangedEvent("Nom");
            }
        }
        /// <summary>
        /// Propriété DocumentXaml qui renseigne le contenu de la note
        /// </summary>
        public string DocumentXaml
        {
            get { return p_DocumentXaml; }

            set
            {
                p_DocumentXaml = value;
                base.RaisePropertyChangedEvent("DocumentXaml");
            }
        }
        /// <summary>
        /// Propriété Chemin qui représente un chemin vers le fichier (ou il est enregistré)
        /// </summary>
        public string Chemin { get; set; }
        /// <summary>
        /// Propriété qui défini le type de la note (équivalent aux hashtag sur les réseaux sociaux)
        /// </summary>
        public TypeDocument Type { get; private set; }
        /// <summary>
        /// Propriété calculée qui permet d'obtenir la taille du fichier courant
        /// </summary>
        public float CalculerTailleFichier { get; }

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
        public Note(string nom,string texte) : this(nom,texte,null,Bouquin.DossierEPF) { }

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
