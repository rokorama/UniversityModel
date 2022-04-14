using System;
using System.Collections.Generic;

namespace UniversityModel.Models
{
    public class Department
    {
        public Guid Id { get; set; }
        public List<Course> Courses { get; set; }
        public List<Student> Students { get; set; }
    }
}
