using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniversityModel.Models
{
    public class Department
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual List<Course> Courses { get; set; }
        public virtual List<Student> Students { get; set; }


        public Department()
        {
            Courses = new();
            Students = new();
        }

        public override string ToString()
        {
            return String.Format("{0,-36} | {1,-33} | {2,-8} | {3,-8}", Id, Name, Courses.Count, Students.Count);
        }  
    }
}
