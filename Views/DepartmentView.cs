using System;
using UniversityModel.Models;
using UniversityModel.Contexts;
using System.Linq;
using UniversityModel.Controllers;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace UniversityModel.Views
{
    static public class DepartmentView
    {

        static internal Department ChooseItemFromDatabase(bool allowCreation)
        {
            using var context = new UniversityDbContext();

            PrintItems(context.Departments.Include(d => d.Students)
                                          .Include(d => d.Courses)
                                          .AsNoTracking()
                                          .ToList());

            Console.WriteLine();
            Console.WriteLine("Enter the number of the department you wish to select.");
            Console.WriteLine("Press B to go back");
            if (allowCreation)
            {
                Console.WriteLine("      N to create new department");
            }
            Console.WriteLine();

            var userselection = InputParser.PromptInputFromUser(context.Departments.Count(),
                                                                "B",
                                                                allowCreation ? "N" : null);
            if (userselection == "B")
            {
                return default;
            }
            else if (userselection == "N")
                return DepartmentController.CreateDepartment();
            else
                return context.Departments.Include(c => c.Courses)
                                          .Include(c => c.Students)
                                          .AsNoTracking()
                                          .ToList()[Convert.ToInt32(userselection) -1];
        }

        static internal void PrintItems(List<Department> deptList)
        {
            Console.Clear();
            Console.WriteLine(String.Format("{0,-5} | {1,-36} | {2,-33} | {3,-8} | {4,-8}",
                                            "#", "Course ID", "Department name", "Courses", "Students"));
            Console.WriteLine();
            int counter = 1;
            foreach (var dept in deptList)
            {
                Console.WriteLine(String.Format("{0,-5}", counter) + " | " + dept.ToString());
                counter++;
            }
        }
        static internal Department DepartmentCreationMenu()
        {
            var resultDept = DepartmentController.CreateDepartment();
            if (resultDept == null)
                return null;

            Console.WriteLine("Add students to the department?");
            var addStudentsToDeptPrompt = InputParser.PromptForYesOrNo();
            if (addStudentsToDeptPrompt)
            {
                bool continueAdding = true;
                while (continueAdding)
                {
                    if (addStudentsToDeptPrompt)
                    {
                        var newStudent = StudentController.CreateStudent();
                        resultDept.Students.Add(newStudent);
                        Console.WriteLine("Add another?");
                        continueAdding = InputParser.PromptForYesOrNo();
                    }
                }
            }

            Console.WriteLine("Add courses to the department?");
            var addCourseToDeptPrompt = InputParser.PromptForYesOrNo();
            if (addCourseToDeptPrompt)
              CourseView.ChooseItemFromDatabase(true);  

            return resultDept;
        }

        // could make the following two generic

        static private void AddStudent(Department deptToUpdate)
        {
            var studentToAdd = StudentView.ChooseItemFromDatabase(true);
            Console.WriteLine($"Add {studentToAdd.FirstName} {studentToAdd.LastName} to {deptToUpdate.Name}? (Y/N)");
            var confirmationPrompt = InputParser.PromptForYesOrNo();
            if (confirmationPrompt)
                DepartmentController.AddStudent(studentToAdd, deptToUpdate);
            else 
                return;
        }

        static private void AddCourse(Department deptToUpdate)
        {
            var courseToAdd = CourseView.ChooseItemFromDatabase(true);
            if (courseToAdd == null)
                return;
            Console.WriteLine($"Add {courseToAdd.Name} to {deptToUpdate.Name}? (Y/N)");
            var confirmationPrompt = InputParser.PromptForYesOrNo();
            if (confirmationPrompt)
                DepartmentController.AddCourse(deptToUpdate, courseToAdd);
            else 
                return;
        }

        static internal void OptionsMenu(Department department)
        {
            bool stayInMenu = true;
            while (stayInMenu)
            {
                Console.Clear();
                Console.WriteLine($"Menu for {department.Name}");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Press 1 to add a student to this department");
                Console.WriteLine("      2 to add a course to this department");
                Console.WriteLine("      3 to see all students in this department");
                Console.WriteLine("      4 to see all courses in this department");
                Console.WriteLine("      B to go back");
                Console.WriteLine();
                var userSelection = InputParser.PromptInputFromUser("1", "2", "3", "4", "B");
                switch (userSelection)
                {
                    case "1":
                        var studentToAdd = StudentView.ChooseItemFromDatabase(true);
                        DepartmentController.AddStudent(studentToAdd, department);
                        break;
                    case "2":
                        AddCourse(department);
                        break;
                    case "3":
                        ListStudentsInDepartment(department);
                        break;
                    case "4":
                        ListCoursesInDepartment(department);
                        break;
                    case "B":
                        ChooseItemFromDatabase(true);
                        stayInMenu = false;
                        break;
                }
            }
        }

        private static void ListStudentsInDepartment(Department department)
        {
            using var context = new UniversityDbContext();

            var studentList = context.Students.Include(s => s.Department)
                                                .Where(s => s.Department.Id == department.Id)
                                                .AsNoTracking()
                                                .ToList();
            StudentView.PrintItems(studentList);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Press any key to go back.");
            Console.ReadKey();
        }

        private static void ListCoursesInDepartment(Department department)
        {
            using var context = new UniversityDbContext();

            var courseList = context.Courses.Include(c => c.Departments)
                                            .Where(c => c.Departments.Contains(department))
                                            .AsNoTracking()
                                            .ToList();
            CourseView.PrintItems(courseList);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Press any key to go back.");
            Console.ReadKey();
        }

    }
}