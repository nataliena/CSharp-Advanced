using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
  public  class Cat : Animal
    {
        public Cat(string name, int age, string color,bool isLazy)
            :base(name,age,color)
        {
            this.IsLazy = isLazy;
        }

        public override void Print()
        {
            Console.WriteLine($"{this.Name} {this.Age} {this.Color} ,Is Lazy: {this.IsLazy} ");

        }
        public bool IsLazy { get; set; }
        public void Meow()
        {
            Console.WriteLine("Meow");
        }
    }
}
