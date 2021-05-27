﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Modele
{
    public class Note : Textable,INotifyPropertyChanged
    {
        #region Champs

        // Déclaration des champs de la classe;
        // ici on choisis IList car le style statique (à gauche du égal) doit toujours être le plus haut;
        IList<Commentaire> commentaires = new List<Commentaire>();
        public Utilisateur utilisateur;
        private string p_Nom;

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Protected Methods

        /// <summary>
        /// Fires the PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The name of the changed property.</param>
        protected void RaisePropertyChangedEvent(string propertyName)
        {
            if (PropertyChanged != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                PropertyChanged(this, e);
            }
        }

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
                RaisePropertyChangedEvent("Nom");
            }
        }
        /// <summary>
        /// Propriété Image qui représente une image
        /// </summary>
        public string Image { get; private set; }
        /// <summary>
        /// Propriété Chemin qui représente un chemin vers un fichier
        /// </summary>
        public string Chemin { get; set; }
        /// <summary>
        /// Propriété LienDuFicchier qui représente le chemin vers le fichier courant
        /// </summary>
        public string LienDuFichier { get; private set; }
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
        public Note(string nom,string texte,string image, string chemin): base(texte)
        {
            Nom = nom;
            Image = image;
            Chemin = chemin;
        }
        /// <summary>
        /// Constructeur de note qui prend seulement le paramètre "texte"
        /// </summary>
        /// <param name="texte"></param>
        public Note(string nom,string texte) : this(nom,texte,null,Bouquin.DossierEPF) { }

        #endregion

        #region Méthodes

        /// <summary>
        /// Méthode qui permet de renommer un fichier
        /// </summary>
        /// <param name="nomDuFichier">nom actuel</param>
        /// <param name="nouveauNom">nouveau nom</param>
        public void RenommerUnFichier(string nouveauNom)
        {
            // Etape 1 : on vérifie que le nom du nouveau fichier n'est pas déjà pris.
            // On renomme le fichier si son nom est identique à un autre fichier pour le même dossier.
            // Cela donnera par exemple pour trois fichiers aux noms identiques pour le même dossier:
            //   - C:\\Users\me\Documents\Mon document.rtf
            //   - C:\\Users\me\Documents\Mon document #1.rtf   --> ici le #1 est ajouté au nom du fichier car le nom existe déjà
            //   - C:\\Users\me\Documents\Mon document #2.rtf   --> pareil ici, on a le nombre 2 (dans #2) car il y a deux fichiers qui ont le même nom
            // Si deux noms de fichiers sont identiques dans un même dossier, alors une fenêtre d'avertissement Windows demandera
            // à l'utilisateur s'il souhaite écraser l'ancien document.
            
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
            return $"{Nom} : {Texte} à l'adresse {Chemin}";
        }
        /// <summary>
        /// Définie le protole d'égalité entre une Note et un objet
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        /*public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Note objAsNote = (Note)obj;
            if (objAsNote == null) return false;
            //if (this.Chemin.Equals(objAsFichier.Chemin)) return false;
            else return Equals(objAsNote);
        }*/

        #endregion
    }
}
