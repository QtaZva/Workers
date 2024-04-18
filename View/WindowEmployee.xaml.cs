using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;
using Workers.Helper;
using Workers.Model;
using Workers.ViewModel;

namespace Workers.View
{
    /// <summary>
    /// Логика взаимодействия для WindowEmployee.xaml
    /// </summary>
    public partial class WindowEmployee : Window
    {
        private PersonViewModel vmPerson = new PersonViewModel();
        private RoleViewModel vmRole;
        private ObservableCollection<PersonDPO> personsDPO;
        private List<Role> roles;
        public WindowEmployee()
        {
            InitializeComponent();
            vmPerson = new PersonViewModel();
            vmRole = new RoleViewModel();
            roles = vmRole.ListRole.ToList();
            // Формирование данных для отображения сотрудников с должностями
            // на базе коллекции класса ListPerson<Person> 
            personsDPO = new ObservableCollection<PersonDPO>();
            foreach (var person in vmPerson.ListPerson)
            {
                PersonDPO p = new PersonDPO();
                p = p.CopyFromPerson(person);
                personsDPO.Add(p);
            }
            lvEmployee.ItemsSource = personsDPO;
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowNewEmployee wnEmployee = new WindowNewEmployee
            {
                Title = "Новый сотрудник",
                Owner = this
            };
            // формирование кода нового собрудника
            int maxIdPerson = vmPerson.MaxId() + 1;
            PersonDPO per = new PersonDPO
            {
                Id = maxIdPerson,
                Birthday = DateTime.Now
            };
            wnEmployee.DataContext = per;
            wnEmployee.CbRole.ItemsSource = roles;
            if (wnEmployee.ShowDialog() == true)
            {
                Role r = (Role)wnEmployee.CbRole.SelectedValue;
                per.Role = r.NameRole;
                personsDPO.Add(per);
                // добавление нового сотрудника в коллекцию ListPerson<Person> 
                Person p = new Person();
                p = p.CopyFromPersonDPO(per);
                vmPerson.ListPerson.Add(p);
            }
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}