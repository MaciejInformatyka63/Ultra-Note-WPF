using System;
using Xunit;
using Modele;

namespace Tests_Unitaires
{
    public class TestUnitNote
    {
        [Fact]
        public void CréationNote()
        {
            Note carré = new Note("carré", "Un carré est un rectangle particulier");
        }
    }
}
