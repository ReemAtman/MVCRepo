using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Models;
using MVC.ViweModels;

namespace MVC.Controllers
{
    public class TraineeController : Controller
    {
        EducationContext db = new EducationContext();
        public IActionResult Index()
        {
           List<Trainee> trainees = db.trainees.Include(t => t.Department).ToList();
            return View(trainees);
        }
        public IActionResult ShowResult(int id,int crsId)
        {
            CrsResult crsResult = db.crsResults.Include(t=>t.Course).Include(t=>t.Trainee).FirstOrDefault(t=>t.Trainee_ID == id && t.Course_ID == crsId);
            if (crsResult.degree < crsResult.Course.mindegree) {
                ViewBag.color = "Red";
            }
            else
            {
                ViewBag.color = "Green";
            }
            return View("ShowResult", crsResult);
        }
        public IActionResult ShowCoursResult(int id)
        { 

            Course course = db.courses.FirstOrDefault(c=>c.id== id);
            List<CrsResult> crsResult = db.crsResults.Include(t => t.Course).Include(t => t.Trainee).Where(t => t.Course_ID == id ).ToList();
            List<CrsResultVM> crsResultVMs = new List<CrsResultVM>();
            foreach (var item in crsResult)
            {
                string clr;
                if (item.degree < item.Course.mindegree)
                {
                    clr = "Red";

                }
                else
                {
                    clr = "Blue";
                }
                crsResultVMs.Add(new CrsResultVM {
                    crs = item.Course.name, name=item.Trainee.name,Color=clr ,degree=item.degree           


                });
          
            }
            
            return View("ShowCoursResult", crsResultVMs);
        }

        
        public IActionResult ShowTrainneResult(int id)
        {
            List<CrsResult> trineeResult = db.crsResults.Include(t => t.Course).Include(t => t.Trainee).Where(t => t.Trainee_ID == id).ToList();
            List<CrsResultVM> crsResultVMs = new List<CrsResultVM>();
            foreach (var item in trineeResult)
            {
                string clr;
                if (item.degree < item.Course.mindegree)
                {
                    clr = "Red";

                }
                else
                {
                    clr = "Blue";
                }
                crsResultVMs.Add(new CrsResultVM
                {
                    crs = item.Course.name,
                    name = item.Trainee.name,
                    Color = clr,
                    degree = item.degree


                });

            }

            return View("ShowTrainneResult", crsResultVMs);
        }
    }
}
