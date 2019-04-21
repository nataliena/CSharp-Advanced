using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
  public  class Subscriber2
    {
        public void Subscriber2Mess(string message)
        {
            Console.WriteLine($"Subscriber2  got the message {message} through E-mail");
        }
    }
}
