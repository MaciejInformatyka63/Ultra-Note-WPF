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
using System.Windows.Shapes;

namespace Vue_Application
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
            contentControl_Parametres.Content = new Parametre_General();
        }

        private void ListViewItem_Affichage(object sender, RoutedEventArgs e)
        {
            contentControl_Parametres.Content = new Parametre_Affichage();
        }
    }
}
