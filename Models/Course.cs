using System;
using System.Collections.Generic;

namespace UniversityModel.Models
{
    public class Course
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public List<Department> Departments { get; set; }
    }
}
