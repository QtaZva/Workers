using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Workers.Helper;
using Workers.Model;
using Workers.ViewModel;
using static System.Net.Mime.MediaTypeNames;

namespace Workers.View
{
    /// <summary>
    /// Логика взаимодействия для WindowEmployee.xaml
    /// </summary>
    public partial class WindowEmployee : Window
    {
        private RoleViewModel vmRole;
        private List<Role> roles;
        public WindowEmployee()
        {
            InitializeComponent();
            vmRole = new RoleViewModel();
            roles = vmRole.ListRole.ToList();

            DataContext = new PersonViewModel();
        }

        private void lvEmployee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView s = (ListView)sender;
            Person v = (Person)s.SelectedItem;

            ((PersonViewModel)DataContext).SelectedPerson = v;
        }
    }
}