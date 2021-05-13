using Data;
using Modele;
using System;
using System.Collections.Generic;
using System.Data;

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

        /*
        public static void TestEnumeration()
        {
            // on fais un mapping des données de l'enumération;
            // ça permet de pouvoir ajouter des espaces à Pour_plus_tard en l'associant à une chaine de caractère
            // identique;
            Dictionary<TypeDocument, string> mapping = new Dictionary<TypeDocument, string>
            {
                [TypeDocument.Personnel] = "Personnel",
                [TypeDocument.Profesionnel] = "Professionnel",
                [TypeDocument.Important] = "Important",
                [TypeDocument.Pour_plus_tard] = "A regarder plus tard"
            };

            // on teste;
            Console.WriteLine("Le type enum");
            TypeDocument typedoc = TypeDocument.Personnel | TypeDocument.Important;
            Console.WriteLine(typedoc);

            Console.WriteLine("\nLe type mapping");
            Console.WriteLine(mapping[TypeDocument.Pour_plus_tard]); // affiche l'énumération avec des espaces;
        }
        */
    }
}
