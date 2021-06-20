using Modele;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace UltraNotes.UserControls
{
    /// <summary>
    /// Logique d'interaction pour Parametre_General.xaml
    /// </summary>
    public partial class Parametre_General : UserControl
    {
        // on déclare une propriété de type Manager qui pointe vers le même espace mémoire que l'instance de Manager
        // dans App.xaml.cs. Ceci permet d'avoir accès à notre instance de Manager partout;
        public Manager MonManager => (App.Current as App).LeManager;
        public string FilePath { get; set; } = $"Les fichiers se trouvent à l'adresse {Path.Combine(Directory.GetCurrentDirectory(), "..//XML")} sur votre disque dur";

        public Parametre_General()
        {
            InitializeComponent();
            info.DataContext = this;
        }

        private void SuppTout_Click(object sender, RoutedEventArgs e)
        {
            MonManager.Bouquin.Nettoyer();
        }
    }
}
