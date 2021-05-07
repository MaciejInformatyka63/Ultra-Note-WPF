using System;
using Xunit;
using Modele;

namespace Tests_Unitaires
{
    public class TestUtilisateur
    {
        [Fact]
        public void CréationUtilisateur()
        {
            Utilisateur utilisateur = new Utilisateur("Dupont","artisan","dupont63","",0);
            Console.WriteLine(utilisateur);
        }
    }
}
