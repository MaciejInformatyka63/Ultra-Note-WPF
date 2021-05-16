using System;
using Xunit;
using Modele;

namespace Tests_Unitaires
{
    public class TestManager
    {
        [Fact]
        public void AjoutDeFichierExistant()
        {
            Manager manager = new Manager(new Bouquin());
            manager.AjouterUnFichier(new Note("Nouveau document", "Bienvenue dans UltraNotes"));
            //on regarde si la collection Notes contient bien un élément ajouté par la méthode AjouterUnFichier
            Assert.Equal(1, manager.NombreDeNotes);
        }

        [Fact]
        public void AjoutDeFichiersInnexistant()
        {
            Manager manager = new Manager(new Bouquin());
            manager.AjouterUnFichier(null);
            Assert.Equal(0, manager.NombreDeNotes);
        }

        [Fact]
        public void SuppressionDeFichierInnexistant()
        {
            Manager manager = new Manager(new Bouquin());
            bool reponse = manager.SupprimerUneNote(new Note("Nouveau document", "Bienvenue dans UltraNotes"));
            Assert.False(reponse);
        }

        [Fact]
        public void SuppressionDeFichierExistant()
        {
            Manager manager = new Manager(new Bouquin());
            manager.AjouterListeDeNotes(new Note[]
            {
                new Note("Nouveau document", "Bienvenue dans UltraNotes"),
                new Note("Encore un nouveau document", "Et un nouveau contenu"),
                new Note("Document a supprimer", "Ce contenu va être perdu, vous êtes prévenus !")
            });
            bool reponse = manager.SupprimerUneNote(manager.Bouquin["Document a supprimer"]);
            Assert.True(reponse);
        }
    }
}
