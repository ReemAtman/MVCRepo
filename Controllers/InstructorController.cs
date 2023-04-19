using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Models;
using MVC.ViweModels;

namespace MVC.Controllers
{
    public class InstructorController : Controller
    {
        EducationContext db = new EducationContext();
        public IActionResult Index()
        {
            List<Instructor> instructors = db.instructors.Include(i => i.Course).Include(i => i.Department).ToList();
            return View("Index", instructors);
        }
        public IActionResult Details(int id)
        {
            Instructor instructor = db.instructors.Include(i => i.Course).Include(i => i.Department).FirstOrDefault(i => i.id == id);
            return View("Details", instructor);
        }

        [HttpGet]
        //Instructor/Edit/2
        public IActionResult Edit(int id)
        {
            Instructor instructor = db.instructors.FirstOrDefault(i => i.id == id);
            List<Department> departments = db.departments.ToList();
            List<Course> courses = db.courses.ToList();
            InstructorVM instructorVM = new InstructorVM();
            instructorVM.Id = id;
            instructorVM.Name = instructor.name;
            instructorVM.Address = instructor.address;
            instructorVM.Img = instructor.img;
            instructorVM.Salary = instructor.salary;
            instructorVM.Dept_ID = instructor.Dept_ID;
            instructor.Course_ID = instructor.Course_ID;
            instructorVM.Courses = courses;
            instructorVM.Departments = departments;
            return View("Edit", instructorVM);
        }

        [HttpPost]
        public IActionResult Edit([FromRoute] int id, Instructor newIstructor)
        {
            if (newIstructor.img != null)
            {
                db.instructors.Update(newIstructor);
                db.SaveChanges();
            }
            else
            {
                Instructor oldInstructor = db.instructors.FirstOrDefault(i => i.id == id);
                oldInstructor.img = oldInstructor.img;
                oldInstructor.id = id;
                oldInstructor.name = newIstructor.name;
                oldInstructor.address = newIstructor.address;
                oldInstructor.Dept_ID = newIstructor.Dept_ID;
                oldInstructor.Course_ID = newIstructor.Course_ID;
                db.SaveChanges();

            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        //Instructor/Add
        public IActionResult AddNew()
        {
            List<Department> departments = db.departments.ToList();
            List<Course> courses = db.courses.ToList();
            InstructorVM instructorVM = new InstructorVM();
            instructorVM.Courses = courses;
            instructorVM.Departments = departments;
            return View(instructorVM);
        }
        [HttpPost]
        //Instructor/Add
        public IActionResult Add(Instructor instructor)
        {
            if (instructor.name == null || instructor.img == null || instructor.salary <= 0
                || instructor.address == null || instructor.Dept_ID <= 0 || instructor.Course_ID <= 0)
            {
                List<Department> departments = db.departments.ToList();
                List<Course> courses = db.courses.ToList();
                InstructorVM instructorVM = new InstructorVM();
                instructorVM.Id = instructor.id;
                instructorVM.Name = instructor.name;
                instructorVM.Address = instructor?.address;
                instructorVM.Img = instructor.img;
                instructorVM.Salary = instructor.salary;
                instructorVM.Dept_ID = instructor.Dept_ID;
                instructor.Course_ID = instructor.Course_ID;
                instructorVM.Courses = courses;
                instructorVM.Departments = departments;
                return View("AddNew", instructorVM);
            }
            else
            {
                db.instructors.Add(instructor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        public IActionResult Delete(int id)
        {
            db.instructors.Remove(db.instructors.FirstOrDefault(i => i.id == id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
}
