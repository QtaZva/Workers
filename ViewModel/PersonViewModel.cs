﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Workers.Helper;
using Workers.Model;
using Workers.View;


namespace Workers.ViewModel
{
    public class PersonViewModel : INotifyPropertyChanged
    {
        public Person SelectedPerson;
        public PersonViewModel()
        {
            ListPerson = new ObservableCollection<Person>();
            ListPerson = GetPersons();
        }
        public ObservableCollection<Person> GetPersons()
        {
            using (var context = new CompanyEntities())
            {
                var query = from per in context.Persons
                .Include("Role")
                            orderby per.LastName
                            select per;
                if (query.Count() != 0)
                {
                    foreach (var p in query)
                    {
                        ListPerson.Add(p);
                    }
                }
            }
            return ListPerson;
        }
        readonly string path = @"C:\Users\Alex\source\Project\WpfApplDemo2018_Json\WpfApplDemo2018\DataModels\ Person.json";
        string _jsonPersons = String.Empty;
        public string Error { get; set; }
        public ObservableCollection<Person> LoadPerson()
        {
            _jsonPersons = File.ReadAllText(path);
            if (_jsonPersons != null)
            {
                ListPerson = JsonConvert.DeserializeObject<ObservableCollection<Person>>(_jsonPersons);
                return ListPerson;
            }
            else
            {
                return null;
            }
        }
        private void SaveChanges(ObservableCollection<Person> listPersons)
        {
            var jsonPerson = JsonConvert.SerializeObject(listPersons);
            try
            {
                using (StreamWriter writer = File.CreateText(path))
                {
                    writer.Write(jsonPerson);
                }
            }
            catch (IOException e)
            {
                Error = "Ошибка записи json файла /n" + e.Message;
            }
        }
        public ObservableCollection<Person> ListPerson { get; set; } =
       new ObservableCollection<Person>();
        //public ObservableCollection<PersonDpo> ListPersonDpo
        //{
        //    get;
        //    set;
        //} = new ObservableCollection<PersonDpo
        //public ObservableCollection<PersonDpo> GetListPersonDpo()
        //{
        //    foreach (var person in ListPerson)
        //    {
        //        PersonDpo p = new PersonDpo();
        //        p = p.CopyFromPerson(person);
        //        ListPersonDpo.Add(p);
        //    }
        //    return ListPersonDpo;
        //}
        /// <summary>
        /// Нахождение максимального Id в коллекции данных
        /// </summary>
        /// <returns></returns>
        public int MaxId()
        {
            int max = 0;
            foreach (var r in this.ListPerson)
            {
                if (max < r.Id)
                {
                    max = r.Id;
                };
            }
            return max;
        }
        #region AddPerson
        /// <summary>
        /// добавление сотрудника
        /// </summary>
        private RelayCommand _addPerson;
        /// <summary>
        /// добавление сотрудника
        /// </summary>
        public RelayCommand AddPerson
        {
            get
            {
                return _addPerson ??
                (_addPerson = new RelayCommand(obj =>
                {
                    Person newPerson = new Person
                    {
                        Birthday = DateTime.Now
                    };
                    WindowNewEmployee wnPerson = new WindowNewEmployee
                    {
                        Title = "Новый сотрудник",
                        DataContext = newPerson
                    };
                    wnPerson.ShowDialog();
                    if (wnPerson.DialogResult == true)
                    {
                        using (var context = new CompanyEntities())
                        {
                            try
                {
                                Person ord = context.Persons.Add(newPerson);
                                context.SaveChanges();
                                ListPerson.Clear();
                                ListPerson = GetPersons();
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

        #endregion
        #region EditPerson
        /// команда редактирования данных по сотруднику
        private RelayCommand _editPerson;
        public RelayCommand EditPerson
        {
            get
            {
                return _editPerson ??
                (_editPerson = new RelayCommand(obj =>
                {
                    Person editPerson = SelectedPerson;
                WindowNewEmployee wnPerson = new WindowNewEmployee()
                {
                    Title = "Редактирование данных сотрудника",
                    DataContext = editPerson
                };
                    wnPerson.ShowDialog();
                    if (wnPerson.DialogResult == true)
                    {
                        using (var context = new CompanyEntities())
                        {
                            Person person = context.Persons.Find(editPerson.Id);
                            if (person != null)
                            {
                                if (person.RoleId != editPerson.RoleId)
                                    person.RoleId = editPerson.RoleId;
                                if (person.FirstName != editPerson.FirstName)
                                    person.FirstName = editPerson.FirstName;
                                if (person.LastName != editPerson.LastName)
                                    person.LastName = editPerson.LastName;
                                if (person.Birthday != editPerson.Birthday)
                                    person.Birthday = editPerson.Birthday;
                                try
                                {
                                    context.SaveChanges();
                                    ListPerson.Clear();
                                    ListPerson = GetPersons();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("\nОшибка редактирования данных!\n"
                    + ex.Message, "Предупреждение");
                                }
                            }
                        }
                    }
                    else
                    {
                        ListPerson.Clear();
                        ListPerson = GetPersons();
                    }
                }, (obj) => SelectedPerson != null && ListPerson.Count >
               0));
            }
        }

        #endregion
        #region DeletePerson
        /// команда удаления данных по сотруднику
        private RelayCommand _deletePerson;
        public RelayCommand DeletePerson
        {
            get
            {
                return _deletePerson ??
                (_deletePerson = new RelayCommand(obj =>
                {
                    Person delPerson = SelectedPerson;
                    using (var context = new CompanyEntities())
                    {
                        // Поиск в контексте удаляемого автомобиля
                        Person person = context.Persons.Find(delPerson.Id);
                        if (person != null)
                        {
                            MessageBoxResult result = MessageBox.Show("Удалить данные по сотруднику: \nФамилия: " + person.LastName + "\nИмя: " + person.FirstName,
            "Предупреждение", MessageBoxButton.OKCancel);
                            if (result == MessageBoxResult.OK)
                            {
                                try
                                {
                                    context.Persons.Remove(person);
                                    context.SaveChanges();
                                    ListPerson.Remove(delPerson);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("\nОшибка удаления данных!\n" +
                    ex.Message, "Предупреждение");
                                }
                            }
                        }
                    }
                }, (obj) => SelectedPerson != null && ListPerson.Count >
               0));
            }
        }

        #endregion
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
