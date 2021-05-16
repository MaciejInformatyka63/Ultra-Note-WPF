using Data;
using Modele;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestsFonctionnels
{
    class TestManager
    {
        public static void TestManipManager()
        {
            // on crée un bouquin et un manager;
            Bouquin bouquin = new Bouquin();
            bouquin.AjouterUneListeDeNotes(new Note[]
            {
                new Note("un", "La premier nombre"),
                new Note("deux", "Le second nombre"),
                new Note("trois", "Une ville antique")
            });
            Manager manager = new Manager(bouquin);
            Display(manager);

            // on ajoute une entrée;
            Console.WriteLine("On ajoute une note via Manager:");
            bool reponse = manager.AjouterUnFichier(new Note("quatre", "encore un autre nombre"));
            Display(manager);

            // on ajoute un fichier innexistant;
            Console.WriteLine("On ajoute une note nulle:");
            manager.AjouterUnFichier(null);
            Display(manager);

            // on vérifie les résultats;
            Console.WriteLine($"Erreur lors de l'éxécution: {!reponse}");
        }

        public static void Display(Manager manager)
        {
            // on affiche les notes;
            Console.WriteLine("Le bouquin actuel:");
            foreach (var note in manager.Bouquin)
            {
                Console.WriteLine(note);
            }
            Console.WriteLine();
        }
    }
}
