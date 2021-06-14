using Modele;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        // idem pour Parametres:
        public Modele.Parametres Param => (App.Current as App).Param;

        #endregion

        #region Constructeurs

        public Parametre_Affichage()
        {
            InitializeComponent();
            BackgroundColorCombo.DataContext = Param;
            Debug.WriteLine(Param.ThemeApplication);
        }

        #endregion

        #region Méthodes SelectionChanged

        /// <summary>
        /// Changes the color of the background
        /// </summary>
        private void OnBackgroundColorComboSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BackgroundColorCombo.SelectedItem == null) return;
            //mise à jour de la propriété ThemeApplication
            Param.ThemeApplication = Param.ThemeApplicationCouleurs[BackgroundColorCombo.SelectedItem.ToString()];
            //mise à jour de la propriété ImageMainWindow
            Param.ImageMainWindow = Param.BanqueImagesMainWindow[BackgroundColorCombo.SelectedItem.ToString()];
            Debug.WriteLine(Param.ThemeApplication);
        }

        private void OnContrastComboSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ContrastCombo.SelectedItem == null) return;
            //mise à jour des propriétés ImageMainWindow et ThemeApplication
            if (ContrastCombo.SelectedItem == oui)
            {
                Param.ImageMainWindow = "../Assets/mountainsContrast.jpg";
                Param.ThemeApplication = "#252C2E";
                Debug.WriteLine(Param.ThemeApplication);
            }
            if (ContrastCombo.SelectedItem == non)
            {
                Param.ImageMainWindow = "../Assets/mountains.jpg";
                Param.ThemeApplication = "#64BED8";
                Debug.WriteLine(Param.ThemeApplication);
            }
        }

        #endregion
    }
}
