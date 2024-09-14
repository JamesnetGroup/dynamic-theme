using DynamicTheme.Core;
using System.Windows;

namespace DynamicTheme
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ThemeManager _themeManager;

        public MainWindow()
        {
            InitializeComponent();

           _themeManager = new ThemeManager();

            _themeManager.RegisterTheme("Dark", "DynamicTheme.Resources", "DarkTheme.xaml");
            _themeManager.RegisterTheme("Light", "DynamicTheme.Resources", "LightTheme.xaml");

            Switch.Checked += Switch_Checked;
            Switch.Unchecked += Switch_Unchecked;
        }


        private void Switch_Checked(object sender, RoutedEventArgs e)
        {
            _themeManager.ApplyTheme("Light");
        }

        private void Switch_Unchecked(object sender, RoutedEventArgs e)
        {
            _themeManager.ApplyTheme("Dark");
        }

    }
}