using Data;
using Modele;
using System;

namespace TestsFonctionnels
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            //Test sur Bouquin
            Console.WriteLine("-----     -----     -----     TestBouquin     -----     -----     -----");
            Console.WriteLine();
            // Test de la manipulation des bouquins;
            TestBouquin.TestManipBouquin();
            // Test du Manager;
            Console.WriteLine("-----     -----     -----     TestManager     -----     -----     -----");
            Console.WriteLine();
            TestManager.TestManipManager();
            TestManager.TestManipNoteViaManager();
            // Test sur Note;
            Console.WriteLine("-----     -----     -----     TestNote     -----     -----     -----");
            Console.WriteLine();
            TestNote.TestRenomNote();
            TestNote.TestDefStyleNote();
            Console.WriteLine("-----     -----     -----     TestEnum     -----     -----     -----");
            Console.WriteLine();
            //TestEnum.TestEnumTypeDocument();
            */
            TestBouquin.AfficherListe(new Bouquin(new Stub()));
        }
    }
}
