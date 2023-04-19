using MVC.Models;

namespace MVC.Repositores
{
    public class DepartmentRepository: IDepartmentRepository
    {
        EducationContext context;

        public DepartmentRepository(EducationContext _context)
        {
            context= _context;
        }
        public List<Department> GetAll()
        {
            return context.departments.ToList();
        }
        public Department GetByID(int id)
        {
            return context.departments.FirstOrDefault(c => c.id == id);
        }
        public void Insert(Department department)
        {
            context.departments.Add(department);
            context.SaveChanges();
        }
        public void Update(int id, Department department)
        {
            context.departments.Update(department);
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            context.departments.Remove(GetByID(id));
            context.SaveChanges();
        }
        
    }
}
