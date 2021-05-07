using System;
using Xunit;
using Modele;

namespace Tests_Unitaires
{
    public class TestManager
    {
        [Fact]
        public void AjoutDeFichier()
        {
            Manager manager = new Manager();
            manager.AjouterUnFichier();
        }
    }
}
