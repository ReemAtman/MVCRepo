using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.ViweModels
{
    public class CourseVM
    {
        public int id { get; set; }
        [DisplayName("Course Name")]
        [Required]
        [MinLength(2, ErrorMessage = "Name must be more than 2 Char")]
        [MaxLength(20, ErrorMessage = "Name must be less than 20 letter")]
        [UniqueCoursName]
        public string name { get; set; }
        [DisplayName("Course Degree")]
        [Required]
        [Range(minimum: 50, maximum: 100)]

       public int degree { get; set; }
        [Required]
        [DisplayName("Course MinDegree")]
        [Remote("CheckMindegree", "Course", AdditionalFields = "degree", ErrorMessage = "Minmuim degree must be less than degree")]

        public int mindegree { get; set; }
        [DisplayName("Department Name")]   
        
        public int Dept_ID { get; set; }
        [DisplayName("Department")]
        public List<Department>? Departments { get; set; } = new List<Department>();
        

    }
}
