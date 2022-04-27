using System;
using UniversityModel.Contexts;
using UniversityModel.Models;

namespace UniversityModel.Controllers
{
    static internal class StudentController
    {
        static internal Student CreateStudent()
        {
            using var context = new UniversityDbContext();

            Console.Write("Enter first name (or leave empty to abort): ");
            var newStudentFirstName = Console.ReadLine();
            if (string.IsNullOrEmpty(newStudentFirstName))
            {
                Console.WriteLine("Operation aborted.");
                return default;
            }
            Console.Write("Enter last name (or leave empty to abort): ");
            var newStudentLastName = Console.ReadLine();
            if (string.IsNullOrEmpty(newStudentLastName))
            {
                Console.WriteLine("Operation aborted.");
                return default;
            }
            var newStudent = new Student() {
                Id = Guid.NewGuid(),
                FirstName = newStudentFirstName.Trim(),
                LastName = newStudentLastName.Trim()
            };

            context.Students.Add(newStudent);
            context.SaveChanges();
            return newStudent;
        }
    }
}
