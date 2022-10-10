using BAL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
    public class HelperClass2
    {
       
            DAL3 dal = null;
            public HelperClass2()
            {
                dal = new DAL3();
            }


            public bool AddE(Class1 school)
            {
                return dal.Insert(school);

            }

            public bool Edit(Class1 school)
            {
                return dal.Update(school);
            }
            //public int Count()
            //{
            //    return dal.EmployeeCount();
            //}
            public Class1 search(int id)
            {
                return dal.Find(id);
            }
            public List<Class1> List()
            {
                return dal.List();
            }
            public bool remove(int id)
            {
                return dal.Delete(id);
            }
        
    }
}
