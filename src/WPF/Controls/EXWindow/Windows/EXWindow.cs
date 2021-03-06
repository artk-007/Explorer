using System.ComponentModel;
using System.Windows;
using System.Windows.Input;


namespace EXWindow
{
    public class ExWindow : Window
    {
        #region Dependency Properties

        public static readonly DependencyProperty CloseCommandProperty = DependencyProperty.Register(
            nameof(CloseCommand), typeof(ICommand), typeof(ExWindow), new PropertyMetadata(default(ICommand)));


        public static readonly DependencyProperty CollapseCommandProperty = DependencyProperty.Register(
            nameof(CollapseCommand), typeof(ICommand), typeof(ExWindow), new PropertyMetadata(default(ICommand)));


        public static readonly DependencyProperty ExpandCommandProperty = DependencyProperty.Register(
            nameof(ExpandCommand), typeof(ICommand), typeof(ExWindow), new PropertyMetadata(default(ICommand)));

        public static readonly DependencyProperty ToolBarContentProperty = DependencyProperty.Register(
            "ToolBarContent", typeof(FrameworkElement), typeof(ExWindow), new PropertyMetadata(default(FrameworkElement)));



        #endregion

        #region Public Properties

        public ICommand CloseCommand
        {
            get => (ICommand)GetValue(CloseCommandProperty);
            set => SetValue(CloseCommandProperty, value);
        }

        public ICommand CollapseCommand
        {
            get => (ICommand)GetValue(CollapseCommandProperty);
            set => SetValue(CollapseCommandProperty, value);
        }

        public ICommand ExpandCommand
        {
            get => (ICommand)GetValue(ExpandCommandProperty);
            set => SetValue(ExpandCommandProperty, value);
        }

        public FrameworkElement ToolBarContent
        {
            get => (FrameworkElement)GetValue(ToolBarContentProperty);
            set => SetValue(ToolBarContentProperty, value);
        }

        #endregion

        #region Static Constructor

        static ExWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ExWindow),
                new FrameworkPropertyMetadata(typeof(ExWindow)));
        }

        #endregion

        #region Constructor

        public ExWindow()
        {
            
            CloseCommand = new DelegateCommand(OnClose);
            CollapseCommand = new DelegateCommand(OnCollapse);
            ExpandCommand = new DelegateCommand(OnExpand);

            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            var behavior = new WindowResizeFixerBehavior();
            behavior.Attach(this);

        }






        #endregion

        #region Protected Methods

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            Application.Current.Shutdown();
        }


        #endregion

        #region Private Methods

        private void OnClose(object obj)
        {
            Close();
        }


        private void OnCollapse(object obj)
        {
            WindowState = WindowState.Minimized;
        }

        private void OnExpand(object obj)
        {
            if (WindowState == WindowState.Normal)
            {
                WindowState = WindowState.Maximized;
            }
            else if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
            }
        }

        #endregion







    }
}
