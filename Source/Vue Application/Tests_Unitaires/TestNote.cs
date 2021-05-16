using System;
using Xunit;
using Modele;

namespace Tests_Unitaires
{
    public class TestNote
    {
        [Fact]
        public void CréationNote()
        {
            Note carré = new Note("carré", "Un carré est un rectangle particulier");
        }

        [Fact]
        public void EditionCommentaire()
        {
            Commentaire com = new Commentaire("ceci est un commentaire");
        }
    }
}
