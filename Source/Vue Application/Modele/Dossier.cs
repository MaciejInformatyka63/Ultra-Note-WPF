using System;
using System.Collections.Generic;
using System.Text;

namespace Modele
{
    class Dossier
    {
        List<Fichier> listeDeFichiers = new List<Fichier>();

        public void AjouterUnFichier(Fichier file)
        {
            listeDeFichiers.Add(file);
        }
        public void SupprimerUnFichier(Fichier file)
        {

        }
    }
}
