﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
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
using Workers.Model;
using Workers.ViewModel;

namespace Workers.View
{
    /// <summary>
    /// Логика взаимодействия для WindowRole.xaml
    /// </summary>
    public partial class WindowRole : Window
    {
        RoleViewModel vmRole = new RoleViewModel();
        public WindowRole()
        {
            InitializeComponent();
            lvRole.ItemsSource = vmRole.ListRole;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowNewRole wnRole = new WindowNewRole
            {
                Title = "Новая должность",
                Owner = this
            };
            // формирование кода новой должности
            int maxIdRole = vmRole.MaxId() + 1;
            Role role = new Role
            {
                Id = maxIdRole
            };
            wnRole.DataContext = role;
            if (wnRole.ShowDialog() == true)
            {
                vmRole.ListRole.Add(role);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            WindowNewRole wnRole = new WindowNewRole
            {
                Title = "Редактирование должности",
                Owner = this
            };
            Role role = lvRole.SelectedItem as Role;
            if (role != null)
            {
                Role tempRole = role.ShallowCopy();
                wnRole.DataContext = tempRole;
                if (wnRole.ShowDialog() == true)
                {
                    // сохранение данных
                    role.NameRole = tempRole.NameRole;
                    lvRole.ItemsSource = null;
                    lvRole.ItemsSource = vmRole.ListRole;
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать должность для редактированния",
                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
