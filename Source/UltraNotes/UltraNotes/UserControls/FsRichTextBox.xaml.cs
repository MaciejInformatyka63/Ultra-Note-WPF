using Microsoft.Win32;
using System;
using Modele;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UltraNotes.Vue;

namespace UltraNotes.UserControls
{
    /// <summary>
    /// Interaction logic for FsRichTextBox.xaml
    /// </summary>
    public partial class FsRichTextBox : UserControl
    {
        #region Champs

        // Static member variables
        private static ToggleButton m_SelectedAlignmentButton;
        private static ToggleButton m_SelectedListButton;

        // Member variables
        private int m_InternalUpdatePending;
        private bool m_TextHasChanged;

        #endregion

        #region Dependency Property Declarations

        // Document property
        public static readonly DependencyProperty DocumentProperty =
            DependencyProperty.Register("Document", typeof(FlowDocument),
            typeof(FsRichTextBox), new PropertyMetadata(OnDocumentChanged));

        #endregion

        #region Constructeur

        /// <summary>
        /// Default constructor.
        /// </summary>
        public FsRichTextBox()
        {
            InitializeComponent();
            this.Initialize();
        }

        #endregion

        #region Propriétés

        /// <summary>
        /// FlowDocument WPF contenu dans le controle.
        /// </summary>
        public FlowDocument Document
        {
            get { return (FlowDocument)GetValue(DocumentProperty); }
            set { SetValue(DocumentProperty, value); }
        }

        // on déclare une propriété de type Manager qui pointe vers le même espace mémoire que l'instance de Manager
        // dans App.xaml.cs. Ceci permet d'avoir accès à notre instance de Manager partout;
        public Manager MonManager => (App.Current as App).LeManager;
        // idem pour la note courant sélectionnée;
        public int NoteSelectionnee => (App.Current as App).NoteSelectionne;

        #endregion

        #region PropertyChanged Callback Methods

        /// <summary>
        /// Appellé quand la propriété Document est modifiée
        /// </summary>
        private static void OnDocumentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            /* Pour des raisons inconnues, cette méthode est appellée 2 fois 
             * quand la propriété Document est "settée". Jusqu'à ce qu'on trouve la raison, nous initialisons
             * le flag à 2 et le décrémentons chaque fois que l'on passe par cette méthode. */

            // Initialisation
            var thisControl = (FsRichTextBox)d;

            // Exit if this update was internally generated
            if (thisControl.m_InternalUpdatePending > 0)
            {

                // Décrémentation du flag et sortie
                thisControl.m_InternalUpdatePending--;
                return;
            }

            // on sauve la valeur du Tag
            thisControl.TextBox.Tag = e.OldValue;
            // On "sette" la propriété Document de la RichTextBox
            thisControl.TextBox.Document = (e.NewValue == null) ? new FlowDocument() : (FlowDocument)e.NewValue;

            // Réinitialisation du flag
            thisControl.m_TextHasChanged = false;
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Implements single-select on the alignment button group.
        /// </summary>
        private void OnAlignementBoutonClick(object sender, RoutedEventArgs e)
        {
            var clickedButton = (ToggleButton)sender;
            var buttonGroup = new[] { LeftButton, CenterButton, RightButton, JustifyButton };
            this.SetButtonGroupSelection(clickedButton, m_SelectedAlignmentButton, buttonGroup, true);
            m_SelectedAlignmentButton = clickedButton;
            TextBox.Focus();
        }

        /// <summary>
        /// Changes the font family of selected text.
        /// </summary>
        private void OnFontFamilyComboSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FontFamilyCombo.SelectedItem == null) return;
            var fontFamily = FontFamilyCombo.SelectedItem.ToString();
            var textRange = new TextRange(TextBox.Selection.Start, TextBox.Selection.End);
            textRange.ApplyPropertyValue(TextElement.FontFamilyProperty, fontFamily);
        }
        /// <summary>
        /// Changes the font color of selected text.
        /// </summary>
        private void OnFontColorComboSelectionChanged(object sender, EventArgs e)
        {
            // On quitte si la selection est vide
            if (FontColorCombo.SelectedColor == null) return;

            // on change la couleur
            var textRange = new TextRange(TextBox.Selection.Start, TextBox.Selection.End);
            textRange.ApplyPropertyValue(TextElement.ForegroundProperty, FontColorCombo.SelectedColor.ToString());
        }
        /// <summary>
        /// Changes the font size of selected text.
        /// </summary>
        private void OnFontSizeComboSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Exit if no selection
            if (FontSizeCombo.SelectedItem == null) return;

            // clear selection if value unset
            if (FontSizeCombo.SelectedItem.ToString() == "{DependencyProperty.UnsetValue}")
            {
                FontSizeCombo.SelectedItem = null;
                return;
            }

            // Process selection
            var pointSize = FontSizeCombo.SelectedItem.ToString();
            var pixelSize = Convert.ToDouble(pointSize) * (96 / 72);
            var textRange = new TextRange(TextBox.Selection.Start, TextBox.Selection.End);
            textRange.ApplyPropertyValue(TextElement.FontSizeProperty, pixelSize);
        }

        /// <summary>
        /// Change le style du texte sélectionné
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnStyleComboSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // On quitte si la selection est nulle
            if (StyleCombo.SelectedItem == null) return;

            // on réinitialise
            StyleCombo.ItemsSource = MonManager.Bouquin[NoteSelectionnee].StylesUtilisateur;

            // sinon on change le style du texte sélectionné
            Modele.Style style = (StyleCombo.SelectedItem as Modele.Style);
            var textRange = new TextRange(TextBox.Selection.Start, TextBox.Selection.End);
            textRange.ApplyPropertyValue(TextElement.FontFamilyProperty, style.PoliceEcriture);
            textRange.ApplyPropertyValue(TextElement.FontSizeProperty, style.TailleDePolice);
            textRange.ApplyPropertyValue(TextElement.ForegroundProperty, style.CouleurTexte);
            if (style.IsGras) EditingCommands.ToggleBold.Execute(null, TextBox);
            if (style.IsItalique) EditingCommands.ToggleItalic.Execute(null, TextBox);
            if (style.IsSouligne) EditingCommands.ToggleUnderline.Execute(null, TextBox);
            switch (style.AlignementTexte)
            {
                case Alignement.Gauche:
                    EditingCommands.AlignLeft.Execute(null, TextBox);
                    break;
                case Alignement.Centre:
                    EditingCommands.AlignCenter.Execute(null, TextBox);
                    break;
                case Alignement.Droite:
                    EditingCommands.AlignRight.Execute(null, TextBox);
                    break;
                case Alignement.Justifie:
                    EditingCommands.AlignJustify.Execute(null, TextBox);
                    break;
            }
        }

        /// <summary>
        /// Implements single-select on the alignment button group.
        /// </summary>
        private void OnListButtonClick(object sender, RoutedEventArgs e)
        {
            var clickedButton = (ToggleButton)sender;
            var buttonGroup = new[] { BulletsButton, NumberingButton };
            this.SetButtonGroupSelection(clickedButton, m_SelectedListButton, buttonGroup, false);
            m_SelectedListButton = clickedButton;
        }

        /// <summary>
        /// Ouvre un gestionnaire de fichier et insert une image dans la FsRichTextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AjoutImage_Click(object sender, RoutedEventArgs e)
        {
            // on ouvre un gestionnaire de fichier
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Insérer une image";
            dialog.Filter = "Tous les fichiers images|*.jpg;*.png;*.bmp";
            bool? resultat = dialog.ShowDialog();

            // on récupère le résultat de la fenêtre et on l'insère dans notre projet;
            if (resultat == true)
            {
                string filePath = dialog.FileName;
                BitmapImage bitmap = new BitmapImage(new Uri(filePath, UriKind.Absolute));
                Image image = new Image();
                image.Source = bitmap;
                image.Width = TextBox.Width;

                if (image != null)
                {
                    TextPointer tp = TextBox.CaretPosition.GetInsertionPosition(LogicalDirection.Forward);
                    Floater floater = new Floater(new BlockUIContainer(image), tp);
                }
            }
        }

        private void CréerStyle_Click(object sender, RoutedEventArgs e)
        {
            FenetreStyle fenetreStyle = new FenetreStyle();
            fenetreStyle.Show();
        }
        /// <summary>
        /// Evènement qui se déclanche quand l'utilisateur clique dans la RichTextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // Set style combo
            StyleCombo.ItemsSource = null;
            StyleCombo.ItemsSource = MonManager.Bouquin[NoteSelectionnee].StylesUtilisateur;
            StyleCombo.SelectedItem = null;
        }
        /// <summary>
        ///  Invoked when the user changes text in this user control.
        /// </summary>
        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            ActualiserBarreOutils();
            // Set the TextChanged flag
            m_TextHasChanged = true;
        }

        #endregion

        #region Méthodes privées

        /// <summary>
        /// Initializes the control.
        /// </summary>
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
        /// <summary>

        /// Sets the toolbar.

        /// </summary>

        private void ActualiserBarreOutils()
        {
            // Set font family combo
            var textRange = new TextRange(TextBox.Selection.Start, TextBox.Selection.End);
            var fontFamily = textRange.GetPropertyValue(TextElement.FontFamilyProperty);
            FontFamilyCombo.SelectedItem = fontFamily;
            // Set font size combo
            var fontSize = textRange.GetPropertyValue(TextElement.FontSizeProperty);
            FontSizeCombo.Text = fontSize.ToString();
            // Set font color combo
            var fontColor = textRange.GetPropertyValue(TextElement.ForegroundProperty);
            //FontColorCombo.SelectedColor = Color.FromRgb();
            //FontColorCombo.SelectedColor.ToString() = fontColor.ToString();
            // Set Font buttons
            BoldButton.IsChecked = textRange?.GetPropertyValue(TextElement.FontWeightProperty).Equals(FontWeights.Bold);
            ItalicButton.IsChecked = textRange?.GetPropertyValue(TextElement.FontStyleProperty).Equals(FontStyles.Italic);
            //UnderlineButton.IsChecked = textRange?.GetPropertyValue(Inline.TextDecorationsProperty).Equals(TextDecorations.Underline);
            // Set Alignment buttons
            LeftButton.IsChecked = textRange?.GetPropertyValue(FlowDocument.TextAlignmentProperty).Equals(TextAlignment.Left);
            CenterButton.IsChecked = textRange?.GetPropertyValue(FlowDocument.TextAlignmentProperty).Equals(TextAlignment.Center);
            RightButton.IsChecked = textRange?.GetPropertyValue(FlowDocument.TextAlignmentProperty).Equals(TextAlignment.Right);
            JustifyButton.IsChecked = textRange?.GetPropertyValue(FlowDocument.TextAlignmentProperty).Equals(TextAlignment.Justify);
        }

        #endregion
    }
}
