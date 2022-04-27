using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using UniversityModel.Contexts;
using UniversityModel.Models;
using UniversityModel.Views;

namespace UniversityModel.Controllers
{
    static internal class DepartmentController
    {
        static internal Department CreateDepartment()
        {
            using var context = new UniversityDbContext();

            Console.Clear();
            Console.Write("Enter department name (leave blank to abort): ");
            var deptName = Console.ReadLine();
            if (deptName == "")
                return default;

            var result = new Department() {
                Id = Guid.NewGuid(),
                Name = deptName.Trim()
            };

            context.Departments.Add(result);
            
            try {
                context.SaveChanges();
                Console.WriteLine("Department added to the database.");
                return result;
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException) {
                Console.WriteLine("An error occured, department could not be saved. Please try again.");
                return default;
            }
        }

        static internal void AddCourse(Department deptToUpdate, Course courseToAdd)
        {
            using var context = new UniversityDbContext();

            var deptEntry = context.Departments.Include(d => d.Courses)
                                               .SingleOrDefault(d => d.Id == deptToUpdate.Id);

            try
            {
                deptEntry.Courses.Add(courseToAdd);
                context.SaveChanges();
                Console.WriteLine("Course added to the department.");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
            }
            catch (System.InvalidOperationException)
            {
                Console.WriteLine("The department already contains this course, no changes needed.");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException)
            {
                Console.WriteLine("An error occured, course could not be added. Please try again.");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
            }
        }

        static internal void AddStudent(Student studentToAdd, Department deptToUpdate = null)
        {
            using var context = new UniversityDbContext();

            if (deptToUpdate == null)
                deptToUpdate = DepartmentView.ChooseItemFromDatabase(false);


            if (deptToUpdate.Students.Contains(studentToAdd))
            {
                Console.WriteLine("The student is already in this department. Press any key to try again.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine();
            Console.WriteLine($"Assign the student to {deptToUpdate.Name}? (Y/N)");
            var confirmChanges = InputParser.PromptForYesOrNo();
            if (confirmChanges)
            {
                try
                {
                    var dbEntry = context.Departments.Include(d => d.Students)
                                                     .Include(d => d.Courses)
                                                     .SingleOrDefault(d => d.Id == deptToUpdate.Id);
                    dbEntry.Students.Add(studentToAdd);
                    context.SaveChanges();
                    Console.WriteLine("Student added to the department.");
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey();
                }
                catch (Microsoft.EntityFrameworkCore.DbUpdateException)
                {
                    Console.WriteLine("An error occured, student could not be added. Please try again.");
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Changes discarded.");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
            }
        }
    }
}
