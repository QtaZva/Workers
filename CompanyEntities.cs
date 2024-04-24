﻿using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Windows;
using Workers.Helper;
using Workers.View;

namespace Workers
{
    public class CompanyEntities : DbContext
    {
        public CompanyEntities()
            : base("name=CompanyEntities")
        {
        }
        private ObservableCollection<Role> GetRoles()
        {
            using (var context = new CompanyEntities())
            {
                var query = from role in context.Roles
                            orderby role.NameRole
                            select role;
                if (query.Count() != 0)
                {
                    foreach (var c in query)
                        ListRole.Add(c);
                }
            }
            return ListRole;
        }
        private RelayCommand _addRole;
        public RelayCommand AddRole
        {
            get
            {
                return _addRole ??
                (_addRole = new RelayCommand(obj =>
                {
                    Role newRole = new Role();
                    WindowNewRole wnRole = new WindowNewRole
                    {
                        Title = "Новая должность",
                        DataContext = newRole,
                    };
                    wnRole.ShowDialog();
                    if (wnRole.DialogResult == true)
                    {
                        using (var context = new CompanyEntities())
                        {
                            try
                            {
                                context.Roles.Add(newRole);
                context.SaveChanges();
                                ListRole.Clear();
                                ListRole = GetRoles();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("\nОшибка добавления данных!\n" +
                ex.Message, "Предупреждение");
                            }
                        }
                    }
                }, (obj) => true));
            }
        }
        private RelayCommand _editRole;
        public RelayCommand EditRole
        {
            get
            {
                return _editRole ??
                (_editRole = new RelayCommand(obj =>
                {
                    Role editRole = SelectedRole;
                    WindowNewRole wnRole = new WindowNewRole
                    {
                        Title = "Редактирование должности",
                        DataContext = editRole,
                    };
                    wnRole.ShowDialog();
                    if (wnRole.DialogResult == true)
                    {
                        using (var context = new CompanyEntities())
                {
                            Role role = context.Roles.Find(editRole.Id);
                            if (role.NameRole != editRole.NameRole)
                                role.NameRole = editRole.NameRole.Trim();
                            try
                            {
                                context.SaveChanges();
                                ListRole.Clear();
                                ListRole = GetRoles();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("\nОшибка редактирования данных!\n" +
                ex.Message, "Предупреждение");
                            }
                        }
                    }
                    else
                    {
                        ListRole.Clear();
                        ListRole = GetRoles();
                    }
                }, (obj) => SelectedRole != null && ListRole.Count > 0));
            }
        }

    }
}