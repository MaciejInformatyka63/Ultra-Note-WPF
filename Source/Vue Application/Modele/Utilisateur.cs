using System;
using System.Diagnostics.CodeAnalysis;

namespace Modele
{
    public class Utilisateur : IEquatable<Utilisateur>
    {
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

        public bool Equals([AllowNull] Utilisateur other)
        {
            return Nom.Equals(other.Nom) && Profession.Equals(other.Profession) && Email.Equals(other.Email);
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