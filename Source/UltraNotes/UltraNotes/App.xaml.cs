using Modele;
using System;
using Data;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;


namespace UltraNotes
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region Champs
     
        // on instancie un Stub;
        static IChargeur chargeur = new Stub();

        #endregion

        #region Propriétés

        // on déclare un Manager commun à toutes les fenêtres, UserControls inclus;
        public Manager LeManager { get; private set; } = new Manager(chargeur.ChargeurBouquin(""));

        #endregion

        #region Constructeurs

        public App()
        {

        }

        #endregion
    }
}
