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
            //on regarde si la collection Notes contient bien un élément ajouté par la méthode AjouterUnFichier
            Assert.Equal(1, manager.Notes);
        }
    }
}
