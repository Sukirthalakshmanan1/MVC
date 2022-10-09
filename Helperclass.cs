using BAL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
    public class Helperclass
    {
        DAL1 dal = null;
        public Helperclass()
        {
            dal = new DAL1();
        }


        public bool AddE(student school)
        {
            return dal.Insert(school);

        }
        //public bool AddEmployees(Employee_BAL employee)
        //{
        //    return dal.InsertEmployees(employee);

        //}
        public bool Edit(student school)
        {
            return dal.Update(school);
        }
        //public int Count()
        //{
        //    return dal.EmployeeCount();
        //}
        public student search(int id)
        {
            return dal.Find(id);
        }
        public List<student> List()
        {
            return dal.List();
        }
        public bool remove(int id)
        {
            return dal.Delete(id);
        }
    }
}