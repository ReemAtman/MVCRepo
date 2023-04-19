using MVC.Models;

namespace MVC.Repositores
{
    public interface ICourseReposirory
    {
         List<Course> GetAll();
         Course GetByID(int id);
        void Insert(Course course);
        void Update(int id, Course course);
        void Delete(int id);
        List<Course> GetCourseByDept(int deptID);
    }
}
