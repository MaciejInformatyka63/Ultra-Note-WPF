using System;
using System.Collections.Generic;
using System.Text;

namespace Modele
{
    [Flags]
    public enum TypeDocument : byte
    {
        // on donne les valeurs en byte 1, 2, 4, et 8 aux éléments de l'énumération pour pouvoir les combiner (ex. TypeDocument doc = TypeDocument.Personnel | TypeDocument.Important)
        // Sur l'exemple du dessus, Personnel = 1 et Important = 4 soit doc = 5, ce qui donne un nombre unique (aucun autre élément de l'énumération dans la liste en dessous n'a la valeur 5).
        // A l'image de cet exemple, toutes les combinaisons sont unique et donc possible;
        Personnel = 1,
        Profesionnel = 2,
        Important = 4,
        Pour_plus_tard = 8
    }
}
