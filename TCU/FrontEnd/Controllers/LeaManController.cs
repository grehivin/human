using bend.dal.entities;
using bend.bil;
using bend.dal;
using Microsoft.AspNetCore.Mvc;

namespace fend.Controllers
{
    public class LeaManController : Controller
    {
        public LeaManController()
        {
        }

        public IActionResult AlreadyExist()
        {
            return View();
        }

        public IActionResult DoesNotExist()
        { 
            return View();
        }

        #region Métodos de creación
        public IActionResult CreateCourse()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCourse(Courses _course)
        {
            ILeaMan learnMan = new LeaMan();

            if (ModelState.IsValid)
            {
                if (learnMan.Exist(_course)) 
                {
                    TempData["Message"] = string.Empty;
                    TempData["Message"] = _course.ToString();
                    return RedirectToAction(nameof(AlreadyExist));
                }

                await learnMan.Add(_course);
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult CreateTopic()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTopic(Topics _topic)
        {
            ILeaMan learnMan = new LeaMan();

            if (ModelState.IsValid)
            {
                if (learnMan.Exist(_topic))
                {
                    TempData["Message"] = string.Empty;
                    TempData["Message"] = _topic.ToString();
                    return RedirectToAction(nameof(AlreadyExist));
                }

                await learnMan.Add(_topic);
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult CreateContent()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateContent(Contents _content)
        {
            ILeaMan learnMan = new LeaMan();

            if (ModelState.IsValid)
            {
                if (learnMan.Exist(_content))
                {
                    TempData["Message"] = string.Empty;
                    TempData["Message"] = _content.ToString();
                    return RedirectToAction(nameof(AlreadyExist));
                }

                await learnMan.Add(_content);
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult CreateOption()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOption(Options _option)
        {
            ILeaMan learnMan = new LeaMan();

            if (ModelState.IsValid)
            {
                if (learnMan.Exist(_option))
                {
                    TempData["Message"] = string.Empty;
                    TempData["Message"] = _option.ToString();
                    return RedirectToAction(nameof(AlreadyExist));
                }

                await learnMan.Add(_option);
            }

            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region Métodos de actualización
        public IActionResult EditCourse(int id)
        {
            ILeaMan learnMan = new LeaMan();

            if (id == 0)
            {
                TempData["Item"] = new Courses().ToString();
                return RedirectToAction(nameof(DoesNotExist));
            }

            if (!learnMan.Exist("course", id))
            {
                TempData["Item"] = new Courses().ToString();
                return RedirectToAction(nameof(DoesNotExist));
            }

            return View(learnMan.GetCourse(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCourse(Courses _course)
        {
            ILeaMan learnMan = new LeaMan();

            if (ModelState.IsValid)
            {
                if (!learnMan.Exist(_course))
                {
                    TempData["Item"] = _course.ToString();
                    return RedirectToAction(nameof(DoesNotExist));
                }

                await learnMan.Update(_course);

                return RedirectToAction("Index", "Home");
            }

            return View(_course);
        }

        public IActionResult EditTopic(int id)
        {
            ILeaMan learnMan = new LeaMan();

            if (id == 0)
            {
                TempData["Item"] = new Topics().ToString();
                return RedirectToAction(nameof(DoesNotExist));
            }

            if (!learnMan.Exist("topic", id))
            {
                TempData["Item"] = new Topics().ToString();
                return RedirectToAction(nameof(DoesNotExist));
            }

            return View(learnMan.GetTopic(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditTopic(Topics _topic)
        {
            ILeaMan learnMan = new LeaMan();

            if (ModelState.IsValid)
            {
                if (!learnMan.Exist(_topic))
                {
                    TempData["Item"] = _topic.ToString();
                    return RedirectToAction(nameof(DoesNotExist));
                }

                await learnMan.Update(_topic);

                return RedirectToAction("Index", "Home");
            }

            return View(_topic);
        }

        public IActionResult EditContent(int id)
        {
            ILeaMan learnMan = new LeaMan();

            if (id == 0)
            {
                TempData["Item"] = new Contents().ToString();
                return RedirectToAction(nameof(DoesNotExist));
            }

            if (!learnMan.Exist("content", id))
            {
                TempData["Item"] = new Contents().ToString();
                return RedirectToAction(nameof(DoesNotExist));
            }

            return View(learnMan.GetContent(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditContent(Contents _content)
        {
            ILeaMan learnMan = new LeaMan();

            if (ModelState.IsValid)
            {
                if (!learnMan.Exist(_content))
                {
                    TempData["Item"] = _content.ToString();
                    return RedirectToAction(nameof(DoesNotExist));
                }

                await learnMan.Update(_content);

                return RedirectToAction("Index", "Home");
            }

            return View(_content);
        }

        public IActionResult EditOption(int id)
        {
            ILeaMan learnMan = new LeaMan();

            if (id == 0)
            {
                TempData["Item"] = new Options().ToString();
                return RedirectToAction(nameof(DoesNotExist));
            }

            if (!learnMan.Exist("option", id))
            {
                TempData["Item"] = new Options().ToString();
                return RedirectToAction(nameof(DoesNotExist));
            }

            return View(learnMan.GetOption(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditOption(Options _option)
        {
            ILeaMan learnMan = new LeaMan();

            if (ModelState.IsValid)
            {
                if (!learnMan.Exist(_option))
                {
                    TempData["Item"] = _option.ToString();
                    return RedirectToAction(nameof(DoesNotExist));
                }

                await learnMan.Update(_option);

                return RedirectToAction("Index", "Home");
            }

            return View(_option);
        }
        #endregion

        #region Métodos de borrado
        public IActionResult DeleteCourse(int id)
        {
            ILeaMan learnMan = new LeaMan();

            if (id == 0)
            {
                TempData["Item"] = new Courses().ToString();
                return RedirectToAction(nameof(DoesNotExist));
            }

            if (!learnMan.Exist("course", id))
            {
                TempData["Item"] = new Courses().ToString();
                return RedirectToAction(nameof(DoesNotExist));
            }

            return View(learnMan.GetCourse(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCourse(Courses _course)
        {
            ILeaMan learnMan = new LeaMan();
            await learnMan.Delete(_course);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult DeleteTopic(int id)
        {
            ILeaMan learnMan = new LeaMan();

            if (id == 0)
            {
                TempData["Item"] = new Topics().ToString();
                return RedirectToAction(nameof(DoesNotExist));
            }

            if (!learnMan.Exist("topic", id))
            {
                TempData["Item"] = new Topics().ToString();
                return RedirectToAction(nameof(DoesNotExist));
            }

            return View(learnMan.GetTopic(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteTopic(Topics _topic)
        {
            ILeaMan learnMan = new LeaMan();
            await learnMan.Delete(_topic);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult DeleteContent(int id)
        {
            ILeaMan learnMan = new LeaMan();

            if (id == 0)
            {
                TempData["Item"] = new Contents().ToString();
                return RedirectToAction(nameof(DoesNotExist));
            }

            if (!learnMan.Exist("content", id))
            {
                TempData["Item"] = new Contents().ToString();
                return RedirectToAction(nameof(DoesNotExist));
            }

            return View(learnMan.GetContent(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteContent(Contents _content)
        {
            ILeaMan learnMan = new LeaMan();
            await learnMan.Delete(_content);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult DeleteOption(int id)
        {
            ILeaMan learnMan = new LeaMan();

            if (id == 0)
            {
                TempData["Item"] = new Options().ToString();
                return RedirectToAction(nameof(DoesNotExist));
            }

            if (!learnMan.Exist("option", id))
            {
                TempData["Item"] = new Options().ToString();
                return RedirectToAction(nameof(DoesNotExist));
            }

            return View(learnMan.GetOption(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteOption(Options _option)
        {
            ILeaMan learnMan = new LeaMan();
            await learnMan.Delete(_option);

            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region Métodos de lectura
        public IActionResult ViewCourse(int id)
        {
            ILeaMan learnMan = new LeaMan();

            if (id == 0)
            {
                TempData["Item"] = new Courses().ToString();
                TempData["Message"] = "El código del curso no es válido.";
                return RedirectToAction(nameof(DoesNotExist));
            }

            if (learnMan.Exist("course", id))
            {
                TempData["Item"] = new Courses().ToString();
                TempData["Message"] = "El código del curso no existe.";
                return RedirectToAction(nameof(DoesNotExist));
            }

            return View(learnMan.GetCourse(id));
        }

        public IActionResult ViewTopic(int id)
        {
            ILeaMan learnMan = new LeaMan();

            if (id == 0)
            {
                TempData["Item"] = new Topics().ToString();
                TempData["Message"] = "El código del tema no es válido.";
                return RedirectToAction(nameof(DoesNotExist));
            }

            if (learnMan.Exist("topic", id))
            {
                TempData["Item"] = new Topics().ToString();
                TempData["Message"] = "El código del tema no existe.";
                return RedirectToAction(nameof(DoesNotExist));
            }

            return View(learnMan.GetTopic(id));
        }

        public IActionResult ViewContent(int id)
        {
            ILeaMan learnMan = new LeaMan();

            if (id == 0)
            {
                TempData["Item"] = new Contents().ToString();
                TempData["Message"] = "El código del contenido no es válido.";
                return RedirectToAction(nameof(DoesNotExist));
            }

            if (learnMan.Exist("content", id))
            {
                TempData["Item"] = new Contents().ToString();
                TempData["Message"] = "El código del contenido no existe.";
                return RedirectToAction(nameof(DoesNotExist));
            }

            return View(learnMan.GetContent(id));
        }

        public IActionResult ViewOption(int id)
        {
            ILeaMan learnMan = new LeaMan();

            if (id == 0)
            {
                TempData["Item"] = new Options().ToString();
                TempData["Message"] = "El código de la opción no es válido.";
                return RedirectToAction(nameof(DoesNotExist));
            }

            if (learnMan.Exist("option", id))
            {
                TempData["Item"] = new Options().ToString();
                TempData["Message"] = "El código de la opción no existe.";
                return RedirectToAction(nameof(DoesNotExist));
            }

            return View(learnMan.GetOption(id));
        }
        #endregion
    }
}
