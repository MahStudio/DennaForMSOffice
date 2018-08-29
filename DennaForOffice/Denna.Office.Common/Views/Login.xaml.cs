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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : UserControl
    {
        public Login()
        {
            InitializeComponent();
        }

        private async void login_Click(object sender, RoutedEventArgs e)
        {
            var _usrsvc = new UserService();
            try
            {
                if (usr.Text == null && pass.Password == null)
                    throw new Exception("Please fill blank fields");
                
                await _usrsvc.Login(usr.Text.Replace(" ", ""), pass.Password);
            }
            catch (Exception ex)
            {
            }
        }
    }
}
