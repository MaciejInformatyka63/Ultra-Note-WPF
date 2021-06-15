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
        // idem pour les parametres
        public Modele.Parametres Param => (App.Current as App).Param;
        // et pour note sélecitonnée qui définie la note courante;
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
            GrilleDeFond.DataContext = Param;
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
            File.Delete(System.IO.Path.Combine(Modele.Parametres.DossierEPF, (listBoxNotes.SelectedItem as Note).Nom));
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
            // on enregistre les paramètres
            Param.SauverParametres();
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
            // on enregistre les paramètres
            Param.SauverParametres();
        }
        /// <summary>
        /// Méthode qui est appelée quand la valeur du type du document change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /*private void TypeDocCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // si la selection est nulle, on sort
            if (TypeDocCombo.SelectedItem == null) return;

            // sinon on défini le type correspondant...
            switch (TypeDocCombo.SelectedItem)
            {
                case "Personnel":
                    MonManager.Bouquin[NoteSelectionnee].Type = TypeDocument.Personnel;
                    break;
                case "Important":
                    MonManager.Bouquin[NoteSelectionnee].Type = TypeDocument.Important;
                    break;
                case "Profesionnel":
                    MonManager.Bouquin[NoteSelectionnee].Type = TypeDocument.Profesionnel;
                    break;
                case "Pour plus tard":
                    MonManager.Bouquin[NoteSelectionnee].Type = TypeDocument.Pour_plus_tard;
                    break;
            }
        }*/
        /// <summary>
        /// Méthode appelée quand l'utilisateur touche aux éléments de la liste
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxNotes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // on défini la note courante sélectionnée;
            if (NoteSelectionnee >= MonManager.Bouquin.NombreDeNotes) NoteSelectionnee -= 1;
            NoteSelectionnee = (listBoxNotes.SelectedIndex == -1) ? NoteSelectionnee : listBoxNotes.SelectedIndex;
            if (listBoxNotes.SelectedIndex == -1) NoteSelectionnee = 0;
        }

        #endregion
    }
}
