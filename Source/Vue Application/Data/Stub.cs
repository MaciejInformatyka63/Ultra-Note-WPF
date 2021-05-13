using Modele;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class Stub : IChargeur
    {
        public Bouquin ChargeurBouquin(string chemin)
        {
            Bouquin bouquin = new Bouquin();
            bouquin.AjouterUnFichier(new Note("Mon super document", "Un méga super document avec plein de super mots !!"));
            bouquin.AjouterUnFichier(new Note("Nouveau document", "Bienvenue dans UltraNotes !"));
            bouquin.AjouterUnFichier(new Note("Cours de maths n°1", "Les suites : les suites doivent se suivre, sinon ce ne sont pas des suites. Incroyable !"));
            bouquin.AjouterUnFichier(new Note("Cours de maths n°2", "Les arbres pondérés : un abre pondéré n'est pas un chêne"));
            return bouquin;
        }
    }
}
