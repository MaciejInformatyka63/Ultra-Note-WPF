using System;
using System.Diagnostics.CodeAnalysis;

namespace Modele
{
    public class Utilisateur : IEquatable<Utilisateur>
    {
        # region Propriétés

        /// <summary>
        /// Propriété qui représente le nom de l'utilisateur
        /// </summary>
        public string Nom {get; private set;}
        /// <summary>
        /// Propriété qui représente la profession de l'utilisateur
        /// </summary>
        public string Profession { get; private set; }
        /// <summary>
        /// Propriété qui représente l'adresse mail de l'utilisateur
        /// </summary>
        public string Email { get; private set; }
        /// <summary>
        /// Propriété qui représente la description de l'utilisateur
        /// </summary>
        public string Description { get; private set; }
        /// <summary>
        /// Propriété qui représente le nombre de Notes appartenant à cette utilisateur
        /// </summary>
        public int NombreDeNotes { get; private set; }

        #endregion

        #region Constructeurs

        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="profession"></param>
        /// <param name="email"></param>
        /// <param name="description"></param>
        /// <param name="nombreDeNotes"></param>
        public Utilisateur(string nom, string profession, string email, string description, int nombreDeNotes)
        {
            Nom = nom;
            Profession = profession;
            Email = email; // on peut éventuellement vérifier l'email avec des regex;
            Description = description;
            NombreDeNotes = nombreDeNotes;
        }
        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        /// <param name="nom"></param>
        public Utilisateur(string nom) : this(nom, null, null, null,0) { }

        #endregion

        #region Méthodes redéfinies

        /// <summary>
        /// Redéfinition du protocole d'égalité
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null)) return false;
            if (ReferenceEquals(obj, this)) return true;
            if (GetType() != obj.GetType()) return false;
            if (GetType() != obj.GetType()) return false;
            return Equals(obj as Utilisateur);
        }
        /// <summary>
        /// Redéfinition du protocole de comparaison entre deux utilisateurs
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals([AllowNull] Utilisateur other)
        {
            return Nom.Equals(other.Nom); //ajouter email?
        }
        /// <summary>
        /// Redéfinition du protocole de comparaison
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return Nom.GetHashCode();
        }
        /// <summary>
        /// Redéfinition de l'affichage par défaut
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Utilisateur {Nom}, {Profession}";
        }

        #endregion
    }
}