using Denna.Office.Common.Services.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Denna.Office.Common.Views
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
            _NavigationFrame.Navigate(new TodoList());
            //try
            //{
            //    if (!new UserService().IsUserLoggenIn())
            //        _NavigationFrame.Navigate(new Login());
            //    else
            //        _NavigationFrame.Navigate(new TodoList());
            //}
            //catch
            //{
            //    _NavigationFrame.Navigate(new Login());
            //}

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
