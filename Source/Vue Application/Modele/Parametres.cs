using System;
using System.Collections.Generic;
using System.Text;

namespace Modele
{
    class Parametres
    {
        /*
         * Propriétés
        */
        public Boolean ModeContraste { get; private set; }
        public string ThemeApplication { get; private set; }
        public static string DossierEPF { get; private set; }

        /*
         * Constructeurs
        */
        /* public Parametres(bool modeContraste, string themeApplication)
        {
            ModeContraste = modeContraste;
            ThemeApplication = themeApplication;
        }*/

        /*
         * Méthodes redéfinies
        */
        public override string ToString()
        {
            return $"mode contraste {ModeContraste} ; thème : {ThemeApplication}";
        }
    }
}
