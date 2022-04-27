using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using UniversityModel.Contexts;
using UniversityModel.Controllers;
using UniversityModel.Models;
using UniversityModel.Views;

namespace UniversityModel
{
    static internal class CourseView
    {
        static public void PrintItems(List<Course> courses)
        {
            Console.Clear();
            Console.WriteLine(String.Format("{0,-5} | {1,-36} | {2,-30} | {3,-10}", "#", "Course ID", "Name", "Students"));
            Console.WriteLine();
            int counter = 1;
            foreach (var course in courses)
            {
                Console.WriteLine(String.Format("{0,-5}", counter) + " | " + course.ToString());
                counter++;
            }
        }

        static internal Course ChooseItemFromDatabase(bool allowCreation)
        {
            using var context = new UniversityDbContext();

            PrintItems(context.Courses.Include(c => c.Students)
                                      .AsNoTracking()
                                      .ToList());

            Console.WriteLine();
            Console.WriteLine("Enter the number of the course you wish to choose.");
            Console.WriteLine("Press B to go back");
            if (allowCreation)
            {
                Console.WriteLine("      N to create new course");
            }
            Console.WriteLine();
            var userselection = InputParser.PromptInputFromUser(context.Courses.Count(),
                                                                "B",
                                                                allowCreation ? "N" : null);
            if (userselection == "B")
                return null;
            else if (userselection == "N")
                return CourseController.CreateCourse();
            else
                return context.Courses.Include(c => c.Students)
                                      .Include(c => c.Departments)
                                      .AsNoTracking()
                                      .ToList()[Convert.ToInt32(userselection) -1];
        }

        static internal void OptionsMenu(Course course)
        {
            bool stayInMenu = true;
            while (stayInMenu)
            {
                Console.Clear();
                Console.WriteLine($"Menu for {course.Name}");
                Console.WriteLine();
                Console.WriteLine("Press 1 to add a student to this course");
                Console.WriteLine("      2 to remove a student from this course");
                Console.WriteLine("      3 to see all students enrolled in this course");
                Console.WriteLine("      4 to see all departments containing this course");
                Console.WriteLine("      B to go back");
                Console.WriteLine();
                var menuSelection = InputParser.PromptInputFromUser("1", "2", "3", "4", "B");
                switch (menuSelection)
                {
                    case "1":
                        var studentToAdd = StudentView.ChooseItemFromDatabase(true);
                        CourseController.AddStudent(course, studentToAdd);
                        break;
                    case "2":
                        StudentRemovalMenu(course);
                        break;
                    case "3":
                        ListStudentsInCourse(course);
                        break;
                    case "4":
                        ListDepartmentsContainingCourse(course);
                        break;
                    case "B":
                        ChooseItemFromDatabase(true);
                        stayInMenu = false;
                        break;
                }
            }
        }
        
        static private void StudentRemovalMenu(Course course)
        {
            using var context = new UniversityDbContext();

            var courseEntry = context.Courses.Include(c => c.Students)
                                                .Include(c => c.Departments)
                                                .AsNoTracking()
                                                .SingleOrDefault(c => c.Id == course.Id);
            StudentView.PrintItems(courseEntry.Students.ToList());
            var studentListIndex = courseEntry.Students.Count;

            Console.WriteLine();
            Console.WriteLine("Select the student to remove:");
            var userSelection = courseEntry.Students[InputParser.PromptIntFromUser(studentListIndex) - 1];
            CourseController.RemoveStudent(course, userSelection);
        }

        static private void ListStudentsInCourse(Course course)
        {
            using var context = new UniversityDbContext();

            var courseList = context.Students.Include(s => s.Courses)
                                                .Include(s => s.Department)
                                                .Where(s => s.Courses.Contains(course))
                                                .ToList();
            StudentView.PrintItems(courseList);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Press any key to go back.");
            Console.ReadKey();
        }

        static private void ListDepartmentsContainingCourse(Course course)
        {
            using var context = new UniversityDbContext();

            var deptList = context.Departments.Include(d => d.Courses)
                                            .Where(d => d.Courses.Contains(course))
                                            .ToList();
            DepartmentView.PrintItems(deptList);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Press any key to go back.");
            Console.ReadKey();
        }

    }
}