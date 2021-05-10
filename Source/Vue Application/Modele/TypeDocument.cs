using System;
using System.Collections.Generic;
using System.Text;

namespace Modele
{
    [Flags]
    public enum TypeDocument : byte
    {
        Personnel = 1,
        Profesionnel = 2,
        Important = 4,
        Pour_plus_tard = 8
    }

    // Ici il faut faire un mapping de l'enumération vers un string pour retirer les espaces;
}
