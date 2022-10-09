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
    public class SubjectsController : Controller
    {
        // GET: Subjects
        Helperclass1 helper = null;
        public SubjectsController()
        {
            helper = new Helperclass1();
        }

        public ActionResult Index()
        {
            var stulist = helper.List();
            List<submodel> modelsList = new List<submodel>();
            foreach (var item in stulist)
            {
                modelsList.Add(new submodel
                {
                    subjects_id = item.subjects_id,
                    subjects_name = item.subjects_name
                });
            }

            return View(modelsList);
        }
        public ActionResult Details(int id)
        {
            var data = helper.search(id);
            submodel emp = new submodel();
            emp.subjects_id = id;
            emp.subjects_name = data.subjects_name;
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
            subjects bal = new subjects();
            bal.subjects_id = Convert.ToInt32(Request["subjects_id"]);
            bal.subjects_name = Request["subjects_name"].ToString();
           

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
            submodel model = new submodel();
            model.subjects_id = id;
            model.subjects_name = emp.subjects_name;
           



            return View(model);
        }


        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                var emp = helper.search(id);
                emp.subjects_id = Convert.ToInt32(Request["subjects_id"]);
                emp.subjects_name = Request["subjects_name"].ToString();
                

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
            submodel model = new submodel();
            model.subjects_id = id;
            model.subjects_name = emp.subjects_name;
            



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