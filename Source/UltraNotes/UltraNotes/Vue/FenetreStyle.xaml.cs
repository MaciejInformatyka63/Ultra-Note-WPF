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
        private string p_NomStyle;
        private double p_TaillePolice;
        private string p_Police;
        private Alignement p_ALignement;
        private string p_CouleurPolice;
        private bool p_IsGras;
        private bool p_IsItalique;
        private bool p_IsSouligne;

        #endregion

        #region Propriétés

        // on déclare une propriété de type Manager qui pointe vers le même espace mémoire que l'instance de Manager
        // dans App.xaml.cs. Ceci permet d'avoir accès à notre instance de Manager partout;
        public Manager MonManager => (App.Current as App).LeManager;
        // idem pour la note courant sélectionnée;
        public int NoteSelectionnee => (App.Current as App).NoteSelectionne;

        #endregion

        #region Constructeur

        public FenetreStyle()
        {
            InitializeComponent();
            this.Initialize();
            //on définit le DataContext de la TextBox
            NomStyle.DataContext = this;
        }

        #endregion

        #region Event Handler

        private void CreerUnStyle_Click(object sender, RoutedEventArgs e)
        {
            // le nom du style
            p_NomStyle = (NomStyle.Text.Equals("")) ? "Style utilisateur" : NomStyle.Text;
            // mise en forme
            p_IsGras = BoldButton.IsChecked ?? false;
            p_IsItalique = ItalicButton.IsChecked ?? false;
            p_IsSouligne = UnderlineButton.IsChecked ?? false;
            // texte
            p_Police = FontFamilyCombo.SelectedItem?.ToString() ?? "Arial";
            p_TaillePolice = Convert.ToDouble(FontSizeCombo.SelectedItem?.ToString());
            if (p_TaillePolice == 0D) p_TaillePolice = 14D;
            p_CouleurPolice = FontColorCombo.SelectedColorText?.ToString();
            if (p_CouleurPolice.Equals("")) p_CouleurPolice = "Black";
            // mise en page
            if ((bool)LeftButton.IsChecked) p_ALignement = Alignement.Gauche;
            if ((bool)CenterButton.IsChecked) p_ALignement = Alignement.Centre;
            if ((bool)RightButton.IsChecked) p_ALignement = Alignement.Droite;
            if ((bool)JustifyButton.IsChecked) p_ALignement = Alignement.Justifie;

            // on ajoute les styles au document actuel
            Modele.Style style = new Modele.Style(p_NomStyle, p_TaillePolice, p_Police, p_ALignement, p_CouleurPolice, p_IsGras, p_IsItalique, p_IsSouligne);
            MonManager.Bouquin[NoteSelectionnee].DefinirStyle(style);

            // on ferme la fenêtre
            Close();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Implements single-select on the alignment button group.
        /// </summary>
        private void OnAlignementBoutonClick(object sender, RoutedEventArgs e)
        {
            var clickedButton = (ToggleButton)sender;
            var buttonGroup = new[] { LeftButton, CenterButton, RightButton, JustifyButton };
            this.SetButtonGroupSelection(clickedButton, m_SelectedAlignmentButton, buttonGroup, true);
            m_SelectedAlignmentButton = clickedButton;
        }

        #endregion

        #region Méthodes privées

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

        /// <summary>
        /// Sets a selection in a button group.
        /// </summary>
        /// <param name="clickedButton">The button that was clicked.</param>
        /// <param name="currentSelectedButton">The currently-selected button in the group.</param>
        /// <param name="buttonGroup">The button group to which the button belongs.</param>
        /// <param name="ignoreClickWhenSelected">Whether to ignore a click on the button when it is selected.</param>
        private void SetButtonGroupSelection(ToggleButton clickedButton, ToggleButton currentSelectedButton, IEnumerable<ToggleButton> buttonGroup, bool ignoreClickWhenSelected)
        {
            /* In some cases, if the user clicks the currently-selected button, we want to ignore
             * the click; for example, when a text alignment button is clicked. In other cases, we
             * want to deselect the button, but do nothing else; for example, when a list butteting
             * or numbering button is clicked. The ignoreClickWhenSelected variable controls that
             * behavior. */

            // Exit if currently-selected button is clicked
            if (clickedButton == currentSelectedButton)
            {
                if (ignoreClickWhenSelected) clickedButton.IsChecked = true;
                return;
            }

            // Deselect all buttons
            foreach (var button in buttonGroup)
            {
                button.IsChecked = false;
            }

            // Select the clicked button
            clickedButton.IsChecked = true;
        }

        #endregion
    }
}