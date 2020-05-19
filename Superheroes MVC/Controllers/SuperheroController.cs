using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Superheroes_MVC.Data;
using Superheroes_MVC.Models;

namespace Superheroes_MVC.Controllers
{
    public class SuperheroController : Controller
    {
        private ApplicationDbContext _context;

        public SuperheroController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Superhero
        public ActionResult Index()
        {
            var heroes = _context.Superheroes;
            return View(heroes);
        }

        // GET: Superhero/Details/5
        public ActionResult Details(int id)
        {
            var selectedHero = _context.Superheroes.Where(x => x.Id == id).SingleOrDefault();
            return View(selectedHero);
        }

        // GET: Superhero/Create
        public ActionResult Create()
        {
            Superhero newHero = new Superhero();
            return View(newHero);
        }

        // POST: Superhero/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Superhero hero)
        {
            try
            {
                // TODO: Add insert logic here
                _context.Superheroes.Add(hero);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Superhero/Edit/5
        public ActionResult Edit(int id)
        {
            var heroToEdit =_context.Superheroes.Where(x => x.Id == id).SingleOrDefault();
            return View(heroToEdit);
        }

        // POST: Superhero/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Superhero hero)
        {
            try
            {
                // TODO: Add update logic here
                Superhero thisHero = _context.Superheroes.Where(x => x.Id == hero.Id).SingleOrDefault();
                thisHero.Name = hero.Name;
                thisHero.Ego = hero.Ego;
                thisHero.PrimaryAbility = hero.PrimaryAbility;
                thisHero.SecondaryAbility = hero.SecondaryAbility;
                thisHero.CatchPhrase = hero.CatchPhrase;
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Superhero/Delete/5
        public ActionResult Delete(int id)
        {
            Superhero heroToDelete = _context.Superheroes.Where(x => x.Id == id).SingleOrDefault();
            return View(heroToDelete);
        }

        // POST: Superhero/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Superhero hero)
        {
            try
            {
                // TODO: Add delete logic here
                _context.Superheroes.Remove(hero);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}