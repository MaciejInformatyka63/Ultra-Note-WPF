﻿using System;
using Modele;

namespace Test_Note
{
    class Program
    {
        static void Main(string[] args)
        {
            Note note = new Note("hello");
            Console.WriteLine(note);
        }
    }
}
