using System;
using Modele;

namespace Data
{
    public interface IChargeur
    {
        /*
         * Méthodes à implémenter dans les classes qui réalisent cette interface
        */
        /// <summary>
        /// Méthode qui charge une liste de Notes et les renvoie dans un Bouquin
        /// </summary>
        /// <returns></returns>
        Bouquin ChargeurBouquin(string chemin);
    }
}
