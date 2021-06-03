﻿using System;
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
        #region Constructeurs

        public Parametres()
        {
            InitializeComponent();
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
