using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Models;

namespace MVC.Repositores
{
    public class CourseReposirory: ICourseReposirory
    {
        EducationContext context;

        public CourseReposirory(EducationContext _context)
        {
            context = _context;
        }
        public List<Course> GetAll()
        {
            return context.courses.ToList();
        }
        public Course GetByID(int id)
        {
            return context.courses.Include(c => c.Department).FirstOrDefault(c => c.id == id);


        }        
        public void Insert(Course course)
        {
            context.courses.Add(course);
            context.SaveChanges();
        }
        public void Update(int id, Course course)
        {
            context.courses.Update(course);
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            context.courses.Remove(GetByID(id));
            context.SaveChanges();
        }
        public List<Course> GetCourseByDept(int deptID)
        {
           return context.courses.Where(c => c.Dept_ID == deptID).ToList();         
        }
    }
}
