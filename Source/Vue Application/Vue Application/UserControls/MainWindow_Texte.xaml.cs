using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;

namespace Vue_Application.UserControls
{
    /// <summary>
    /// Logique d'interaction pour MainWindow_Texte.xaml
    /// </summary>
    public partial class MainWindow_Texte : UserControl
    {
        public MainWindow_Texte()
        {
            InitializeComponent();
            // texteditor.Navigate(@"file:///C:/Users/thdevienne/Documents/index.html");
            string curDir = Directory.GetCurrentDirectory();
            // texteditor.Navigate(curDir + .. );
        }

        /*
        private void RichTextArea(object sender, TextChangedEventArgs e)
        {
            Grid myGrid= new Grid();

            // Create a FlowDocument to contain content for the RichTextBox.
            FlowDocument myFlowDoc = new FlowDocument();

            // Add paragraphs to the FlowDocument.
            myFlowDoc.Blocks.Add(new Paragraph(new Run("Bienvenue dans UltraNotes !")));
            myFlowDoc.Blocks.Add(new Paragraph(new Run("Ici vous pouvez taper du texte et le modifier.")));
            myFlowDoc.Blocks.Add(new Paragraph(new Run("Profitez bien :)")));
            myFlowDoc.Blocks.Add(new Paragraph(new Run(curDir)));
            RichTextBox myRichTextBox = new RichTextBox
            {

                // Add initial content to the RichTextBox.
                Document = myFlowDoc
            };

            myGrid.Children.Add(myRichTextBox);
            this.Content = myGrid;
        }
        */
    }
}
