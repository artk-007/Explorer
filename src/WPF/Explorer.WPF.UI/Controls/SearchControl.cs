using System.Windows;
using System.Windows.Controls;

namespace Explorer.WPF.UI
{
    /// <summary>
    /// Логика взаимодействия для SearchControl.xaml
    /// </summary>
    public class SearchControl : TextBox
    {
        public static readonly DependencyProperty ButtonsContentProperty = DependencyProperty.Register(
            nameof(ButtonsContent), typeof(UIElement), typeof(SearchControl), new PropertyMetadata(default(UIElement)));

        public UIElement ButtonsContent
        {
            get => (UIElement) GetValue(ButtonsContentProperty);
            set => SetValue(ButtonsContentProperty, value);
        }

        #region Static Constructor
        static SearchControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SearchControl),
                new FrameworkPropertyMetadata(typeof(SearchControl)));
        }

        #endregion

    }
}
