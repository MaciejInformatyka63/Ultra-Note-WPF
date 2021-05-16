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
            Manager manager = new Manager(new Bouquin());
            manager.AjouterUnFichier(new Note("Nouveau document", "Bienvenue dans UltraNotes"));
            //on regarde si la collection Notes contient bien un élément ajouté par la méthode AjouterUnFichier
            Assert.Equal(1, manager.NombreDeNotes);
        }
    }
}
