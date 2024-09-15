using System.Windows;

namespace BlackPinkTheme.Core
{
    public class ThemeManager
    {
        private Dictionary<string, ResourceDictionary> _themes = new();

        public void ApplyTheme(string themeName)
        {
            ResourceDictionary theme = _themes[themeName];  

            foreach (var kvp in _themes)
            {
                Application.Current.Resources.MergedDictionaries.Remove(kvp.Value);
            }

            Application.Current.Resources.MergedDictionaries.Add(theme);
        }

        public void RegisterTheme(string themeName, string assemblyName, string resourcePath)
        { 
            string urlString = $"/{assemblyName};component/{resourcePath}";

            ResourceDictionary resource = new();
            resource.Source = new Uri(urlString, UriKind.RelativeOrAbsolute);

            _themes.Add(themeName, resource);   
        }
    }
}
