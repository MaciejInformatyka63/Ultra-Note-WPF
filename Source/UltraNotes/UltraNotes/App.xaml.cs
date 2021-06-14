using Modele;
using System;
using Data;
using DataContractPersistance;
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
        //static IChargeur chargeur = new Stub();
        // index de la note courant dans l'éditeur;
        int index_note;

        #endregion

        #region Propriétés

        public Modele.Parametres Param { get; set; } = new Modele.Parametres(new DataContractPers());
        /// <summary>
        /// On déclare un Manager commun à toutes les fenêtres, UserControls inclus
        /// </summary>
        public Manager LeManager { get; private set; } = new Manager(new Bouquin(new DataContractPers()));
        /// <summary>
        /// Note actuellement sélectionnée dans l'éditeur de texte
        /// </summary>
        public int NoteSelectionne
        {
            get => index_note;
            set => index_note = value;
        }

        #endregion

        #region Constructeurs

        public App()
        {
            Param.ChargerParametres();
            LeManager.Bouquin.ChargeDonnees();
        }

        #endregion
    }
}
