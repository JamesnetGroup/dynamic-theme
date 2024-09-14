using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace DynamicTheme.Core
{
    public class ThemeProps
    {
        public static Brush GetBackground(DependencyObject obj)
        {
            return (Brush)obj.GetValue(BackgroundProperty);
        }

        public static void SetBackground(DependencyObject obj, Brush value)
        {
            obj.SetValue(BackgroundProperty, value);
        }

        public static readonly DependencyProperty BackgroundProperty =
            DependencyProperty.RegisterAttached("Background", typeof(Brush), typeof(ThemeProps), new PropertyMetadata(null,OnBackgroundPropertyChanged));

        private static void OnBackgroundPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is FrameworkElement element && e.NewValue is SolidColorBrush newBrush)
            {
                AnimateBrushProperty(element, newBrush, "Background");
            }
        }

        public static Brush GetForeground(DependencyObject obj)
        {
            return (Brush)obj.GetValue(ForegroundProperty);
        }

        public static void SetForeground(DependencyObject obj, Brush value)
        {
            obj.SetValue(ForegroundProperty, value);
        }

        public static readonly DependencyProperty ForegroundProperty =
            DependencyProperty.RegisterAttached("Foreground", typeof(Brush), typeof(ThemeProps), new PropertyMetadata(null,OnForegroundPropertyChanged));

        private static void OnForegroundPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is FrameworkElement element && e.NewValue is SolidColorBrush newBrush)
            {
                AnimateBrushProperty(element, newBrush, "Foreground");
            }
        }

        private static void AnimateBrushProperty(FrameworkElement element, SolidColorBrush newBrush, string propertyName)
        {
            var property = element.GetType().GetProperty(propertyName);

            if (property == null) return;

            var currentBrush = property.GetValue(element) as SolidColorBrush;

            if (currentBrush == null || currentBrush.IsFrozen)
            {
                currentBrush = new SolidColorBrush(newBrush.Color);

                property.SetValue(element, currentBrush);
            }

            currentBrush.BeginAnimation(SolidColorBrush.ColorProperty, new ColorAnimation
            {
                To = newBrush.Color,
                Duration = TimeSpan.FromSeconds(0.3)
            });
        }
    }
}