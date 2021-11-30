using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using proiectDAW.Models;

namespace proiectDAW.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        public static List<Student> students = new List<Student>
        {
            new Student(1, "test", 12),
            new Student(2, "test1", 13)
        };

        [HttpGet("getStudents")]
        public List<Student> getStudents()
        {
            return students;
        }
    }
}
