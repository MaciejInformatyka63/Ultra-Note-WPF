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
            bouquin.AjouterUneNote(new Note("Mon super document", "Un méga super document avec plein de super mots !!"));
            bouquin.AjouterUneNote(new Note("Une aventure pas comme les autres", "Bienvenue dans UltraNotes !"));
            bouquin.AjouterUneNote(new Note("Cours de maths n°1", "Les suites : les suites doivent se suivre, sinon ce ne sont pas des suites. Incroyable !"));
            bouquin.AjouterUneNote(new Note("Cours de maths n°2", "Les arbres pondérés : un abre pondéré n'est pas un chêne"));
            return bouquin;
        }
    }
}
