using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Modele;

namespace UltraNotes
{
    /// <summary>
    /// Logique d'interaction pour Parametres.xaml
    /// </summary>
    public partial class Parametres : Window
    {
        /*
        #region Propriétés

        public Bouquin Bouquin
        {
            get { return (Bouquin)GetValue(BouquinProperty); }
            set { SetValue(BouquinProperty, value); }
        }

        #endregion

        #region Déclaration des Dependency Properties

        public static readonly DependencyProperty BouquinProperty =
            DependencyProperty.Register("Bouquin", typeof(int), typeof(Bouquin), new PropertyMetadata(0));

        #endregion
        */

        public Bouquin BouquinNotes { get; set; }

        #region Constructeurs

        public Parametres()
        {
            InitializeComponent();
            DataContext = BouquinNotes;
        }

        #endregion

        #region UserControls

        private void ListViewItem_General(object sender, RoutedEventArgs e)
        {
            contentControl_Parametres.Content = new UserControls.Parametre_General();
        }

        private void ListViewItem_Affichage(object sender, RoutedEventArgs e)
        {
            contentControl_Parametres.Content = new UserControls.Parametre_Affichage();
        }

        #endregion
    }
}
