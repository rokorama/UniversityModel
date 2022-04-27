using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using UniversityModel.Contexts;
using UniversityModel.Models;
using UniversityModel.Views;

namespace UniversityModel.Controllers
{
    static internal class CourseController
    {
        static internal Course CreateCourse()
        {
            using var context = new UniversityDbContext();

            Console.WriteLine("\n\nEnter name of the course (or leave empty to abort): ");
            var courseName = Console.ReadLine();
            if (courseName == "")
                return default;
            var newCourse = new Course()
            {
                Id = Guid.NewGuid(),
                Name = courseName.Trim()
            };

            context.Courses.Add(newCourse);

            try
            {
                context.SaveChanges();
                Console.WriteLine("Course saved successfully");
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException)
            {
                Console.WriteLine("Course could not be saved; please try again.");
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();

            return newCourse;
        }

        static internal void AddStudent(Course course = null, Student studentToAdd = null)
        {
            using var context = new UniversityDbContext();
        
            if (course == null)
                course = CourseView.ChooseItemFromDatabase(false);

            if (studentToAdd == null)
                studentToAdd = StudentView.ChooseItemFromDatabase(false);

            if (course.Students.Contains(studentToAdd))
            {
                Console.WriteLine("Student already enrolled in this course, no changes made.");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine($"Assign the student to {course.Name}? (Y/N)");
            var confirmChanges = InputParser.PromptForYesOrNo();
            if (confirmChanges)
            {
                try
                {
                    var courseEntry = context.Courses.Include(c => c.Students)
                                               .SingleOrDefault(c => c.Id == course.Id);
                    var studentEntry = context.Students.Include(s => s.Courses)
                                                       .SingleOrDefault(s => s.Id == studentToAdd.Id);
                    courseEntry.Students.Add(studentEntry);
                    context.SaveChanges();
                    Console.WriteLine("Changes saved.");
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey();
                }
                catch (Microsoft.EntityFrameworkCore.DbUpdateException)
                {
                    Console.WriteLine("Student could not be added, please try again.");
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

        static internal void RemoveStudent(Course course, Student studentToRemove = null)
        {
            using var context = new UniversityDbContext();

            if (studentToRemove == null)
            {
                StudentView.PrintItems(course.Students);
                var studentListIndex = course.Students.Count;
                studentToRemove = course.Students[InputParser.PromptIntFromUser(studentListIndex) - 1];
            }
            
            Console.WriteLine($"Remove the {studentToRemove.FirstName} {studentToRemove.LastName} from {course.Name}? (Y/N)");
            var confirmChanges = InputParser.PromptForYesOrNo();
            if (confirmChanges)
            {
                var courseEntry = context.Courses.Include(c => c.Students)
                                           .Include(c => c.Departments)
                                           .SingleOrDefault(c => c.Id == course.Id);
                var studentEntry = context.Students.Include(s => s.Courses)
                                                .SingleOrDefault(s => s.Id == studentToRemove.Id);
                courseEntry.Students.Remove(studentEntry);
                context.SaveChanges();
                Console.WriteLine("Changes saved.");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
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
