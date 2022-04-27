using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniversityModel.Models
{
    public class Course
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual List<Department> Departments { get; set; }
        public virtual List<Student> Students { get; set; }

        public Course()
        {
            Departments = new();
            Students = new();
        }

        public override string ToString()
        {
            return String.Format("{0,-36} | {1,-30} | {2,-10}", Id, Name, Students.Count);
        }    
    }
}
