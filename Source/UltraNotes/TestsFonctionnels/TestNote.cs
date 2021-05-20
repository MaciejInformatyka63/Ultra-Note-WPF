using System;
using System.Collections.Generic;
using System.Text;
using Modele;

namespace TestsFonctionnels
{
    class TestNote
    {
        public static void TestRenomNote()
        {
            Note note = new Note("note", "hello");

            Console.WriteLine(note);

            note.RenommerUnFichier("NouvelleNote");

            Console.WriteLine(note);
        }
        public static void TestDefStyleNote()
        {
            Note note = new Note("note","hello");

            Style style = new Style(12, Police.Arial, Alignement.gauche, false, false, false);

            note.DefinirStyle(style);

            Console.WriteLine(note.StylesUtilisateur[0]);
        }
    }
}
