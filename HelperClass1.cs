using BAL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
    public class Helperclass1
    {
        DAL2 dal = null;
        public Helperclass1()
        {
            dal = new DAL2();
        }


        public bool AddE(subjects school)
        {
            return dal.Insert(school);

        }
       
        public bool Edit(subjects school)
        {
            return dal.Update(school);
        }
        //public int Count()
        //{
        //    return dal.EmployeeCount();
        //}
        public subjects search(int id)
        {
            return dal.Find(id);
        }
        public List<subjects> List()
        {
            return dal.List();
        }
        public bool remove(int id)
        {
            return dal.Delete(id);
        }
    }
    }
