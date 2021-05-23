﻿using System;
using System.Collections.Generic;
using System.IO;
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

namespace UltraNotes.Vue
{
    /// <summary>
    /// Logique intéractive de MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Champs

        // On déclare un manager de cette manière;
        static IChargeur chargeur = new Stub();
        Manager manager = new Manager(chargeur.ChargeurBouquin(""));

        #endregion

        #region Constructeurs

        /// <summary>
        /// Construteur de la classe MainWindow
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            listViewNotes.DataContext = manager;
        }

        #endregion

        #region Méthodes privées

        /// <summary>
        /// Méthode appelée quand la valeur du layout RichTextBox change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RichTextArea(object sender, TextChangedEventArgs e)
        {
            // some content;
        }

        /// <summary>
        /// Méthode qui ouvre la fenêtre des paramètres quand le bouton associé à été cliqué
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonOptions_Click(object sender, RoutedEventArgs e)
        {
            Parametres parametre = new Parametres();
            parametre.Show();
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Forces an update of the FsRichTextBox.Document property.
        /// </summary>
        private void OnForceUpdateClick(object sender, RoutedEventArgs e)
        {
            this.EditBox.UpdateDocumentBindings();
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