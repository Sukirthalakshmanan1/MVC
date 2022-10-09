using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class student
    {
        public int student_id { get; set; }
        public string student_name { get; set; }

        public int student_class { get; set; }
    }
    public class subjects
    {
        public int subjects_id { get; set; }
        public string subjects_name { get; set; }    
    }

    public class Class1
    {
        public int Room_no { get; set; }
        public int class_strength { get; set; }
    }

}
