using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiectDAW.Models
{
    public class Student
    {
        public int Id;
        public string Name;
        public int Age;

        public Student(int v1, string v2, int v3)
        {
            this.Id = v1;
            this.Name = v2;
            this.Age = v3;
        }
    }
}
