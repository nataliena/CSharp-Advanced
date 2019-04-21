using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
  public  class GenericMethods
    {
        public void Print<T>(List<T>items)
        {
            foreach (var o in items)
            {
                Console.Write($"{o}, ");
            }
        }
        public void PrintAllAnimals<T>(List<T> animals)
            where T:Animal
        {
            foreach (var animal in animals)
            {
                animal.Print();
            }
        }
    }
}
