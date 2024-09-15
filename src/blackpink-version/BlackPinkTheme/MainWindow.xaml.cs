using BlackPinkTheme.Core;
using System.Windows;
using System.Windows.Threading;

namespace BlackPinkTheme
{
    public partial class MainWindow : Window
    {
        private readonly ThemeManager _themeManager;
        private DispatcherTimer _timer;
        private bool _isDarkTheme = false;

        public MainWindow()
        {
            InitializeComponent();
            _themeManager = new ThemeManager();
            _themeManager.RegisterTheme("Dark", "BlackPinkTheme.Resources", "DarkTheme.xaml");
            _themeManager.RegisterTheme("Light", "BlackPinkTheme.Resources", "LightTheme.xaml");

            InitializeTimer();

            Switch.Checked += Switch_Checked;
            Switch.Unchecked += Switch_Unchecked;

            Closing += MainWindow_Closing;
        }

        private void InitializeTimer()
        {
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(3);
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            _isDarkTheme = !_isDarkTheme;
            Switch.IsChecked = _isDarkTheme;
            ApplyTheme();
        }

        private void Switch_Unchecked(object sender, RoutedEventArgs e)
        {
            _isDarkTheme = false;
            ApplyTheme();
        }

        private void Switch_Checked(object sender, RoutedEventArgs e)
        {
            _isDarkTheme = true;
            ApplyTheme();
        }

        private void ApplyTheme()
        {
            _themeManager.ApplyTheme(_isDarkTheme ? "Dark" : "Light");
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_timer != null)
            {
                _timer.Stop();
                _timer = null;
            }
        }
    }
}