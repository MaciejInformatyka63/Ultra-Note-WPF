using Modele;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UltraNotes.UserControls
{
    /// <summary>
    /// Logique d'interaction pour Parametre_Affichage.xaml
    /// </summary>
    public partial class Parametre_Affichage : UserControl
    {
        #region Propriétés

        // on déclare une propriété de type Manager qui pointe vers le même espace mémoire que l'instance de Manager
        // dans App.xaml.cs. Ceci permet d'avoir accès à notre instance de Manager partout;
        public Manager MonManager => (App.Current as App).LeManager;

        #endregion

        #region Constructeurs

        public Parametre_Affichage()
        {
            InitializeComponent();
            BackgroundColorCombo.DataContext = MonManager.Bouquin;
        }

        #endregion

        #region Méthodes SelectionChanged

        /// <summary>
        /// Changes the color of the background
        /// </summary>
        private void OnBackgroundColorComboSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BackgroundColorCombo.SelectedItem == null) return;
            MonManager.Bouquin.ThemeApplication = BackgroundColorCombo.SelectedItem.ToString();
        }

        #endregion
    }
}
