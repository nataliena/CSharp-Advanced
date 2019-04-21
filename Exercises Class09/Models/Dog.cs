using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Dog : Animal
    {
        public Dog(string race, string name, int age, string color)
            :base(name, age, color)
        {
            Race = race;
        }

        public string Race { get; set; }
        public override void Print()
        {
            Console.WriteLine($"{this.Name} {this.Age} {this.Color} {this.Race}"); 

        }
        public  void  Bark (){


            Console.WriteLine("Bark Bark");
        }

    }
}
