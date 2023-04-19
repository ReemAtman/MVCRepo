using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Models
{
    public class CrsResult
    {
        public int id { get; set; }
        public int degree { get; set; }
        [ForeignKey("Course")]
        public int Course_ID { get; set; }
        public virtual Course? Course { get; set; }
        [ForeignKey("Trainee")]
        public int Trainee_ID { get; set; }
        public virtual Trainee? Trainee { get; set; }

    }
}
