using MahApps.Metro.Controls;
using System;
using System.Globalization;
using System.Threading;
using System.Windows;

namespace ImgTool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public void loadTool()
        {
            this.Hide();
            (new OptionsWindow()).Show();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("tr");
            loadTool();
        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en");
            loadTool();
        }

        private void button_Copy1_Click(object sender, RoutedEventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("de");
            loadTool();
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }
    }
}
