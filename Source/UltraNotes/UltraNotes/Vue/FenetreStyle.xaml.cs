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
using System.Windows.Navigation;
using System.Linq;
using System.Threading.Tasks;
using static UltraNotes.UserControls.FsRichTextBox;
using Modele;
using System.Windows.Controls.Primitives;

namespace UltraNotes.Vue
{
    /// <summary>
    /// Logique d'interaction pour FenetreStyle.xaml
    /// </summary>
    public partial class FenetreStyle : Window
    {
        #region Champs privées

        private static ToggleButton m_SelectedAlignmentButton;
        private double p_TaillePolice;
        private string p_Police;
        private Alignement p_ALignement = Alignement.Gauche;
        private string p_CouleurPolice;
        private bool p_EstGras = false;
        private bool p_EstItalique = false;
        private bool p_EstSouligne = false;

        #endregion

        #region Propriétés

        // on déclare une propriété de type Manager qui pointe vers le même espace mémoire que l'instance de Manager
        // dans App.xaml.cs. Ceci permet d'avoir accès à notre instance de Manager partout;
        public Manager MonManager => (App.Current as App).LeManager;
        public string Nom { get; set; }

        #endregion

        #region Constructeur

        public FenetreStyle()
        {
            InitializeComponent();
            this.Initialize();
            //on définit le DataContext de la TextBox
            NomStyle.DataContext = this;
            AperçuStyle.DataContext = MonManager.Bouquin[0].StylesUtilisateur[MonManager.Bouquin[0].StylesUtilisateur.Count-1];
        }

        #endregion

        private void BoutonGras_Click(object sender, RoutedEventArgs e)
        {
            var boutonclique = (ToggleButton)sender ;
            if (boutonclique.IsChecked == true) p_EstGras = true;
            else p_EstGras = false;
        }

        private void BoutonItalique_Click(object sender, RoutedEventArgs e)
        {
            var boutonclique = (ToggleButton)sender;
            if (boutonclique.IsChecked == true) p_EstItalique = true;
            else p_EstItalique = false;
        }

        private void BoutonSurligne_Click(object sender, RoutedEventArgs e)
        {
            var boutonclique = (ToggleButton)sender;
            if (boutonclique.IsChecked == true) p_EstSouligne = true;
            else p_EstSouligne = false;
        }

        private void CreerUnStyle_Click(object sender, RoutedEventArgs e)
        {
            Modele.Style style = new Modele.Style(Nom, p_TaillePolice, p_Police, p_ALignement, p_CouleurPolice, p_EstGras, p_EstItalique, p_EstSouligne);
            MonManager.Bouquin[0].StylesUtilisateur.Add(style);
            Close();
        }

        /// <summary>
        /// Change la police de caractère
        /// </summary>
        private void OnFontFamilyComboSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FontFamilyCombo.SelectedItem == null) return;
            p_Police = FontFamilyCombo.SelectedItem.ToString();
        }
        /// <summary>
        /// Change la couleur de la police
        /// </summary>
        private void OnFontColorComboSelectionChanged(object sender, EventArgs e)
        {
            // On quitte si la selection est vide
            if (FontColorCombo.SelectedColor == null) return;
            // on change la couleur
            p_CouleurPolice = FontColorCombo.SelectedColor.ToString();
        }
        /// <summary>
        /// Change la taille de la police
        /// </summary>
        private void OnFontSizeComboSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FontSizeCombo.SelectedItem == null) return;
            if (FontSizeCombo.SelectedItem.ToString() == null) return;

            // on convertit le string en double
            var taille = FontSizeCombo.SelectedItem.ToString();
            p_TaillePolice = Convert.ToDouble(taille) * (96 / 72);
        }

        private void OnAlignementBoutonClick(object sender, RoutedEventArgs e)
        {
            var clickedButton = (ToggleButton)sender;
            var buttonGroup = new[] { LeftButton, CenterButton, RightButton, JustifyButton };
            this.SetButtonGroupSelection(clickedButton, m_SelectedAlignmentButton, buttonGroup, true);
            m_SelectedAlignmentButton = clickedButton;
            foreach (var button in buttonGroup)
            {
                if(button.IsChecked==true)
                {
                    switch (button.ToString())
                    {
                        case "LeftButton":
                            p_ALignement=Alignement.Gauche;
                            break;
                        case "CenterButton":
                            p_ALignement = Alignement.Centre;
                            break;
                        case "RightButton":
                            p_ALignement = Alignement.Droite;
                            break;
                        case "JustifyButton":
                            p_ALignement = Alignement.Justifie;
                            break;
                    }
                }
            }
        }

        private void SetButtonGroupSelection(ToggleButton clickedButton, ToggleButton currentSelectedButton, IEnumerable<ToggleButton> buttonGroup, bool ignoreClickWhenSelected)
        {
            if (clickedButton == currentSelectedButton)
            {
                if (ignoreClickWhenSelected) clickedButton.IsChecked = true;
                return;
            }
            foreach (var button in buttonGroup)
            {
                button.IsChecked = false;
            }
            clickedButton.IsChecked = true;
        }

        private void Initialize()
        {
            // police d'écriture
            FontFamilyCombo.ItemsSource = Fonts.SystemFontFamilies;
            // taille de police
            FontSizeCombo.Items.Add("10");
            FontSizeCombo.Items.Add("12");
            FontSizeCombo.Items.Add("14");
            FontSizeCombo.Items.Add("18");
            FontSizeCombo.Items.Add("24");
            FontSizeCombo.Items.Add("36");
        }

    }
}
