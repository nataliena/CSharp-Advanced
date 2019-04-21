using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public class Subscriber3
    {
        public void Subscriber3Mess(string message)
        {
            Console.WriteLine($"Subscriber3  got the message {message} through Facebook");
        }
    }
}
