using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using UniversityModel.Contexts;
using UniversityModel.Controllers;
using UniversityModel.Models;

namespace UniversityModel.Views
{
    static public class StudentView
    {
        internal static void PrintItems(List<Student> students)
        {
            Console.Clear();
            Console.WriteLine(String.Format("{0,-5} | {1,-36} | {2,-15} | {3,-15} | {4,-10}", "#", "ID", "First name", "Last name", "Department"));
            Console.WriteLine();
            int counter = 1;
            foreach (var student in students)
            {
                Console.WriteLine(String.Format("{0,-5}", counter) + " | " + student.ToString());
                counter++;
            }
        }

        internal static Student ChooseItemFromDatabase(bool allowCreation)
        {
            using var context = new UniversityDbContext();

            var students = context.Students.Include(s => s.Courses)
                                           .Include(s => s.Department)
                                           .AsNoTracking()
                                           .ToList();
            PrintItems(students);

            Console.WriteLine();
            Console.WriteLine("Enter the number of the student you wish to select.");
            Console.WriteLine("Press B to go back");
            if (allowCreation)
            {
                Console.WriteLine("      N to create new student");
            }
            Console.WriteLine();
            var userselection = InputParser.PromptInputFromUser(students.Count(),
                                                                "B",
                                                                allowCreation ? "N" : null);
            if (userselection == "B")
                return null;
            else if (userselection == "N")
                return StudentController.CreateStudent();
            else
                return students[Convert.ToInt32(userselection) -1];
        }

        internal static void OptionsMenu(Student student)
        {
            bool stayInMenu = true;
            while (stayInMenu)
            {
                Console.Clear();
                Console.WriteLine($"Menu for {student.FirstName} {student.LastName}");
                Console.WriteLine();
                Console.WriteLine("Press 1 to change the student's department");
                Console.WriteLine("      2 to add student to a course");
                Console.WriteLine("      3 to remove student from a course");
                Console.WriteLine("      4 to see all courses the student is enrolled in");
                Console.WriteLine("      B to go back");
                Console.WriteLine();
                var userSelection = InputParser.PromptInputFromUser("1", "2", "3", "4", "B");
                switch (userSelection)
                {
                    case "1":
                        DepartmentController.AddStudent(student);
                        break;
                    case "2":
                        CourseController.AddStudent(null, student);
                        break;
                    case "3":
                        CourseController.RemoveStudent(null, student);
                        break;
                    case "4":
                        CourseView.PrintItems(student.Courses);
                        Console.WriteLine("\nPress any key to go back.");
                        Console.ReadKey();
                        break;
                    case "B":
                        ChooseItemFromDatabase(true);
                        stayInMenu = false;
                        break;
                }
            }
        }
    }
}