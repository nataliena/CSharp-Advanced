﻿using System.Collections.Generic;

namespace LinqExercise.Models
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Job Occupation { get; set; }
        public List<Dog> Dogs { get; set; }

        public Person(string firstName, string lastName, int age, Job occupation)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Occupation = occupation;
        }
        public void PrintAllDogs()
        {
            foreach (var dog in Dogs)
            {
                System.Console.WriteLine($"{dog.Name}");
            }


        }
    }
}