using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Models;
using MVC.Repositores;
using MVC.ViweModels;

namespace MVC.Controllers
{
    public class CourseController : Controller
    {
        EducationContext db = new EducationContext();
        ICourseReposirory courseReposirory;
        IDepartmentRepository departmentRepository;
        public CourseController(ICourseReposirory _courseReposirory, IDepartmentRepository _departmentRepository)
        {
            this.courseReposirory = _courseReposirory;
            this.departmentRepository = _departmentRepository;
        }

        public IActionResult CheckMindegree( int mindegree, int degree)
        {
            if (mindegree < degree  && mindegree > 0)
                return Json(true);
            else
                return Json("Minmuim degree must be less than degree and more than zero");
        }
        public IActionResult CheckDegreeValue(int degree)
        {
            if ( degree > 0)
                return Json(true);
            else
                return Json("Degree must be more than zero");
        }
        public IActionResult Index()
        {
            List<Course> courses = db.courses.Include(c =>c.Department).ToList();
            return View(courses);
        }
        public IActionResult GetCourseByDept( int deptID)
        {
            List<Course> courses = db.courses.Where(c=>c.Dept_ID == deptID).ToList();
            return Json(courses);
        }
        public IActionResult AddNew()
        {
            List<Department> departments = departmentRepository.GetAll();
            CourseVM courseVM = new CourseVM();
            courseVM.Departments = departments;
            return View(courseVM);
        }
        [HttpPost]

        public IActionResult Add(Course course)
        {

            if (ModelState.IsValid)
            {
                try
                { 
                    courseReposirory.Insert(course);
                    return RedirectToAction("Index");

                }
                catch (Exception ex)
                {

                    ModelState.AddModelError("Dept_ID", "Selected Department");
                    ModelState.AddModelError(string.Empty, ex.Message);
                     
                }
               
            }
            List<Department> departments =departmentRepository.GetAll();
            CourseVM courseVM = new CourseVM();
            courseVM.Departments = departments;
            courseVM.name = course.name;
            courseVM.degree = course.degree;
            courseVM.mindegree = course.mindegree;
            courseVM.Dept_ID = course.Dept_ID;
            return View("AddNew", courseVM);


        }

        public IActionResult Details(int id)
        {           
            return View(courseReposirory.GetByID(id));
        }
        
        [HttpGet]       
        public IActionResult Edit(int id)
        {
            Course course = courseReposirory.GetByID(id);
            List<Department> departments = db.departments.ToList();
            CourseVM courseVM = new CourseVM();
            courseVM.Departments = departments;
            courseVM.id = id;
            courseVM.name = course.name;
            courseVM.degree = course.degree;
            courseVM.mindegree = course.mindegree;
            courseVM.Dept_ID = course.Dept_ID;            
            return View("Edit", courseVM);
        }

        [HttpPost]
        public IActionResult Edit([FromRoute] int id, Course course)
        {
            if (ModelState.IsValid && course.degree > 0 && course.mindegree > 0)
            {
                courseReposirory.Update(id, course);
                return RedirectToAction("Index");
            }
            else
            {
                List<Department> departments = departmentRepository.GetAll();
                CourseVM courseVM = new CourseVM();
                courseVM.Departments = departments;
                courseVM.name = course.name;
                courseVM.degree = course.degree;
                courseVM.mindegree = course.mindegree;
                courseVM.Dept_ID = course.Dept_ID;
                return View("AddNew", courseVM);

            }            
        }


        public IActionResult Delete(int id)
        {
           courseReposirory.Delete(id);
            return RedirectToAction("Index");
        }
        
    }
}
