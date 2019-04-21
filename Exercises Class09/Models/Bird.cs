using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
  public  class Bird:Animal
    {
        public Bird(string name, int age, string color,bool isWild)
            :base(name,age,color)
        {
            IsWild = isWild;
        }

        public bool IsWild { get; set; }

        public override void  Print()
        {
            Console.WriteLine($"{this.Name} {this.Age} {this.Color} ,Is Wild:{this.IsWild}" ); ;

        }
        public void FlySouth ()

        {
            if(IsWild)
            {
                Console.WriteLine($"{this.Name} is flying South");
            }
            else 
            {
                Console.WriteLine($"{this.Name} is domesticated Bird");
            }

        }
    }
}
