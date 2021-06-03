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

        public Bouquin BouquinUtilisateur
        {
            get { return (Bouquin)GetValue(BouquinUtilisateurProperty); }
            set { SetValue(BouquinUtilisateurProperty, value); }
        }

        #endregion

        #region Déclaration des Dependency Properties

        public static readonly DependencyProperty BouquinUtilisateurProperty =
            DependencyProperty.Register("BouquinUtilisateur", typeof(Bouquin), typeof(Parametre_Affichage));

        #endregion

        #region Constructeurs

        public Parametre_Affichage()
        {
            InitializeComponent();
            DataContext = BouquinUtilisateur;
        }

        #endregion

        #region Méthodes SelectionChanged

        /// <summary>
        /// Changes the font color of the background
        /// </summary>
        private void OnBackgroundColorComboSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BackgroundColorCombo.SelectedItem == null) return;
            BouquinUtilisateur.ThemeApplication = BackgroundColorCombo.SelectedItem.ToString();
        }

        #endregion
    }
}
