using Azucena.Vasquez.Client.Helper;
using Azucena.Vasquez.Client.Models;
using Azucena.Vasquez.Client.Services;
using Azucena.Vasquez.Infrastructure.Helper.Audit;
using Azucena.Vasquez.Infrastructure.Helper.Log;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace Azucena.Vasquez.Client.Controllers
{
    [ServiceFilter(typeof(LogFilter))]
    [Audit]
    public class ScoreController : Controller
    {

        private readonly IUniversityService _universityService;
        public ScoreController(IUniversityService universityService)
        {
            _universityService = universityService;
        }

        [Authorize(Roles = Roles.AdministratorOrProfesorOrAlumno)]
        public IActionResult Index()
        {
            return View(_universityService.GetScores());
        }

        [Authorize(Policy = Policies.CreateUser)]
        public IActionResult Create()
        {

            ViewBag.LstStudent = _universityService.GetUsersBy_Role("ALUMNO");
            ViewBag.LstCourses = _universityService.GetCourses();

            return View();

        }

        [Authorize(Policy = Policies.CreateUser)]
        [HttpPost]
        public IActionResult Create(ScoresViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _universityService.InsertScore(model);
                    return RedirectToAction(nameof(Index));
                }

                ViewBag.LstStudent = _universityService.GetUsersBy_Role("ALUMNO");
                ViewBag.LstCourses = _universityService.GetCourses();
                return View(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [Authorize(Policy = Policies.EditUser)]
        public IActionResult Edit(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            ScoresViewModel model = _universityService.GetScore(Id.Value);
            if (model == null)
            {
                return NotFound();
            }

            ViewBag.LstStudent = _universityService.GetUsersBy_Role("ALUMNO");
            ViewBag.LstCourses = _universityService.GetCourses();

            return View(model);
        }

        [Authorize(Policy = Policies.EditUser)]
        [HttpPost]
        public IActionResult Edit(int Id, ScoresViewModel model)
        {
            if (Id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _universityService.UpdateScore(model);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_universityService.ScoreExists(model.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            ViewBag.LstStudent = _universityService.GetUsersBy_Role("ALUMNO");
            ViewBag.LstCourses = _universityService.GetCourses();
            return View(model);
        }

        [Authorize(Policy = Policies.DeleteUser)]
        public IActionResult Delete(int Id)
        {
            _universityService.DeleteScore(Id);
            return RedirectToAction(nameof(Index));
        }

    }
}
