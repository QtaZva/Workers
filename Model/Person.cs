using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workers.Helper;
using Workers.ViewModel;

namespace Workers.Model
{
    /// <summary>
    /// Класс сотрудник
    /// </summary>
    public class Person
    {
        public int Id { get; set; } // код
        public int RoleId { get; set; } // код должности
         public string FirstName { get; set; } // имя
        public string LastName { get; set; } // фамилия
        public DateTime Birthday { get; set; } // дата рождения
    }
}
