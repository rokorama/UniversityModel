using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniversityModel.Models
{
    public class Student
    {
        [Key]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual List<Course> Courses { get; set; }
        public virtual Department Department { get; set; }

        public Student()
        {
            Courses = new();
        }

        public override string ToString()
        {
            return String.Format("{0,-36} | {1,-15} | {2,-15} | {3,-10}", Id, FirstName, LastName, (Department == null) ? "N/A" : Department.Name);
        }  
    }
}
