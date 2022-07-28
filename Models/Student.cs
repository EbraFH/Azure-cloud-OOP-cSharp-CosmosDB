using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Models
{
    public class Student
    {
        public string id { get; set; }
        public string lastname { get; set; }
        public string firstname { get; set; }
        public string age {get; set;}
        public string StudentMiddleName { get; set; }
        public Address[] Addresses { get; set; }
        public Course[] Courses { get; set; }
    }
}
