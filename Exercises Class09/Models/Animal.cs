using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public abstract class Animal
    {
        public  string Name { get; set; }
        private  int _age;

        public  int Age
        {
            get
            {
                return _age;
            }

            set
            {
                _age = value;
            }
        }
        public  string Color { get; set; }
        public abstract void Print();
        public Animal (string name,int age, string color)
        {
            this.Name = name;
            this.Age = age;
            this.Color = color;
        }
      
    }
}
