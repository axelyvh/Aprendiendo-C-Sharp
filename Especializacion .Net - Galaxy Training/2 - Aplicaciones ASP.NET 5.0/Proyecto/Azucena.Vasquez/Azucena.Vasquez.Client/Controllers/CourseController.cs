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
    public class CourseController : Controller
    {

        private readonly IUniversityService _universityService;
        public CourseController(IUniversityService universityService)
        {
            _universityService = universityService;
        }

        [Authorize(Roles = Roles.Administrator)]
        public IActionResult Index()
        {
            return View(_universityService.GetCourses());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CoursesViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _universityService.InsertCourse(model);
                    return RedirectToAction(nameof(Index));
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IActionResult Edit(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            CoursesViewModel model = _universityService.GetCourse(Id.Value);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(int Id, CoursesViewModel model)
        {
            if (Id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _universityService.UpdateCourse(model);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_universityService.CourseExists(model.Id))
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

            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int Id)
        {
            _universityService.DeleteCourse(Id);
            return RedirectToAction(nameof(Index));
        }

    }
}
