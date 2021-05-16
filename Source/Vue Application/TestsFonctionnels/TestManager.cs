using Data;
using Modele;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestsFonctionnels
{
    class TestManager
    {
        public static void TestAjoutFichier()
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
            bool reponse = manager.AjouterUnFichier(new Note("quatre", "encore un autre nombre"));

            // on vérifie les résultats;
            Console.WriteLine($"Erreur lors de l'éxécution: {reponse}");
            // on affiche les notes;
            Console.WriteLine("Affichage des notes:");
            foreach (var note in bouquin.BouquinDeNotes)
            {
                Console.WriteLine(note);
            }
        }
    }
}
