﻿using System;
using Modele;

namespace Test_Note
{
    class Program
    {
        static void Main(string[] args)
        {
            Note note = new Note("note","hello");

            Style style = new Style(12,Police.Calibri,Alignement.Gauche,false,false,false);
            
            Console.WriteLine(note);
            Console.WriteLine(style);
        }
    }
}
