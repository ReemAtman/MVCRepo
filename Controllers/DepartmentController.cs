using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using MVC.ViweModels;

namespace MVC.Controllers
{
    public class DepartmentController : Controller
    {
        EducationContext db = new EducationContext();
        public IActionResult Index()
        {
            List<Department> departments = db.departments.ToList();
            return View(departments);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Department department = db.departments.SingleOrDefault(d=>d.id== id);
            return PartialView(department);
        }

        [HttpPost]
        public IActionResult Edit(int id, Department dept)
        {
            if (ModelState.IsValid)
            {

                db.departments.Update(dept);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("Edit", dept);
            }
        }

        public IActionResult Delete(int id)
        {
           
                db.departments.Remove(db.departments.FirstOrDefault(d => d.id == id));
                db.SaveChanges();
                return RedirectToAction("Index");
            

        }
    }
}
