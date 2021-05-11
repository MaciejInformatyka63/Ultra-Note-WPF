using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Modele
{
    public class Note : Textable
    {
        // Déclaration des attributs de la classe;
        public ReadOnlyCollection<Style> listeStyle { get; private set; }
        List<Style> listeStylesUtilisateur = new List<Style>();
        List<Commentaire> commentaires = new List<Commentaire>();

        /// <summary>
        /// Attribut qui renseigne l'utilisateur
        /// </summary>
        public Utilisateur utilisateur;


        /// <summary>
        /// Propriété Nom qui représente le nom de la Note
        /// </summary>
        public string Nom { get; set; }


        /// <summary>
        /// Propriété Image qui représente une image
        /// </summary>
        public string Image { get; private set; }


        /// <summary>
        /// Propriété Chemin qui représente un chemin vers un fichier
        /// </summary>
        public string Chemin { get; private set; }


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
        public float CalculerTailleFichier { get; private set; }


        /// <summary>
        /// Constructeurs de note qui prend tous les paramètres
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

            listeStyle = new ReadOnlyCollection<Style>(listeStylesUtilisateur);
        }


        /// <summary>
        /// Constructeurs de note qui prend seulement le paramètre "texte"
        /// </summary>
        /// <param name="texte"></param>
        public Note(string nom,string texte) : this(nom,texte,null,null) { }
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

            // Etape 2 : enregistrer le nouveau fichier et ces métadonnées dans le nouveau fichier.
            // Etape 3 : supprimer l'ancien fichier.
        }
        public void DefinirStyle(Style style)
        {
            if (!listeStylesUtilisateur.Contains(style))
            {
                listeStylesUtilisateur.Add(style);
            }
        }
        /// <summary>
        /// Redéfinition de la méthode ToString qui permet d'afficher une note
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Nom} : {Texte}";
        }
    }
}
