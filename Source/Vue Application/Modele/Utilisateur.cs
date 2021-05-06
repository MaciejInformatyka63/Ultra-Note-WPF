using System;
using System.Diagnostics.CodeAnalysis;

namespace Modele
{
    public class Utilisateur : IEquatable<Utilisateur>
    {
        public Utilisateur(string nom, string profession, string email, string description, int nombreDeNotes)
        {
            Nom = nom;
            Profession = profession;
            Email = email;
            Description = description;
            NombreDeNotes = nombreDeNotes;
        }
        public Utilisateur(string nom) : this(nom, null, null, null,0) { }

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
        public bool Equals([AllowNull] Utilisateur other)
        {
            return Nom.Equals(other.Nom); //ajouter email?
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null)) return false;
            if (ReferenceEquals(obj, this)) return true;
            if (GetType() != obj.GetType()) return false;
            if (GetType() != obj.GetType()) return false;
            return Equals(obj as Utilisateur);
        }
        public override int GetHashCode()
        {
            return Nom.GetHashCode();
        }
    }
}