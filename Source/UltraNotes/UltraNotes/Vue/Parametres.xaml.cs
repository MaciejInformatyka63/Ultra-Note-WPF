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
        #region Propriétés

        // on déclare une propriété de type Manager qui pointe vers le même espace mémoire que l'instance de Manager
        // dans App.xaml.cs. Ceci permet d'avoir accès à notre instance de Manager partout;
        public Manager MonManager => (App.Current as App).LeManager;
        // idem pour les paramètres
        public Modele.Parametres Param => (App.Current as App).Param;

        #endregion

        #region Constructeurs

        public Parametres()
        {
            InitializeComponent();

            // on définit la grille de fond;
            GrilleDeFond.DataContext = Param;
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

        #region Event Handler

        private void Confirmer_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        #endregion
    }
}
