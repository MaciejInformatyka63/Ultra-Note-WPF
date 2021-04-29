using System;
using System.Collections.Generic;
using System.Text;

namespace Modele
{
    class Balise
    {
        public string Position { get; private set; }

        public Balise(string position)
        {
            Position = position;
        }
    }
}
