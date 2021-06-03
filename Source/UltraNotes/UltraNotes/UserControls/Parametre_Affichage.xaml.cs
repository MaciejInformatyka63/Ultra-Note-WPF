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
        public Parametre_Affichage()
        {
            InitializeComponent();
            this.Initialize();
        }
        /// <summary>
        /// Changes the font color of the background
        /// </summary>
        private void OnBackgroundColorComboSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /* Exit if no selection
            if (FontColorCombo.SelectedItem == null) return;

            // clear selection if value unset
            if (FontColorCombo.SelectedItem.ToString() == "{DependencyProperty.UnsetValue}")
            {
                FontColorCombo.SelectedItem = FontColorCombo.Items[0];
                return;
            }

            / Process selection*/
            var color = BackgroundColorCombo.SelectedItem.ToString();
            ColorGrid.Background.SetValue(Control.BackgroundProperty, color);
        }

        private void Initialize()
        {
            BackgroundColorCombo.Items.Add("Red");
            BackgroundColorCombo.Items.Add("Blue");
        }
    }
}
