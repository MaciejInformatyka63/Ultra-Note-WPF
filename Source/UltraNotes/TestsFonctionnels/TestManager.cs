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
            bool reponse = manager.AjouterUneNote(new Note("quatre", "encore un autre nombre"));
            Display(manager);

            // on ajoute un fichier innexistant;
            Console.WriteLine("On ajoute une note nulle:");
            manager.AjouterUneNote(null);
            Display(manager);

            // on vérifie les résultats;
            Console.WriteLine($"Erreur lors de l'éxécution: {!reponse}");

            // on accède à un élément du BouquinDeNotes de Manager;
            Console.WriteLine($"\nLe deuxième élement du bouquin est \"{manager.Bouquin[1]}\"");
            Console.WriteLine($"La note qui à pour titre trois est \"{manager.Bouquin["trois"]}\"");
        }

        public static void TestManipNoteViaManager()
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

            // on crée un style pour une note;
            Console.WriteLine("Création d'un style pour une note via indexeur de type int");
            manager.Bouquin[0].DefinirStyle(new Style(12, Police.Arial, Alignement.Justifie, false, EpaisseurPolice.Normal, false, true));
            Console.WriteLine($"Le nouveau style de un est : {manager.Bouquin[0].StylesUtilisateur[0]}");
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
