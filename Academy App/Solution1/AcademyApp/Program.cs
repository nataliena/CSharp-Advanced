using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace AcademyApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Subject> subjects = new List<Subject>();

            subjects.Add(new Subject("HTML"));
            subjects.Add(new Subject("CSS"));
            subjects.Add(new Subject("JavaScript"));
            subjects.Add(new Subject("C#"));

            List<Person> persons = new List<Person>();
            persons.Add(new Admin("Dejan", "Zdravkovski", "dejan", "pass1"));
            persons.Add(new Admin("Orce", "Stefanovski", "orce", "pass2"));
            persons.Add(new Admin("Martin", "Panov", "martin", "pass3"));

            persons.Add(new Trainer("Trajan", "Stevkovski", "trajan", "pass4"));
            persons.Add(new Trainer("Risto", "Panchevski", "risto", "pass5"));
            persons.Add(new Trainer("Dragan", "Gelevski", "dragan", "pass6"));



            persons.Add(new Student("Natasha", "Andova", "natasha", "pass7", new Dictionary<Subject, byte>() { { subjects[0], 8 }, { subjects[1], 7 } }));
            persons.Add(new Student("Valentina", "Palkovska", "valentina", "pass8", new Dictionary<Subject, byte>() { { subjects[1], 9 }, { subjects[2], 10 } }));
            persons.Add(new Student("Jovan", "Jovanovski", "jovan", "pass8", new Dictionary<Subject, byte>() { { subjects[2], 10 }, { subjects[0], 6 } }));

            #region Login
            while (true)
            {
                Console.WriteLine("Enter your username:");
                string inputUser = Console.ReadLine();
                Person person = persons
                    .Where(x => x.User == inputUser)
                    .FirstOrDefault();
                if (person == null)

                {
                    Console.WriteLine("Please try again!");

                }
                if (person.CheckUser(inputUser))

                {
                    Console.WriteLine("Enter your password:");
                    string inputPass = Console.ReadLine();
                    if (person.CheckPassword(inputPass))
                    {
                        Console.WriteLine($"Welcome {person.Role} : {person.FullName()}!");
                        
                        

                    }
                    else
                    {
                        Console.WriteLine("Wrong password, try again!");
                        break;
                    }

                }
                #endregion Login

                #region Admin

                if (person.Role == Role.Admin)
                {
                    Console.WriteLine("If you want to add users enter 1, if you want to remove users enter 2");

                    int adminInput = int.Parse(Console.ReadLine());
                    if (adminInput == 1)
                    {
                        Console.WriteLine("If you want to add Trainer enter T," +
                            "if you want to add Student enter S and " +
                            "if you want to add Admin enter A");
                        string adminInput1 = Console.ReadLine().ToUpper();
                        if (adminInput1 == "T")
                        {
                            Console.WriteLine("Add first name");
                            string firstName = Console.ReadLine();
                            Console.WriteLine("Add last name");
                            string lastName = Console.ReadLine();
                            Console.WriteLine("Add user");
                            string user = Console.ReadLine();
                            Console.WriteLine("Add password");
                            string pass = Console.ReadLine();


                            persons.Add(new Trainer(firstName, lastName, user, pass));
                            Console.WriteLine($"You have successfully added a new Trainer");
                            foreach (var item in persons)
                            {
                                if (item.Role == Role.Trainer)
                                {
                                    Console.WriteLine($"The new list of Trainers is: {item.FullName()}");
                                }
                            }



                        }
                        if (adminInput1 == "S")
                        {
                            Console.WriteLine("Add first name");
                            string firstName = Console.ReadLine();
                            Console.WriteLine("Add last name");
                            string lastName = Console.ReadLine();
                            Console.WriteLine("Add user");
                            string user = Console.ReadLine();
                            Console.WriteLine("Add password");
                            string pass = Console.ReadLine();
                            persons.Add(new Student(firstName, lastName, user, pass, new Dictionary<Subject, byte>()));
                            Console.WriteLine($"You have successfully added a new Student");
                            Console.WriteLine("The new list of Students is: ");
                            foreach (var item in persons)
                            {
                                if (item.Role == Role.Student)
                                {
                                    Console.WriteLine($"{item.FullName()}");
                                }
                            }


                        }
                        if (adminInput1 == "A")
                        {
                            Console.WriteLine("Add first name");
                            string firstName = Console.ReadLine();
                            Console.WriteLine("Add last name");
                            string lastName = Console.ReadLine();
                            Console.WriteLine("Add user");
                            string user = Console.ReadLine();
                            Console.WriteLine("Add password");
                            string pass = Console.ReadLine();


                            persons.Add(new Admin(firstName, lastName, user, pass));
                            Console.WriteLine($"You have successfully added a new Admin");
                            Console.WriteLine("The new list of Admins is: ");
                            foreach (var item in persons)
                            {
                                if (item.Role == Role.Admin)
                                {
                                    Console.WriteLine($"{item.FullName()}");
                                }
                            }

                        }



                    }
                    else if (adminInput == 2)
                    {
                        Console.WriteLine("Enter the username that you want to remove from the list");
                        string userName = Console.ReadLine();
                        if (userName == person.User)
                        {
                            Console.WriteLine("This action it's not allowed");
                        }

                        else
                        {


                            persons.Remove(persons.Where(x => x.User == userName)
                                .FirstOrDefault());
                            Console.WriteLine($"You have succesfully remove this {userName} form the list");

                            //Console.WriteLine("The list now is: ");  za proverka na listata
                            //foreach (var item in persons)
                            //{
                            //    Console.WriteLine($"{item.FullName()}");
                            //}
                        }
                    }

                }
                #endregion Admin

                #region Trainer
                else if (person.Role == Role.Trainer)
                {
                    Console.WriteLine("Enter : 1 .Show all Students, 2 . Show all Grades  or 3 . Show Current Subject ");
                    List<Person> students = persons.Where(x => x.Role == Role.Student).ToList();
                    List<Student> newStudentsList = students.Cast<Student>().ToList();

                    int trainerInput = int.Parse(Console.ReadLine());
                    if (trainerInput == 1)
                    {

                        foreach (var s in students)
                        {
                            Console.WriteLine($"{s.FullName()}");
                        }
                    }
                    if (trainerInput == 2)
                    {
                        Console.WriteLine($"Enter Student name to show all its grades");
                        string trainerInput2 = Console.ReadLine();

                        foreach (var s in newStudentsList)
                        {
                            if (trainerInput2 == s.FirstName)
                            {
                                Console.WriteLine(s.StudentInfo());

                            }
                        }
                    }
                    if (trainerInput == 3)
                    {
                        Console.WriteLine("Enter Subject from the List");
                        foreach (var s in subjects)
                        {
                            Console.WriteLine($"{s.Name}");
                        }
                        string currentSubject = Console.ReadLine();
                        int subjectCount = 0;
                        foreach (Student s in newStudentsList)
                        {
                            foreach (var student in s.Subjects)
                            {
                                if (student.Key.Name == currentSubject)
                                {
                                    subjectCount += 1;
                                }
                            }
                        }
                        Console.WriteLine($"Name of Subject {currentSubject}: Students {subjectCount}");
                    }
                    #endregion Trainer  

                    #region Student
                }
                else if (person.Role == Role.Student)
                {

                    Console.WriteLine("Enter : 1. Enroll a Subject or 2. Show all your Grades");

                    Student studentUser = (Student)person;
                    int studentInput1 = int.Parse(Console.ReadLine());
                    if (studentInput1 == 1)
                    {

                        Console.WriteLine("Please select Subject from the List below");

                        foreach (Subject subject in subjects)
                        {
                            if (!studentUser.Subjects.ContainsKey(subject))
                            {
                                Console.WriteLine($"{subject.Name}");
                            }

                        }
                        string studentSubject = Console.ReadLine();
                        Console.WriteLine($"Your current Subject is {studentSubject}");
                    }
                    else if (studentInput1 == 2)
                    {
                        Console.WriteLine($"{studentUser.StudentInfo()}");
                    }

                }

                #endregion Student
                Console.ReadLine();
            }
            
                
            
           
        }
    }
    }

