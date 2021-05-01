using System;
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
using Vue_Application.UserControls;

namespace Vue_Application
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            /* // Pour utiliser HTML avec l'éditeur de texte
            texteditor.Navigate(@"file:///C:/Users/thdevienne/Documents/index.html");
            string curDir = Directory.GetCurrentDirectory();
            texteditor.Navigate(curDir + .. );
            */
        }

        private void RichTextArea(object sender, TextChangedEventArgs e)
        {
            /*Grid myGrid= new Grid();

            // Create a FlowDocument to contain content for the RichTextBox.
            FlowDocument myFlowDoc = new FlowDocument();

            // Add paragraphs to the FlowDocument.
            myFlowDoc.Blocks.Add(new Paragraph(new Run("Bienvenue dans UltraNotes !")));
            myFlowDoc.Blocks.Add(new Paragraph(new Run("Ici vous pouvez taper du texte et le modifier.")));
            myFlowDoc.Blocks.Add(new Paragraph(new Run("Profitez bien :)")));
            RichTextBox myRichTextBox = new RichTextBox
            {

                // Add initial content to the RichTextBox.
                Document = myFlowDoc
            };

            myGrid.Children.Add(myRichTextBox);
            this.Content = myGrid;*/
        }

        private void ButtonOptions_Click(object sender, RoutedEventArgs e)
        {
            Parametres parametre = new Parametres();
            parametre.Show();
        }

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
    }
}
