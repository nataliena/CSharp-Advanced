using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
  public static class Emethods
    {
        
        public static string GetFirstLetter(this string letter  )
        {
            return letter.Substring(0, 1);
        }

        public static string GetLastLetter(this string letter)
        {
            return letter.Substring(letter.Length - 1, 1); ;
        }
        public static bool isEven(this int integer)
        {
            if(integer %2==0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static List<T> FirstInt<T>(this List<T> list, int n)
        {
            return list.Take(n).ToList();
        }


    }
}
