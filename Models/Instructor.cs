using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Models
{
    public class Instructor
    {
        public int id { get; set; }
        public string name { get; set; }
        public string img { get; set; }
        public string address { get; set; }
        public double salary { get; set; }

        [ForeignKey("Department")]
        public int Dept_ID { get; set; }
        [ForeignKey("Course")]
        public int Course_ID { get; set; }
        public virtual Department? Department { get; set; }
        public virtual Course? Course { get; set; }

      
            
    }
}
