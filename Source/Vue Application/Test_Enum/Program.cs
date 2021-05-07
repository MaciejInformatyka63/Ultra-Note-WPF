using System;
using System.Collections.Generic;
using Modele;
using static System.Console;

namespace Test_Enum
{
    class Program
    {
        static void Main(string[] args)
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
            WriteLine("Le type enum");
            TypeDocument typedoc = TypeDocument.Personnel | TypeDocument.Important;
            WriteLine(typedoc);

            WriteLine("\nLe type mapping");
            WriteLine(mapping[TypeDocument.Pour_plus_tard]); // affiche l'énumération avec des espaces;
        }
    }
}
