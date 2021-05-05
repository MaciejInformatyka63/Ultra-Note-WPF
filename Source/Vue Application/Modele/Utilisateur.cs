namespace Modele
{
    public class Utilisateur
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
    }
}