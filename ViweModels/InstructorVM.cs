using MVC.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.ViweModels
{
    public class InstructorVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Img { get; set; }
        public string Address { get; set; }
        public double Salary { get; set; }
        public int Dept_ID { get; set; }        
        public int Course_ID { get; set; }


        public List<Department> Departments { get; set; } = new List<Department>();
        public List<Course> Courses { get; set; } = new List<Course>();
        
    }
}
