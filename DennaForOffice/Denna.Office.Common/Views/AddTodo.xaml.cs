using Denna.Office.Common.Domain;
using Denna.Office.Common.Services.Todos;
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
    /// Interaction logic for AddTodo.xaml
    /// </summary>
    public partial class AddTodo : UserControl
    {
        TodoService _service;
        public AddTodo()
        {
            _service = new TodoService();
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainPage.current._NavigationFrame.Navigate(new TodoList());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            var start = datepic.Value;

            if (Title.Text == "")
            {
                ErrorText.Text = "Please set a title for this alarm.";
                return;
            }


            if (start < DateTime.Now)
            {
                ErrorText.Text = "Can't set a time in past.";
                return;
            }
            var todo = new Todo()
            {
                Subject = Title.Text,
                Detail = Details.Text,
                StartTime = start,
                Notify = 0,
                Status = 2
            };
            _service.AddTodo(todo);

            MainPage.current._NavigationFrame.Navigate(new TodoList());
        }
    }
}
