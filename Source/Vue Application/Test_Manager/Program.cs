using System;
using System.Collections.Generic;
using Modele;

namespace Test_Manager
{
    class Program
    {
        static void Display(Dictionary<Note,Utilisateur> dico)
        {
            foreach (KeyValuePair<Note,Utilisateur> kvp in dico)
            {
                Console.WriteLine($"{kvp.Key} => {kvp.Value}");
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

            Dictionary<Note, Utilisateur> dico = new Dictionary<Note, Utilisateur>
            {
                [carré] = Euclide,
                [rectangle] = Euler,
                [cercle] = Pascal,
            };

            Display(dico);

            Console.WriteLine("On renomme carré en bouah");
            Display(dico);
        }
    }
}
