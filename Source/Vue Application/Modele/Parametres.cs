using System;
using System.Collections.Generic;
using System.Text;

namespace Modele
{
    class Parametres
    {
        public Parametres(bool modeContraste, string themeApplication)
        {
            ModeContraste = modeContraste;
            ThemeApplication = themeApplication;
        }

        public Boolean ModeContraste { get; private set; }
        public string ThemeApplication { get; private set; }
        public override string ToString()
        {
            return $"mode contraste {ModeContraste} ; thème : {ThemeApplication}";
        }
    }
}
