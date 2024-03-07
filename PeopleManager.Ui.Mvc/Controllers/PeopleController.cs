﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeopleManager.Ui.Mvc.Core;
using PeopleManager.Ui.Mvc.Models;

namespace PeopleManager.Ui.Mvc.Controllers
{
    public class PeopleController : Controller
    {
        private readonly PeopleManagerDbContext _DbContext;
        public PeopleController(PeopleManagerDbContext peopleManagerDbContext)
        {
            _DbContext = peopleManagerDbContext;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var people = _DbContext.People
                .Include(p => p.Organization);
            return View(people.ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Person person)
        {
            _DbContext.People.Add(person);
            _DbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var person = _DbContext.People.FirstOrDefault(p => p.Id == id);
            if (person == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }

        [HttpPost]
        public IActionResult Edit(Person person)
        {
            var dbPerson = _DbContext.People.FirstOrDefault(p => p.Id == person.Id);
            if (dbPerson == null)
            {
                return RedirectToAction(nameof(Index));
            }
            _DbContext.People.Update(person);
            _DbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var person = _DbContext.People.FirstOrDefault(p => p.Id == id);
            if (person == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(person);
        }

        [HttpPost("/{Controller}/Delete/{id:int}"), ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed([FromRoute] int id)
        {
            var p = _DbContext.People.FirstOrDefault(p => p.Id == id);
            if (p == null)
            {
                return RedirectToAction(nameof(Index));
            }
            _DbContext.People.Remove(p);
            _DbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
