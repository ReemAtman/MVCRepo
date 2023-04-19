using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Models
{
    public class Course
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
        //[Remote("CheckDegree", "Course", ErrorMessage = "Degree must be more than zero")]
        
       
        public int mindegree { get; set; }
        public virtual List<Instructor>? Instructors { get; set; }
        [DisplayName("Department Name")]   
        [ForeignKey("Department")]       
        public int Dept_ID { get; set; }
        public virtual Department? Department { get; set; }
        public virtual List<CrsResult>? CrsResult { get; set; }

    }

}
