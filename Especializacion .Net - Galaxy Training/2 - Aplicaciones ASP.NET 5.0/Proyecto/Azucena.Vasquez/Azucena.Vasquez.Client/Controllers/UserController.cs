using Azucena.Vasquez.Client.Helper;
using Azucena.Vasquez.Client.Models;
using Azucena.Vasquez.Client.Services;
using Azucena.Vasquez.Infrastructure.Helper.Audit;
using Azucena.Vasquez.Infrastructure.Helper.Log;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Azucena.Vasquez.Client.Controllers
{
    [ServiceFilter(typeof(LogFilter))]
    [Audit]
    public class UserController : Controller
    {

        private readonly IUniversityService _universityService;
        public UserController(IUniversityService universityService)
        {
            _universityService = universityService;
        }

        [Authorize(Roles = Roles.Administrator)]
        public IActionResult Index()
        {
            return View(_universityService.GetUsers());
        }

        public IActionResult Create()
        {
            ViewBag.LstRoles = _universityService.GetRoles();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _universityService.InsertUser(model);
                    return RedirectToAction(nameof(Index));
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IActionResult Edit(string Id)
        {
            if (string.IsNullOrEmpty(Id))
            {
                return NotFound();
            }

            UserViewModel model = _universityService.GetUser(Id);
            if (model == null)
            {
                return NotFound();
            }

            ViewBag.LstRoles = _universityService.GetRoles();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string Id, UserViewModel model)
        {
            if (string.IsNullOrEmpty(Id))
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _universityService.UpdateUser(model);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_universityService.UserExists(model.Id))
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
        public async Task<IActionResult> Delete(string Id)
        {
            await _universityService.DeleteUser(Id);
            return RedirectToAction(nameof(Index));
        }

    }
}
