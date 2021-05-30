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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UltraNotes.UserControls
{
    /// <summary>
    /// Logique d'interaction pour Menu.xaml
    /// </summary>
    public partial class Menu : UserControl
    {
        public Menu()
        {
            InitializeComponent();
            this.Initialize();
        }
        private void Initialize()
        {
            FontFamilyMenu.ItemsSource = Fonts.SystemFontFamilies;
            FontSizeMenu.Items.Add("10");
            FontSizeMenu.Items.Add("12");
            FontSizeMenu.Items.Add("14");
            FontSizeMenu.Items.Add("16");
            FontSizeMenu.Items.Add("18");
            FontSizeMenu.Items.Add("24");
            FontSizeMenu.Items.Add("32");
        }
    }
}
