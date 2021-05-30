using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public interface ISauveur
    {
        #region Méthodes à implémenter dans les classes qui réalisent cette interface

        void SauveurBouquin(string chemin);

        #endregion
    }
}
