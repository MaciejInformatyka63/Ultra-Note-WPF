using Data;
using Modele;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestsFonctionnels
{
    class TestBouquin
    {
        public static void TestManipBouquin()
        {
            // on déclare un chargeur puis un bouquin comme ça on peut juste remplacer Stub() par le chargeur qu'on veut tester (quand on aura notre persistance)
            IPersistanceBouquin chargeur = new Stub();
            Bouquin bouquin = new Bouquin(chargeur);
            bouquin.ChargeDonnees();
            AfficherBouquin(bouquin);

            // on affiche la note qui à l'indice 2;
            AfficherLaNote(bouquin, 2);

            // on ajoute une note dans le bouquin;
            Console.WriteLine("On ajoute la note dont le nom est \"Le petit asticot de Jean Blonblon...\"");
            bouquin.AjouterUneNote(new Note("Le petit asticot de Jean Blonblon", "Un voyage extraordinaire chez les inuites !"));
            AfficherBouquin(bouquin);

            // on supprime une note dans le bouquin;
            Console.WriteLine("On supprime la note dont le nom est \"Cours de math n°1\"");
            bouquin.SupprimerUneNote(bouquin["Cours de maths n°3"]); // on essaye de supprimer une note qui n'existe pas...
            bouquin.SupprimerUneNote(bouquin["Cours de maths n°1"]); // on supprime une note qui existe...
            AfficherBouquin(bouquin);
        }

        private static void AfficherBouquin(Bouquin bouquin)
        {
            Console.WriteLine("Liste des notes dans le bouquin :");
            foreach (Note note in bouquin.BouquinDeNotes)
            {
                Console.WriteLine($" - {note}");
            }
            Console.WriteLine($"Nombre de notes retournées: {bouquin.NombreDeNotes}");
            Console.WriteLine();
        }

        private static void AfficherLaNote(Bouquin bouquin, int index)
        {
            Console.WriteLine($"Affichage de la note n°{index} :");
            Console.WriteLine(bouquin[index]);
            Console.WriteLine();
        }
    }
}
