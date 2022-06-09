using crud_using_ripository_pattern.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ripo_using_core.Models;

namespace ripo_using_core.Controllers
{
    public class EmployeeController1 : Controller
    {

        Ripository<Employee> obj = new Ripository<Employee>();



        // GET: EmployeeController1
        public ActionResult Index()
        {
            var itm = obj.spexecution("sp_ShowAllEmployee");
            return View(itm);
        }

        // GET: EmployeeController1/Details/5
        public ActionResult Details(int id)
        {
            var itm = obj.spexecution("sp_showSpecificEmployee {0}",id).ToList().FirstOrDefault();
            return View(itm);
        }

        // GET: EmployeeController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    obj.spexecution("sp_AddEmp {0},{1},{2}",emp.Fullname,emp.Age,emp.Email).ToList();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");

            }
        }

        // GET: EmployeeController1/Edit/5
        public ActionResult Edit(int id)
        {
            var itm = obj.spexecution("sp_showSpecificEmployee {0}", id).ToList().FirstOrDefault();
            return View(itm);
        }

        // POST: EmployeeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Employee emp)
        {
            try
            {
                obj.spexecution("sp_UpdateEmp {0},{1},{2},{3}",emp.Id,emp.Fullname,emp.Age,emp.Email).ToList();
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // GET: EmployeeController1/Delete/5
        public ActionResult Delete(int id)
        {
            var itm = obj.spexecution("sp_showSpecificEmployee {0}", id).ToList().FirstOrDefault();
            return View(itm);
        }

        // POST: EmployeeController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id,Employee e)
        {
            try
            {
                obj.spexecution("sp_DeleteEmp {0}",e.Id).ToList();
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }



    }
}
