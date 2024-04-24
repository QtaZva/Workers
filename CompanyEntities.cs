using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;

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
    }
}