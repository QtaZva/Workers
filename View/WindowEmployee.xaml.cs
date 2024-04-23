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

        private PersonViewModel vmPerson = new PersonViewModel();
        private RoleViewModel vmRole;
        private ObservableCollection<PersonDpo> personsDPO;
        private List<Role> roles;
        public WindowEmployee()
        {
            InitializeComponent();
            DataContext = new PersonViewModel();
            vmPerson = new PersonViewModel();
            vmRole = new RoleViewModel();
            roles = vmRole.ListRole.ToList();
            personsDPO = new ObservableCollection<PersonDpo>();
            foreach (var person in vmPerson.ListPerson)
            {
                PersonDpo p = new PersonDpo();
                p = p.CopyFromPerson(person);
                personsDPO.Add(p);
            }
            lvEmployee.ItemsSource = personsDPO;
        }
    }
}