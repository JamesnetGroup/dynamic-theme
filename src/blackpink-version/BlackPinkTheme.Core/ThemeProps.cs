using System.Windows.Media;
using System.Windows;
using System.Windows.Media.Animation;

namespace BlackPinkTheme.Core
{
    public class ThemeProps
    {
        public static readonly DependencyProperty BackgroundProperty = DependencyProperty.RegisterAttached("Background", typeof(Brush), typeof(ThemeProps), new PropertyMetadata(null, OnBackgroundPropertyChanged));
        public static readonly DependencyProperty ForegroundProperty = DependencyProperty.RegisterAttached("Foreground", typeof(Brush), typeof(ThemeProps), new PropertyMetadata(null, OnForegroundPropertyChanged));
        public static readonly DependencyProperty BorderBrushProperty = DependencyProperty.RegisterAttached("BorderBrush", typeof(Brush), typeof(ThemeProps), new PropertyMetadata(null, OnBorderBrushPropertyChanged));
        public static readonly DependencyProperty FillProperty = DependencyProperty.RegisterAttached("Fill", typeof(Brush), typeof(ThemeProps), new PropertyMetadata(null, OnFillPropertyChanged));

        public static Brush GetBackground(DependencyObject obj)
        {
            return (Brush)obj.GetValue(BackgroundProperty);
        }

        public static void SetBackground(DependencyObject obj, Brush value)
        {
            obj.SetValue(BackgroundProperty, value);
        }

        private static void OnBackgroundPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is FrameworkElement element && e.NewValue is SolidColorBrush newBrush)
            {
                AnimateBrushProperty(element, newBrush, BackgroundProperty.Name);
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

        private static void OnForegroundPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is FrameworkElement element && e.NewValue is SolidColorBrush newBrush)
            {
                AnimateBrushProperty(element, newBrush, ForegroundProperty.Name);
            }
        }

        public static Brush GetBorderBrush(DependencyObject obj)
        {
            return (Brush)obj.GetValue(BorderBrushProperty);
        }

        public static void SetBorderBrush(DependencyObject obj, Brush value)
        {
            obj.SetValue(BorderBrushProperty, value);
        }

        private static void OnBorderBrushPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is FrameworkElement element && e.NewValue is SolidColorBrush newBrush)
            {
                AnimateBrushProperty(element, newBrush, BorderBrushProperty.Name);
            }
        }

        public static Brush GetFill(DependencyObject obj)
        {
            return (Brush)obj.GetValue(FillProperty);
        }

        public static void SetFill(DependencyObject obj, Brush value)
        {
            obj.SetValue(FillProperty, value);
        }


        private static void OnFillPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is FrameworkElement element && e.NewValue is SolidColorBrush newBrush)
            {
                AnimateBrushProperty(element, newBrush, FillProperty.Name);
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