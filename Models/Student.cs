using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityModel.Models
{
    public class Student
    {
        public Guid Id { get; set; }
        public List<Course> Courses { get; set; }
        [ForeignKey("Department")]
        public Guid DepartmentId { get; set; }
        
    }
}
