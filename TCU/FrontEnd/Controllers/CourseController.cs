using Microsoft.AspNetCore.Mvc;

namespace Curso_DDHH_ESP.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
