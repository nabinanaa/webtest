using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Web.WebView2.Core;
using KeyEventArgs = System.Windows.Forms.KeyEventArgs;
using Microsoft.Web.WebView2.Wpf;

namespace WpfApp4
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    /// 
    
    public partial class MainWindow : Window
    {
        bool _isNavigating = false;

        public MainWindow()
        {
            InitializeComponent();
            
        }
        //private void Textblock(object sender, NavigationEventArgs e)
        //{
        //    addressBar.Text = webView.CoreWebView2.Source.ToString();
        //}
        //private void Textbox(object sender, RoutedEventArgs e)
        //{
        //    if (webView != null && webView.CoreWebView2 != null)
        //    {
        //        webView.CoreWebView2.Navigate(addressBar.Text);
        //    }
        //}
        void GoToPageCmdCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = webView != null && !_isNavigating;
        }

        async void GoToPageCmdExecuted(object target, ExecutedRoutedEventArgs e)
        {
            await webView.EnsureCoreWebView2Async();
            webView.CoreWebView2.Navigate((string)e.Parameter);
        }

        private void ForwardButton_Click(object sender, RoutedEventArgs e)
        {
            webView.CoreWebView2.GoForward();
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            webView.CoreWebView2.GoBack();
        }
        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {

            webView.CoreWebView2.Reload();
        }
   

    }
}
