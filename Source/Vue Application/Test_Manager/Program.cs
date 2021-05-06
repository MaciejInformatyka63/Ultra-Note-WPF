using System;
using System.Collections.Generic;
using Modele;

namespace Test_Manager
{
    class Program
    {
        static void Display(Dictionary<Utilisateur,Note> dico)
        {
            foreach (KeyValuePair<Utilisateur,Note> kvp in dico)
            {
                Console.WriteLine($"{kvp.Key.Nom} => {kvp.Value.Nom}");
            }
            Console.WriteLine("----- ----- -----");
        }
        static void Main(string[] args)
        {
            Manager manager = new Manager();

            Note carré = new Note("carré","Un carré est un rectangle particulier");
            Note rectangle = new Note("rectangle","Un rectangle est un polygone à 4 côtés");
            Note cercle = new Note("cercle","Un cercle est une courbe plane fermée");

            Utilisateur Euclide = new Utilisateur("Euclide");
            Utilisateur Euler = new Utilisateur("Euler");
            Utilisateur Pascal = new Utilisateur("Pascal");

            Dictionary<Utilisateur, Note> dico = new Dictionary<Utilisateur, Note>
            {
                [Euclide] = carré,
                [Euler] = rectangle,
                [Pascal] = cercle,
            };

            Display(dico);

            manager.RenommerUnFichier("carré", "cercle");

            Display(dico);
        }
    }
}
