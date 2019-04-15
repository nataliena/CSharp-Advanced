using System;
using System.Collections.Generic;
using System.Linq;
using LinqExercise.Models;
using LinqExercise.Services;

namespace LinqExercise
{
    class Program
    {

        static void Main(string[] args)
        {
            var people = PersonService.GetAllPeople();

            var dogs = DogService.GetAllDogs();

            #region Exercises

            //==============================
            // TODO LINQ expressions :)
            // Your turn guys...
            //==============================

            //PART 1
            // 1. Take person Cristofer and add Jack, Ellie, Hank and Tilly as his dogs.
            Console.WriteLine("------------------------Task 1-----------------------------");
            Person cristofer = people.FirstOrDefault(x => x.FirstName == "Cristofer");
            if (cristofer != null)
            {
                //cristofer.Dogs = new List<Dog>();
                //Dog jack = dogs.FirstOrDefault(x => x.Name == "Jack");
                //cristofer.Dogs.Add(jack);
                cristofer.Dogs = dogs.Where(x => x.Name == "Jack" || x.Name == "Ellie" || x.Name == "Hank" || x.Name == "Tilly").ToList();

                cristofer.PrintAllDogs();

            }




            // 2. Take person Freddy and add Oscar, Toby, Chanel, Bo and Scout as his dogs.
            Console.WriteLine("--------------------Task 2------------------------------");
            Person freddy = people.FirstOrDefault(x => x.FirstName == "Freddy");
            if (freddy != null)
            {

                freddy.Dogs = dogs.Where(x => x.Name == "Oscar" || x.Name == "Toby" || x.Name == "Chanel" || x.Name == "Bo" || x.Name == "Scout").ToList();
                freddy.PrintAllDogs();
            }

            // 3. Add Trixie, Archie and Max as dogs from Erin.
            Console.WriteLine("--------------------Task 3------------------------------");
            Person erin = people.FirstOrDefault(x => x.FirstName == "Erin");
            if (erin != null)
            {
                erin.Dogs = dogs.Where(x => x.Name == "Trixie" || x.Name == "Archie" || x.Name == "Max").ToList();


            }
            erin.PrintAllDogs();


            // 4. Give Abby and Shadow to Amelia.
            Console.WriteLine("--------------------Task 4------------------------------");
            Person amelia = people.FirstOrDefault(x => x.FirstName == "Amelia");
            if (amelia != null)
            {
                amelia.Dogs = dogs.Where(x => x.Name.Equals("Abby") || x.Name.Equals("Shadow")).ToList();

            }

            amelia.PrintAllDogs();

            Console.WriteLine("--------------------Task 5------------------------------");
            // 5. Take person Larry and Zoe, Ollie as his dogs.
            Person larry = people.FirstOrDefault(x => x.FirstName == "Larry");
            if (larry != null)
            {
                //larry.Dogs = new List<Dog>();   
                //Dog zoe = dogs.FirstOrDefault(x => x.Name == "Zoe");
                //Dog ollie = dogs.FirstOrDefault(x => x.Name == "Ollie");
                //larry.Dogs.Add(zoe);
                //larry.Dogs.Add(ollie);

                larry.Dogs = dogs.Where(x => x.Name == "Zoe" || x.Name == ("Ollie")).ToList();
                larry.PrintAllDogs();

            }
            // 6. Add all retrievers to Erika.
            Console.WriteLine("--------------------Task 6------------------------------");
            Person erika = people.FirstOrDefault(x => x.FirstName == "Erika");
            if (erika != null)
            {
                erika.Dogs = dogs.Where(x => x.Race == Race.Retriever).ToList();
            }
            erika.PrintAllDogs();


            // 7. Erin has Chet and Ava and now give Diesel to August thah previously has just Rigby
            Console.WriteLine("--------------------Task 7------------------------------");

            //Dog chet = dogs.FirstOrDefault(x => x.Name == "Chet");
            //Dog ava = dogs.FirstOrDefault(x => x.Name == "Ava");
            //erin.Dogs.Add(chet);
            //erin.Dogs.Add(ava);
            erin.Dogs.Add(dogs.Where(x => x.Name == "Chet" || x.Name == "Ava").FirstOrDefault());
            erin.PrintAllDogs();

            //PART 2 - LINQ
            Console.WriteLine("--------------------Task 1------------------------------");
            // 1. Find and print all persons firstnames starting with 'S', ordered by age - DESCENDING ORDER.
            List<Person> firstNamesStartsS = people.Where(x => x.FirstName.StartsWith("S"))
                                            .OrderByDescending(x => x.Age)
                                            .ToList();

            PrintListPerson(firstNamesStartsS);



            Console.WriteLine("--------------------Task 2------------------------------");
            // 2. Find and print all brown dogs names and ages older than 3 years, ordered by age - ASCENDING ORDER.
            List<Dog> dogByColor = dogs
                                .Where(x => x.Color == Color.Brown && x.Age > 3)
                                .OrderByDescending(x => x.Age).ToList();
            dogByColor.Reverse();

            PrintListDog(dogByColor);

            Console.WriteLine("--------------------Task 3------------------------------");
            // 3. Find and print all persons with more than 2 dogs, ordered by name - DESCENDING ORDER.
            List<Person> personDogs = people
                                        .Where(x => (x.Dogs != null) && (x.Dogs.Count() > 2))
                                        .OrderByDescending(x => x.FirstName)
                                        .ToList();
            PrintListPerson(personDogs);

            Console.WriteLine("--------------------Task 4------------------------------");
            // 4. Find and print all persons names, last names and job positions that have just one race type dogs.
            List<Person> personTask4 = people.Where(x => x.Dogs != null && x.Dogs.Select(y => y.Race).Distinct().Count() == 1).ToList();
            PrintListPerson(personTask4);


            Console.WriteLine("--------------------Task 5------------------------------");
            // 5. Find and print all Freddy`s dogs names older than 1 year, grouped by dogs race.

            var freddyDogs = freddy.Dogs.Where(x => x.Age > 1).GroupBy(x => x.Race).ToList();
            foreach (var group in freddyDogs)
            {
                Console.WriteLine($"{group.Key}");
                foreach (var dog in group)
                {
                    Console.WriteLine($"{dog.Name}");
                }
            }

            Console.WriteLine("--------------------Task 6------------------------------");
            // 6. Find and print last 10 persons grouped by their age.

            people.Reverse();
            var lastTenPersons = people

                                    .Take(10)
                                    .GroupBy(x => x.Age)
                                     .Reverse()
                                     .ToList();

            foreach (var group in lastTenPersons)
            {
                Console.WriteLine($"Age : {group.Key}");
                foreach (var person in group)
                {
                    Console.Write($"{person.FirstName} {person.LastName} \n");
                }
            }






            Console.WriteLine("--------------------Task 7------------------------------");
            // 7. Find and print all dogs names from Cristofer, Freddy, Erin and Amelia, grouped by color and ordered by name - ASCENDING ORDER.
            var dog7 = people
                 .Where(x => x.FirstName == "Cristofer" || x.FirstName == "Freddy" || x.FirstName == "Erin" || x.FirstName == "Amelia")
                 .SelectMany(x => x.Dogs)
                 .OrderBy(x => x.Name)
                  .GroupBy(x => x.Color)
                  .ToList();

           

            foreach (var dog in dog7)
            {
                Console.WriteLine($"Dog color: {dog.Key}");
                foreach (var item in dog)
                {
                    Console.WriteLine($"Name :{item.Name}");

                }
            }




            Console.WriteLine("--------------------Task 8------------------------------");
            // 8. Find and persons that have slisame dogs races and order them by name length ASCENDING, then by age DESCENDING.
            var person8 = people
                        .Select(x=>x.Dogs)
                        .GroupBy(y => y.Race)
                        .Distinct()
                        

                        .ToList();



            Console.WriteLine("--------------------Task 9------------------------------");
            //9. Find the last dog of Amelia and print all dogs form other persons older than Amelia, ordered by dogs age DESCENDING.

            Dog lastDog = amelia.Dogs
                        .LastOrDefault();
            var person9 = people
                           .Where(x => x.Age > amelia.Age).ToList();
            //PrintListPerson(person9);
            var dog9 = person9
                           .Where(x=>x.Dogs != null)
                          .SelectMany(x=>x.Dogs)
                          .OrderByDescending(x=>x.Age)
                          .ToList();
            Console.WriteLine($"{lastDog.Name} {lastDog.Age}");
            PrintListDog(dog9);
           

            Console.WriteLine("--------------------Task 10------------------------------");
            //10.Find all developers older than 20 with more than 1 dog that contains letter 'e' in the name and print their names and job positions.
          var developers = people
                        .Where(x => x.Dogs != null)
                       .Where(x => (x.Occupation == Job.Developer) && x.Age > 20)
                       .Where(x => x.Dogs.Count() > 1)
                        .Where(x => x.Dogs.Any(y => y.Name.Contains("e")))
                        .ToList();


             PrintListPerson(developers);

            
                        
                         
                         

                         

                       
                         



            Console.ReadLine();
            #endregion
        }
        public static void PrintListPerson(List<Person> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName} {item.Age} {item.Occupation}");
            }

        }
        public static void PrintListDog(List<Dog> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine($"{item.Name} {item.Age} {item.Color} ");
            }

        }
    }
}