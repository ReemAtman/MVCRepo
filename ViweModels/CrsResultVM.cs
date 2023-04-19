using MVC.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.ViweModels
{
    public class CrsResultVM
    {
        public string crs { get; set; }
        public int degree { get; set; }
       
        public string name{ get; set; }
        
        public string Color { get; set; }

    }
}
