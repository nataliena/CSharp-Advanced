using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public class Admin: Person
    {

        public Admin(string firstName, string lastName, string user, string password)
           : base(Role.Admin, firstName, lastName, user, password) { }
    }
}
