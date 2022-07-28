using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Models
{
    public class Course
    {
        public String CourseName { get; set; }
        public String Teacher { get; set; }
        public int NumOfRegisteredStudents { get; set; }
        public int Rate { get; set; }
    }
}
