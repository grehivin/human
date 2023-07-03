using BackEnd.bil;
using BackEnd.dal.entities;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FrontEnd.Controllers
{
    public class StudentController : Controller
    {
        // GET: StudentViewModel/Create
        public IActionResult SignUp()
        {
            return View();
        }

        // POST: StudentViewModel/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(StudentViewModel student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ISignUp enrollment = new SignUp();

                    await enrollment.UserSignUp(student.Person, student.User);

                    return RedirectToAction("Index", "Home");
                }
            }
            catch
            {
                throw;
            }

            return View();
        }
    }
}
