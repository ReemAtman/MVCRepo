namespace MVC.Models
{
    public class Department
    {
        public int id { get; set; }
        public string name { get; set; }
        public string manager { get; set; }
        public virtual List<Instructor>? Instructors { get; set; }
        public virtual List<Course>? Course { get; set; }
        public virtual List<Trainee>? Trainee { get; set; }
    }
}
