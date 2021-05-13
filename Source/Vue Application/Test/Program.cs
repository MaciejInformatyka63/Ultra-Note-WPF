using System;
using Modele;

namespace Test_Note
{
    class Program
    {
        static void Main(string[] args)
        {
            Note note = new Note("note", "hello");

            Style style = new Style(12, Police.Arial, Alignement.gauche, false, false, false);

            note.DefinirStyle(style);

            Console.WriteLine(note);
            note.RenommerUnFichier("NouvelleNote");
            Console.WriteLine(note);
            // Console.WriteLine(note.listeStyle[0]);
        }
    }
}
