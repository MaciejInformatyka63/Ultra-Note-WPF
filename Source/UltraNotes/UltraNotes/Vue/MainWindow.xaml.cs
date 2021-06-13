using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
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
using UltraNotes.UserControls;
using Modele;
using Data;
using System.Windows.Markup;
using DataContractPersistance;

namespace UltraNotes.Vue
{
    /// <summary>
    /// Logique intéractive de MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Champs

        public Note noteSelectionne;

        #endregion

        #region Propriétés

        // on déclare une propriété de type Manager qui pointe vers le même espace mémoire que l'instance de Manager
        // dans App.xaml.cs. Ceci permet d'avoir accès à notre instance de Manager partout;
        public Manager MonManager => (App.Current as App).LeManager;
        // idem pour note sélecitonnée qui définie la note courante;
        public int NoteSelectionnee
        {
            get => (App.Current as App).NoteSelectionne;
            set => (App.Current as App).NoteSelectionne = value;
        }

        #endregion

        #region Constructeurs

        /// <summary>
        /// Construteur de la classe MainWindow
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            // on définie le DataContext;
            listBoxNotes.DataContext = MonManager;
            // on se place automatiquement sur le premier élément de la liste;
            listBoxNotes.SelectedItem = MonManager.Bouquin[0];
            // et on donne automatiquement le focus à la RichTextBox;
            EditBox.TextBox.Focus();

            // on défini également le DataContext de la grille de fond;
            GrilleDeFond.DataContext = MonManager.Bouquin;
            // et la note courante sélectionnée;
            NoteSelectionnee = 0;
        }

        #endregion

        #region Events Handler

        /// <summary>
        /// Méthode qui ouvre la fenêtre des paramètres quand le bouton associé à été cliqué
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BoutonOptions_Click(object sender, RoutedEventArgs e)
        {
            Parametres parametre = new Parametres();
            parametre.Show();
        }

        /// <summary>
        /// Méthode qui permet de créer une nouvelle note dans le bouquin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreerNote_Click(object sender, RoutedEventArgs e)
        {
            // on instancie une nouvelle note;
            // le titre est "Ma nouvelle note" suivi de "#x", x étant le nombre de notes
            // qui portent déjà le nom de "Ma nouvelle note";
            string titre_doc = "Ma nouvelle note";
            int nb_occurences = MonManager.Bouquin.BouquinDeNotes.Where(n => n.Nom.Contains(titre_doc)).Count();
            titre_doc = (nb_occurences == 0) ? titre_doc : $"{titre_doc} #{nb_occurences}";
            // le contenu de la note est un fichier XML représentant un FlowDocument vide;
            Note nouvelle_note = new Note(titre_doc, XamlWriter.Save(new FlowDocument()));
            // on l'ajoute au bouquin;
            MonManager.AjouterUneNote(nouvelle_note);
            // puis on la sélectionne automatiquement;
            listBoxNotes.SelectedItem = nouvelle_note;
        }

        /// <summary>
        /// Méthode qui permet de supprimer le fichier courant du bouquin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SupprimerFichier_Click(object sender, RoutedEventArgs e)
        {
            // on supprime le fichier;
            MonManager.SupprimerUneNote(listBoxNotes.SelectedItem as Note);
            // puis on sélectionne la dernière note du bouquin;
            int dernier_element = (MonManager.NombreDeNotes <= 0) ? 0 : MonManager.NombreDeNotes - 1;
            listBoxNotes.SelectedItem = MonManager.Bouquin[dernier_element];
        }

        private void EnregistrerNote_Click(object sender, RoutedEventArgs e)
        {
            // on provoque une mise à jour de la propriété Document de la FsRichTextBox
            var saveDoc = listBoxNotes.SelectedItem;
            listBoxNotes.SelectedItem = null;
            // on enregistre
            MonManager.Bouquin.SauvegardeNote(saveDoc as Note);
            // puis on reviens sur l'éléments sélectionné;
            listBoxNotes.SelectedItem = saveDoc;
        }

        private void EnregistrerToutesLesNote_Click(object sender, RoutedEventArgs e)
        {
            // on provoque une mise à jour de la propriété Document de la FsRichTextBox
            var saveDoc = listBoxNotes.SelectedItem;
            listBoxNotes.SelectedItem = null;
            // on enregistre
            foreach (Note note in MonManager.Bouquin.BouquinDeNotes) MonManager.Bouquin.SauvegardeDonnees();
            // puis on reviens sur l'éléments sélectionné;
            listBoxNotes.SelectedItem = saveDoc;
        }

        /// <summary>
        /// Méthode appelée quand l'utilisateur touche aux éléments de la liste
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxNotes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // on défini la note courante sélectionnée;
            NoteSelectionnee = listBoxNotes.SelectedIndex;
        }

        #endregion

        #region Ressources commentées

        /// <summary>
        /// Méthode qui permet d'appliquer un effet de gras sur une portion de texte
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /*private void effetGrasClick(object sender, RoutedEventArgs e)
        {
            BindingExpression be = textbox.GetBindingExpression(TextBox.FontWeightProperty);
            be.UpdateSource();
        }*/


        /* VOICI UNE MANIERE DE SERIALISER AVEC FILESTREAM
        private void SaveRTBContent(object sender, RoutedEventArgs e)
        {
            // Send an arbitrary URL and file name string specifying
            // the location to save the XAML in.
            SaveXamlPackage("C:\\test.xaml");
        }

        void LoadRTBContent(Object sender, RoutedEventArgs args)
        {
            // Send URL string specifying what file to retrieve XAML
            // from to load into the RichTextBox.
            LoadXamlPackage("C:\\test.xaml");
        }

        // Sauvegarde du XAML contenu dans le RichTextBox à l'intérieur d'un fichier _fileName
        void SaveXamlPackage(string _fileName)
        {
            TextRange range;
            FileStream fStream;
            range = new TextRange(RichTextBox.Document.ContentStart, RichTextBox.Document.ContentEnd);
            fStream = new FileStream(_fileName, FileMode.Create);
            range.Save(fStream, DataFormats.XamlPackage);
            fStream.Close();
        }

        // Chargement du XAML dans la RichTextBox (RTB) en spécifiant un fichier _fileName
        void LoadXamlPackage(string _fileName)
        {
            TextRange range;
            FileStream fStream;
            if (File.Exists(_fileName))
            {
                range = new TextRange(RichTextBox.Document.ContentStart, RichTextBox.Document.ContentEnd);
                fStream = new FileStream(_fileName, FileMode.OpenOrCreate);
                range.Load(fStream, DataFormats.XamlPackage);
                fStream.Close();
            }
        }
        */

        /* VOICI UNE MANIERE DE SERIALISER AVEC MEMORYSTREAM (cependant privilégier FileStream pour les RichTextBox)
        private MemoryStream src = null;

        private void btnSave_Click(Object sender, System.Windows.RoutedEventArgs e)
        {
            if (src != null)
            {
                src.Close();
            }
            src = new MemoryStream();
            new TextRange(RichTextBox.Document.ContentStart, RichTextBox.Document.ContentEnd).Save(
             src, System.Windows.DataFormats.Rtf);
        }

        private void btnLoad_Click(Object sender, System.Windows.RoutedEventArgs e)
        {
            if (src != null)
            {
                src.Seek(0, SeekOrigin.Begin);
                new TextRange(RichTextBox.Document.ContentStart, RichTextBox.Document.ContentEnd).Load(
                src, System.Windows.DataFormats.Rtf);
            }
        }
        */

        #endregion
    }
}
