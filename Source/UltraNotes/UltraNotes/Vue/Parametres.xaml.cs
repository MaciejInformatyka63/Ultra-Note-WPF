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

namespace UltraNotes
{
    /// <summary>
    /// Logique d'interaction pour Parametres.xaml
    /// </summary>
    public partial class Parametres : Window
    {
        public Parametres()
        {
            InitializeComponent();
        }

        private void ListViewItem_General(object sender, RoutedEventArgs e)
        {
            contentControl_Parametres.Content = new UserControls.Parametre_General();
        }

        private void ListViewItem_Affichage(object sender, RoutedEventArgs e)
        {
            contentControl_Parametres.Content = new UserControls.Parametre_Affichage();
        }
    }
}
