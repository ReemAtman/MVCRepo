using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Models
{
    public class Trainee
    {
        public int id { get; set; }
        public  string name { get; set; }
        public string img { get; set; }
        public string address { get; set; }
        public string grade { get; set; }
        [ForeignKey("Department")]
        public int Dept_ID { get; set; }
        public virtual Department? Department { get; set; }
        public virtual List<CrsResult>? CrsResult { get; set; }
    }
}
