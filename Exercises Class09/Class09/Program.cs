using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;



namespace Class09
{
    class Program
    {
        public delegate bool NewDelegate(string s1, string s2);
        public static void StringMagic(string string1, string string2, NewDelegate delegate1)
            {
           
            Console.WriteLine($"{string1} , {string2}, {delegate1(string1, string2)}");
            }
        static void Main(string[] args)
        {
            #region MANY EXERCISES

            /* 1) Create an abstract class Animal and Dog, Cat and Bird classes inheriting it
                       Animal has
           Name
           Age(custom getter and setter) - Can't be set below 0 or over 175
           Color
           Print( abstract method ) - Prints all properties of the Animal
           Dog has
           Race
           Bark(method ) - Prints BARK BARK in console
           Cat has
           IsLazy
           Meow(method ) - Prints MEOW in console
           Bird has
           IsWild
           FlySouth(method ) - Print's in the console that is flying south if IsWild is true or print's that it's a domesticated bird if its false
           Create Lists of:
           3 dogs
           3 cats
           3 birds
           Use LINQ to:
           Get all dogs of a particular race
           Get the last lazy cat
           Get the all wild birds that are younger than 3 and are ordered by their name
           2) Create extension methods:
           GetFirstLetter - Method on String that returns the first letter of a string
           LastLetter - Method on String that returns the last letter of a string
           IsEven - Method on Int that checks if its even and returns bool
           GetNfromList - Generic method that accepts an int and returns the first N(input ) items from that list
           3) Create generic methods:
           PrintList - Method that prints any list of items in the console(strings, bools ints etc. )
           PrintAnimals - Method that prints any list with Animals(print method) in the console(Dog, Cat Bird and any Animal )
           4) Create a delegate that accepts two strings and returns bool
           Create a method called StringMagic that requires the delegate as parameter and that executes the delegate and prints the 2 strings and the result
           Call the StringMagic method to compare 2 strings length
           Call the StringMagic method to compare if the 2 strings start on the same character
           Call the StringMagic method to compare if the 2 strings end on the same character
           5) Create a publisher class called Trainer that:
           Has delegate that returns void and accepts one string parameter
           Has method SendMessage - Accepts a message and sends it to all subscribers in the event
           Has method ComposeMessage - Accepts 3 parameters, trainerName, groupNumber, message.This method will Thread.Sleep(3000) and then call a method SendMessage with a string that says: {trainerName
               }
               informs G { groupNumber }: {message
           }
           Create 3 Subscriber classes with one method in each that implements the delegate from the publisher
           First subscriber will write that it got the message through SMS
           Second subscriber will write that it got the message through E-Mail
           Third subscriber will write that it got the message through Facebook
           Create instances of the publisher and 3 subscribers and make the publisher send a message to all 3 of them*/

            #endregion MANY EXERCISES

            List<Dog> dogs = new List<Dog>()
            {
                new Dog("race1","sarko", 3, "red"),
                new Dog("race2","sarko1", 4, "blue"),
                new Dog("race3","sarko2", 5, "pink"),
                new Dog("race4","sarko3", 6, "black"),
            };

            List<Cat> cats = new List<Cat>()
            {
                new Cat("maca1",2,"white",true),
                new Cat("maca2",5,"red",false),
                new Cat("maca3",3,"blue",true),
                new Cat("maca4",7,"yellow",false),
            };
            List<Bird> birds = new List<Bird>()
            {
                new Bird("bird1",3,"white",false),
                new Bird("bird2",3,"red",true),
                new Bird("bird3",1,"brown",false),
                new Bird("bird4",2,"blue",true),
                

            };
            //var particularRace = dogs
            //                .Where(x => x.Race == "race1")
            //                .ToList();

            //foreach (var item in particularRace)
            //{
            //    item.Print();
            //}

            //var lastlazyCat = cats
            //                 .Where(x => x.IsLazy == true)
            //                 .LastOrDefault();

            //Console.WriteLine(lastlazyCat.Name);
            //List<Bird> allBirds = birds
            //                  .Where(x => x.IsWild == true && x.Age < 3)
            //                  .OrderBy(x => x.Name)
            //                  .ToList();

            //foreach (var item in allBirds)
            //{
            //    item.Print();
            //}
            //string s1 = "natasha";
            //Console.WriteLine(s1.GetFirstLetter());
            //string s2 = "Natasha is developer";
            //Console.WriteLine(s2.GetLastLetter());
            //int integer = 32;
            //Console.WriteLine(integer.isEven());

            //var c = dogs.FirstInt(1);
            //foreach (var item in c)
            //{
            //    Console.WriteLine(item.Name);
            //}


            //List<int> integers = new List<int>() { 1, 2, 3, 4, 5 };
            //List<string> strings = new List<string>() { "Natasha", "Goran", "Danilo","Mateo" };
            //GenericMethods g = new GenericMethods();
            //g.Print(integers);
            //g.Print(strings);
            //g.PrintAllAnimals(dogs);
            //g.PrintAllAnimals(birds);
            //g.PrintAllAnimals(cats);

            //string str1 = "Natasha Andova";
            //string str2 = "Natasha Andonova";


            //StringMagic(str1, str2, (x, y) =>
            //{
            //    if (x.Length > y.Length)
            //    {
            //        return true;
            //    }
            //    return false;
            //});
            //StringMagic(str1, str2, (x, y) =>
            //{
            //    if (x.ToCharArray().First() == y.ToCharArray().First())
            //    {
            //        return true;
            //    }
            //    return false;
            //});
            //StringMagic(str1, str2, (x, y) =>
            //{
            //    if (x.ToCharArray().Last() == y.ToCharArray().Last())
            //    {
            //        return true;
            //    }
            //    return false;
            //});
            Publisher p1 = new Publisher();
            Subscriber1 sub1 = new Subscriber1();
            Subscriber2 sub2 = new Subscriber2();
            Subscriber3 sub3 = new Subscriber3();

            

            p1.EventHandler += sub1.Subscriber1Mess;
            p1.EventHandler += sub2.Subscriber2Mess;
            p1.EventHandler += sub3.Subscriber3Mess;
            p1.ComposeMessage("Risto Panchevski", 1, "Let's talk about C# Adv");






            Console.ReadLine();

        }
    }
}
