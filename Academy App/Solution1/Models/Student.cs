using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public class Student:Person
    {
        public Subject CurrentSubject { get; set; }
        public Dictionary<Subject,byte> Subjects { get; set; }
        public Student (string firstName,string lastName, string user,string password, Dictionary<Subject,byte> Subjects)
                       :base(Role.Student,firstName,lastName,user,password)
                         {
                        this.Subjects = Subjects;
                         }
       

        public string StudentInfo()
        {
            string info = "";
            foreach (var item in Subjects)
            {
                info += $"Subject :{item.Key.Name}: Grade:{item.Value} \n";
            }
            return info;
        }
    }
}
