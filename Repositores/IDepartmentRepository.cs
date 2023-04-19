using MVC.Models;

namespace MVC.Repositores
{
    public interface IDepartmentRepository
    {
        List<Department> GetAll();
        Department GetByID(int id);
        void Insert(Department course);
        void Update(int id, Department course);
        void Delete(int id);
    }
}
