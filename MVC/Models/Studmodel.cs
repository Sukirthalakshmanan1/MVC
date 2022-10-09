using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Studmodel
    {
        public int student_id { get; set; }
        public string student_name { get; set; }

        public int student_class { get; set; }
    }

    public class submodel
    {
        public int subjects_id { get; set; }
        public string subjects_name { get; set; }
    }

    public class Class1model
    {
        public int Room_no { get; set; }
        public int class_strength { get; set; }
    }


}