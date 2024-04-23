using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Workers.Model;

namespace Workers.ViewModel
{
    public class RoleViewModel : INotifyPropertyChanged
    {
        private Role selectedRole;
        public Role SelectedRole
        {
            get
            {
                return selectedRole;
            }
            set
            {
                selectedRole = value;
                OnPropertyChanged("SelectedRole");
            }
        }
        public ObservableCollection<Role> ListRole { get; set; } = new
       ObservableCollection<Role>();
        public RoleViewModel()
        {
            this.ListRole.Add(new Role
            {
                Id = 1,
                NameRole = "Директор"
            });
            this.ListRole.Add(new Role
            {
                Id = 2,
                NameRole = "Бухгалтер"
            });
            this.ListRole.Add(new Role
            {
                Id = 3,
                NameRole = "Менеджер"
            });
        }
        public int MaxId()
        {
            int max = 0;
            foreach (var r in this.ListRole)
            {
                if (max < r.Id)
                {
                    max = r.Id;
                };
            }
            return max;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
