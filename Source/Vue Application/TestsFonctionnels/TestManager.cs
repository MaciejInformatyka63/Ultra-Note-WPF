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
            string chemin = "Chemin invalide";
            Manager manager = new Manager();
            string reponse = manager.AjouterUnFichier(chemin);
            Console.WriteLine($"Erreur lors de l'éxécution: {reponse}");
        }
    }
}
