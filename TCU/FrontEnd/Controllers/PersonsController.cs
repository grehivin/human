using BackEnd.dal;
using BackEnd.dal.entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace FrontEnd.Controllers
{
    public class PersonsController : Controller
    {
        private readonly HREContext _hre;

        public PersonsController()
        {
            _hre = new HREContext();
        }

        // GET: Persons
        public async Task<IActionResult> Index()
        {
            return View(await _hre.Persons.ToListAsync());
        }

        // GET: Persons/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var person = await _hre.Persons
                .Include(p => p.Id)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (person == null)
                return NotFound();

            return View(person);
        }

        // GET: Persons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Persons/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Lastname,Email,UserId")] Persons person)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _hre.Add(person);
                    await _hre.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                throw;
            }

            return View(person);
        }

        // GET: Persons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var person = await _hre.Persons.FindAsync(id);

            if (person == null)
                return NotFound();

            return View(person);
        }

        // POST: Persons/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Lastname,Email,UserId")] Persons person)
        {
            try
            {
                if (id != person.Id)
                    return NotFound();

                if (ModelState.IsValid)
                {
                    try
                    {
                        _hre.Update(person);
                        await _hre.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        // if person doesn't exist return not found
                        if (!PersonExist(id))
                            return NotFound();

                        throw;
                    }

                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                throw;
            }

            return View(person);
        }

        // GET: Persons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var person = await _hre.Persons.FirstOrDefaultAsync(p => p.Id == id);

            if (person == null)
                return NotFound();

            return View(person);
        }

        // POST: PersonsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var person = await _hre.Persons.FindAsync(id);

                _hre.Persons.Remove(person);
                await _hre.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));

                throw;
            }
        }

        private bool PersonExist(int id)
        {
            return _hre.Persons.Any(p => p.Id == id);
        }
    }
}
