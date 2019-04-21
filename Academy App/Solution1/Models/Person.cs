using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Person
    {
        public  Role Role  { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public Person(Role role, string firstName, string lastName, string user, string password)
        {
            this.Role = role;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.User = user;
            this.Password = password;
             

        }
        
      
        public bool CheckUser(string user) => User == user;

        public bool CheckPassword(string password) => Password == password;
        public string FullName() => $"{FirstName} {LastName}";
        

    }
}
