using BAL;
using Helper;
using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class Class1Controller : Controller
    {
        // GET: Class1
        HelperClass2 helper = null;
        public Class1Controller()
        {
            helper = new HelperClass2();
        }

        public ActionResult Index()
        {
            var stulist = helper.List();
            List<Class1model> modelsList = new List<Class1model>();
            foreach (var item in stulist)
            {
                modelsList.Add(new Class1model
                {
                    Room_no= item.Room_no,
                    class_strength = item.class_strength
                });
            }

            return View(modelsList);
        }
        public ActionResult Details(int id)
        {
            var data = helper.search(id);
           Class1model emp = new Class1model();
            emp.Room_no = id;
            emp.class_strength = data.class_strength;
            //  emp.student_class = data.student_class;

            return View(emp);

        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            Class1 bal = new Class1();
            bal.Room_no= Convert.ToInt32(Request["Room_no"]);
            bal.class_strength= Convert.ToInt32(Request["class_strength"]);


            bool ans = helper.AddE(bal);
            if (ans)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var emp = helper.search(id);
            Class1model model = new Class1model();
            model.Room_no = id;
            model.class_strength= emp.class_strength;




            return View(model);
        }


        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                var emp = helper.search(id);
                emp.Room_no = Convert.ToInt32(Request["Room_no"]);
                emp.class_strength = Convert.ToInt32(Request["class_strength"]);



                bool ans = helper.Edit(emp);


                if (ans)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }


            }
            catch
            {
                return View();
            }
        }


        public ActionResult Delete(int id)
        {
            var emp = helper.search(id);
            Class1model model = new Class1model();
            model.Room_no= id;
            model.class_strength = emp.class_strength;




            return View(model);
        }


        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var dataFound = helper.search(id);
                if (dataFound != null)
                {
                    bool ans = helper.remove(id);
                    if (ans)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return View();
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}