using Data;
using Modele;
using System;

namespace TestsFonctionnels
{
    class Program
    {
        static void Main(string[] args)
        {
            // on déclare un chargeur puis un bouquin comme ça on peut juste remplacer Stub() par le chageur qu'on veut tester (quand on aura notre persistance)
            IChargeur chargeur = new Stub();
            Bouquin bouquin = chargeur.ChargeurBouquin("");
            AfficherBouquin(bouquin);
        }

        private static void AfficherBouquin(Bouquin bouquin)
        {
            Console.WriteLine("Liste des notes dans le bouquin :");
            foreach (Note note in bouquin.BouquinDeNotes)
            {
                Console.WriteLine(note);
            }
        }
    }
}
